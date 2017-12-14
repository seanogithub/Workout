using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_DownloadWorkout : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIDownloading;
	public GameObject WorkoutButton;
	
	public SaveDownloadWorkoutData UserDownloadWorkoutData;
	public SaveWorkoutData UserWorkoutData;

	public WorkoutData item = new WorkoutData();
	
	public List<GameObject> WorkoutButtonArray = new List<GameObject>();
	
	public Transform WorkoutContentPanel;
	public GameObject WorkoutContentPanelScrollBar;
	public bool ScrollBarMove = false;
	
	public int SelectedWorkout = -1;
	public List<string> DownloadWorkoutList = new List<string> ();
	public List<WorkoutData> DownloadWorkoutData = new List<WorkoutData>();
    public List<string> DownloadWorkoutFileList = new List<string>();

    public Color SelectedColor = Color.red;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
		UserDownloadWorkoutData = new SaveDownloadWorkoutData();
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
		DownloadWorkoutList = new List<string> ();
		DownloadWorkoutData = new List<WorkoutData>();
        DownloadWorkoutFileList = new List<string>();
        UserDownloadWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadWorkoutData;
		SelectedWorkout = -1;
		ClearScrollList ();
		PopulateScrollList ();
		
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadWorkoutData.DownloadWorkout.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadWorkoutData.DownloadWorkout.Length, WorkoutContentPanel);
		}
		else
		{
			WorkoutContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}
	
	public void ClearScrollList()
	{
		for (int i = WorkoutContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(WorkoutContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateScrollList () 
	{
		WorkoutButtonArray.Clear ();
		foreach (var item in UserDownloadWorkoutData.DownloadWorkout)
		{
			GameObject newButton = Instantiate (WorkoutButton) as GameObject;
			WorkoutButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
            newButton.transform.Find("Text_Time").GetComponent<Text>().text = item.Time;
            string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => WorkoutButtonClicked(selectedButton));
			newButton.transform.SetParent (WorkoutContentPanel);
		}
//		WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void WorkoutButtonClicked(string myText)
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindDownloadWorkoutByName(myText);
		SelectedWorkout = myIndex;

		bool sel = false;
		foreach (var item in DownloadWorkoutList) 
		{
			if (item == myText)
			{
				sel = true;
			}
		}
		if (sel) 
		{
			// remove from list
			DownloadWorkoutList.Remove(myText);
			WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = Color.white;
		}
		else
		{
			DownloadWorkoutList.Add(myText);
			WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true && UserBlobManager.GetComponent<UserBlobManager>().UserDownloadWorkoutData.DownloadWorkout.Length > 5)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadWorkoutData.DownloadWorkout.Length;
			float ScrollPercentage =  WorkoutContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadWorkoutData.DownloadWorkout.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			WorkoutContentPanel.localPosition = tempPos;
		}
		ScrollBarMove = true;
	}
	
	public void OnPanelValueChanged()
	{		
		ScrollBarMove = false;
		int ButtonHeight = 200;
		//		double ButtonOffset = 2.8;
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserDownloadWorkoutData.DownloadWorkout.Length;
		float ScrollValue =  ((WorkoutContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		WorkoutContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		myScrollPanel.localPosition = tempPos;
	}

	public void OnDownloadButtonPressed ()
	{
		if(DownloadWorkoutList.Count > 0)
		{
            //build shared Workout data
            for (int i = 0; i < DownloadWorkoutList.Count; i++)
            {
                string FileName = "";
                int WorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().FindDownloadWorkoutByName(DownloadWorkoutList[i]);
                FileName = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadWorkoutData.DownloadWorkout[WorkoutIndex].FileName;
                DownloadWorkoutFileList.Add(FileName);
            }
            UIDownloading.GetComponent<UI_Downloading>().TrainingFileList = new List<string>();
            UIDownloading.GetComponent<UI_Downloading>().WorkoutFileList = DownloadWorkoutFileList;
            UIDownloading.GetComponent<UI_Downloading>().ExerciseFileList = new List<string>();
            UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadingState");
        }
		else 
		{
		}
	}
}
