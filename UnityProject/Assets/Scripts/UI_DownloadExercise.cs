using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_DownloadExercise : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIDownloading;
    public GameObject exerciseButton;

	
//	public List<ExerciseData> UserExerciseData = new List<ExerciseData>();	
	public SaveDownloadExerciseData UserDownloadExerciseData;
//	public List<WorkoutData> UserWorkoutData = new List<WorkoutData>();
	public SaveWorkoutData UserWorkoutData;

	public ExerciseData item = new ExerciseData();
	
	public List<GameObject> ExerciseButtonArray = new List<GameObject>();
	
	public Transform ExerciseContentPanel;
	public GameObject ExerciseContentPanelScrollBar;
	public bool ScrollBarMove = false;
	
	public int SelectedExercise = -1;
	public List<string> DownloadExerciseList = new List<string> ();
	public List<ExerciseData> DownloadExerciseData = new List<ExerciseData>();
    public List<string> DownloadExerciseFileList = new List<string>();

	public Color SelectedColor = Color.red;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
		UserDownloadExerciseData = new SaveDownloadExerciseData();
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
		DownloadExerciseList = new List<string> ();
		DownloadExerciseData = new List<ExerciseData>();
        DownloadExerciseFileList = new List<string>();
        UserDownloadExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadExerciseData;
		SelectedExercise = -1;
		ClearScrollList ();
		PopulateScrollList ();
		
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadExerciseData.DownloadExercise.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadExerciseData.DownloadExercise.Length, ExerciseContentPanel);
		}
		else
		{
			ExerciseContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}
	
	public void ClearScrollList()
	{
		for (int i = ExerciseContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(ExerciseContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateScrollList () 
	{
		ExerciseButtonArray.Clear ();
		foreach (var item in UserDownloadExerciseData.DownloadExercise)
		{
			GameObject newButton = Instantiate (exerciseButton) as GameObject;
			ExerciseButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
            newButton.transform.Find("Text_Time").GetComponent<Text>().text = item.BodyPart;
            string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => ExerciseButtonClicked(selectedButton));
			newButton.transform.SetParent (ExerciseContentPanel);
		}
//		ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void ExerciseButtonClicked(string myText)
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindDownloadExerciseByName(myText);
		SelectedExercise = myIndex;

		bool sel = false;
		foreach (var item in DownloadExerciseList) 
		{
			if (item == myText)
			{
				sel = true;
			}
		}
		if (sel) 
		{
			// remove from list
			DownloadExerciseList.Remove(myText);
			ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = Color.white;
		}
		else
		{
			DownloadExerciseList.Add(myText);
			ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true && UserBlobManager.GetComponent<UserBlobManager>().UserDownloadExerciseData.DownloadExercise.Length > 5)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadExerciseData.DownloadExercise.Length;
			float ScrollPercentage =  ExerciseContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadExerciseData.DownloadExercise.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			ExerciseContentPanel.localPosition = tempPos;
		}
		ScrollBarMove = true;
	}
	
	public void OnPanelValueChanged()
	{		
		ScrollBarMove = false;
		int ButtonHeight = 200;
		//		double ButtonOffset = 2.8;
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadExerciseData.DownloadExercise.Length;
		float ScrollValue =  ((ExerciseContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		ExerciseContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		myScrollPanel.localPosition = tempPos;
	}

	public void OnDownloadButtonPressed ()
	{
		if(DownloadExerciseList.Count > 0)
		{
			//build shared exercise data
            for (int i = 0; i < DownloadExerciseList.Count; i++)
            {
                string FileName = "";
                int ExerciseIndex = UserBlobManager.GetComponent<UserBlobManager>().FindDownloadExerciseByName(DownloadExerciseList[i]);
                FileName = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadExerciseData.DownloadExercise[ExerciseIndex].FileName;
                DownloadExerciseFileList.Add(FileName);
            }
            UIDownloading.GetComponent<UI_Downloading>().TrainingFileList = new List<string>();
            UIDownloading.GetComponent<UI_Downloading>().WorkoutFileList = new List<string>();
            UIDownloading.GetComponent<UI_Downloading>().ExerciseFileList = DownloadExerciseFileList;
            UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadingState");
		}
		else 
		{
		}
	}
}
