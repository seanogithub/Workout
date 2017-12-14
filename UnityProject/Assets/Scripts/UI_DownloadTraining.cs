using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_DownloadTraining : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIDownloading;
    public GameObject TrainingButton;
	
	public SaveDownloadTrainingData UserDownloadTrainingData;
	public SaveTrainingData UserTrainingData;

	public TrainingData item = new TrainingData();
	
	public List<GameObject> TrainingButtonArray = new List<GameObject>();
	
	public Transform TrainingContentPanel;
	public GameObject TrainingContentPanelScrollBar;
	public bool ScrollBarMove = false;
	
	public int SelectedTraining = -1;
	public List<string> DownloadTrainingList = new List<string> ();
	public List<TrainingData> DownloadTrainingData = new List<TrainingData>();
    public List<string> DownloadTrainingFileList = new List<string>();

    public Color SelectedColor = Color.red;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
		UserDownloadTrainingData = new SaveDownloadTrainingData();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Initialize) 
		{
			Init ();
		}
	}
	
	public void Init()
	{
		Initialize = false;
		DownloadTrainingList = new List<string> ();
		DownloadTrainingData = new List<TrainingData>();
        DownloadTrainingFileList = new List<string>();
        UserDownloadTrainingData = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadTrainingData;
		SelectedTraining = -1;
		ClearScrollList ();
		PopulateScrollList ();
		
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadTrainingData.DownloadTraining.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadTrainingData.DownloadTraining.Length, TrainingContentPanel);
		}
		else
		{
			TrainingContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}
	
	public void ClearScrollList()
	{
		for (int i = TrainingContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(TrainingContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateScrollList () 
	{
		TrainingButtonArray.Clear ();
		foreach (var item in UserDownloadTrainingData.DownloadTraining)
		{
			GameObject newButton = Instantiate (TrainingButton) as GameObject;
			TrainingButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
            newButton.transform.Find("Text_Time").GetComponent<Text>().text = (item.NumberOfDays.ToString() + " Days");
            string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => TrainingButtonClicked(selectedButton));
			newButton.transform.SetParent (TrainingContentPanel);
		}
//		TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void TrainingButtonClicked(string myText)
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindDownloadTrainingByName(myText);
		SelectedTraining = myIndex;

		bool sel = false;
		foreach (var item in DownloadTrainingList) 
		{
			if (item == myText)
			{
				sel = true;
			}
		}
		if (sel) 
		{
			// remove from list
			DownloadTrainingList.Remove(myText);
			TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = Color.white;
		}
		else
		{
			DownloadTrainingList.Add(myText);
			TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true && UserBlobManager.GetComponent<UserBlobManager>().UserDownloadTrainingData.DownloadTraining.Length > 5)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadTrainingData.DownloadTraining.Length;
			float ScrollPercentage =  TrainingContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadTrainingData.DownloadTraining.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			TrainingContentPanel.localPosition = tempPos;
		}
		ScrollBarMove = true;
	}
	
	public void OnPanelValueChanged()
	{		
		ScrollBarMove = false;
		int ButtonHeight = 200;
		//		double ButtonOffset = 2.8;
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadTrainingData.DownloadTraining.Length;
		float ScrollValue =  ((TrainingContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		TrainingContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		myScrollPanel.localPosition = tempPos;
	}

	public void OnDownloadButtonPressed ()
	{
		if(DownloadTrainingList.Count > 0)
		{
            //build shared Training data
            for (int i = 0; i < DownloadTrainingList.Count; i++)
            {
                string FileName = "";
                int TrainingIndex = UserBlobManager.GetComponent<UserBlobManager>().FindDownloadTrainingByName(DownloadTrainingList[i]);
                FileName = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadTrainingData.DownloadTraining[TrainingIndex].FileName;
                DownloadTrainingFileList.Add(FileName);
            }
            UIDownloading.GetComponent<UI_Downloading>().TrainingFileList = DownloadTrainingFileList;
            UIDownloading.GetComponent<UI_Downloading>().WorkoutFileList = new List<string>();
            UIDownloading.GetComponent<UI_Downloading>().ExerciseFileList = new List<string>();
            UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadingState");
        }
		else 
		{
		}
	}
}
