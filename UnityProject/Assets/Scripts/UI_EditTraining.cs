using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class UI_EditTraining : MonoBehaviour {
	
	public bool Initialize = false;
	public bool UpdateUIFlag = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;

	public GameObject BackgroundImage;
	private Sprite[] EditWorkoutBackgroundBitmaps; 
	private Timer BackgroundTimer = new Timer();

	public GameObject UIText_TrainingName;
	
	public GameObject TrainingDayButton;
	public GameObject TrainingWorkoutButton;
	public GameObject WorkoutButton;
	
	public SaveWorkoutData UserWorkoutData;
//	public List<TrainingData> UserTrainingData = new List<TrainingData>();
	public SaveTrainingData UserTrainingData;

	public TrainingData CurrentTraining = new TrainingData();
	
	public Transform TrainingContentPanel;
	public Transform WorkoutContentPanel;
	
	public GameObject WorkoutContentPanelScrollBar;
	public bool WorkoutScrollBarMove = false;
	public GameObject TrainingContentPanelScrollBar;
	public bool TrainingScrollBarMove = false;
	
	public List<GameObject> TrainingDayButtonArray = new List<GameObject>();
	public List<GameObject> WorkoutButtonArray = new List<GameObject>();
	
	public int SelectedWorkout = 0;
	public int SelectedTrainingDay = 0;
	public int SelectedTrainingWorkout = 0;
	public int SelectedTrainingButtonIndex = 0;

	private int NumFilteredWorkouts;
	
	public Color SelectedColor = Color.red;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
//		EditWorkoutBackgroundBitmaps = Resources.LoadAll<Sprite>("UI/EditWorkoutBackground");  
		BackgroundTimer.Interval = 1000/30;
		BackgroundTimer.Elapsed += new ElapsedEventHandler (OnBackgroundTimeEvent);
	}
	
	// Use this for initialization
	void Start () 
	{
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

		BackgroundTimer.Start();

		CurrentTraining = new TrainingData();
		CurrentTraining.Name = "";
		CurrentTraining.Description = "";
        CurrentTraining.Type = "";
        //CurrentTraining.DayArray = new List<DayData>();
        CurrentTraining.DayArray = new SaveDayData();

        int CurrentTrainingIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex;
		CurrentTraining.Name = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training[CurrentTrainingIndex].Name;
		CurrentTraining.Description = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training[CurrentTrainingIndex].Description;
        CurrentTraining.Type = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[CurrentTrainingIndex].Type;
        //CurrentTraining.DayArray = new List<DayData>(UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training[CurrentTrainingIndex].DayArray);
        CurrentTraining.DayArray = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[CurrentTrainingIndex].DayArray;

        UIText_TrainingName.GetComponent<Text> ().text = CurrentTraining.Name;
		
		SelectedWorkout = 0;
		SelectedTrainingDay = 0;
		SelectedTrainingWorkout = 0;
		SelectedTrainingButtonIndex = 0;
		
		ClearWorkoutScrollList ();
		PopulateWorkoutScrollList ();
		ClearTrainingScrollList ();
		PopulateTrainingScrollList ();
        //if(CurrentTraining.DayArray.Count > 6)
        if(CurrentTraining.DayArray.Day.Length > 6)
        {
            //SetScrollRectPositionFromIntWithOffset (0, 2.6, 100, CurrentTraining.DayArray.Count, TrainingContentPanel);
            SetScrollRectPositionFromIntWithOffset(0, 2.6, 100, CurrentTraining.DayArray.Day.Length, TrainingContentPanel);
        }
        else
		{
			TrainingContentPanel.localPosition = new Vector3 (0, 0, 0);
		}
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout.Length > 8)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.6, 100, NumFilteredWorkouts, WorkoutContentPanel);
		}
		else
		{
			WorkoutContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
		
	}
	
	public void UpdateUI()
	{
		UpdateUIFlag = false;
		ClearWorkoutScrollList ();
		PopulateWorkoutScrollList ();
		ClearTrainingScrollList ();
		PopulateTrainingScrollList ();
	}

	public void OnBackgroundTimeEvent(object source, ElapsedEventArgs e)
	{
		
	}

	public void ClearWorkoutScrollList()
	{
		for (int i = WorkoutContentPanel.childCount - 1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(WorkoutContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateWorkoutScrollList () 
	{
//		UserWorkoutData.Clear ();
		UserWorkoutData = new SaveWorkoutData ();
		WorkoutButtonArray.Clear ();
		NumFilteredWorkouts = 0;
//		string WorkoutFilterTypeString = UserBlobManager.GetComponent<UserBlobManager> ().WorkoutFilterType;
//		string WorkoutFilterBodyPartString = UserBlobManager.GetComponent<UserBlobManager> ().WorkoutFilterBodyPart;
		string WorkoutFilterTypeString = "None"; //UserBlobManager.GetComponent<UserBlobManager> ().WorkoutFilterType;
		string WorkoutFilterBodyPartString = "None"; //UserBlobManager.GetComponent<UserBlobManager> ().WorkoutFilterBodyPart;
		foreach (var item in UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout)
		{
//			if(((WorkoutFilterTypeString == "None") ||
//			    (WorkoutFilterTypeString == item.Type)) &&
//			   ((WorkoutFilterBodyPartString == "None") ||
//			 (WorkoutFilterBodyPartString == item.BodyPart)))
			if(((WorkoutFilterTypeString == "None")) &&
			   ((WorkoutFilterBodyPartString == "None")))
			{
				UserWorkoutData.Add(item);
				NumFilteredWorkouts++;
				GameObject newButton = Instantiate (WorkoutButton) as GameObject;
				WorkoutButtonArray.Add(newButton);
				newButton.name = ("Button_" + item.Name);
				string tempText = item.Name;
				newButton.GetComponentInChildren<Text>().text = tempText;
				newButton.GetComponentInChildren<Text>().fontSize = 50;
				string selectedButton = item.Name;
				newButton.GetComponent<Button>().onClick.AddListener(() => ExcerciseButtonClicked(selectedButton));
				newButton.transform.SetParent (WorkoutContentPanel);
			}
		}
		if(WorkoutButtonArray.Count > 0)
		{
			WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void ClearTrainingScrollList()
	{
		for (int i = TrainingContentPanel.childCount - 1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(TrainingContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateTrainingScrollList () 
	{
		TrainingDayButtonArray.Clear ();
		int ButtonIndex = 0;
        //for(int DayIndex = 0; DayIndex < CurrentTraining.DayArray.Count; DayIndex++)
        for(int DayIndex = 0; DayIndex < CurrentTraining.DayArray.Day.Length; DayIndex++)
        {
            GameObject newButton = Instantiate (TrainingDayButton) as GameObject;
			TrainingDayButtonArray.Add(newButton);
			newButton.name = ("Button_Day_" + (DayIndex + 1).ToString());
			string tempText = ("  Day " + (DayIndex + 1).ToString());
			newButton.GetComponentInChildren<Text>().text = tempText;
			newButton.GetComponentInChildren<Text>().fontSize = 50;
			int tempTrainginButtonIndex = ButtonIndex;
			int tempDayIndex = DayIndex;
			newButton.GetComponent<Button>().onClick.AddListener(() => TrainingDayButtonClicked(tempTrainginButtonIndex, tempDayIndex));
			newButton.transform.SetParent (TrainingContentPanel);
			ButtonIndex++;
			// add workout name buttons
			//for(int NameIndex = 0; NameIndex < CurrentTraining.DayArray[DayIndex].DayWorkoutArray.Length; NameIndex++)
            for (int NameIndex = 0; NameIndex < CurrentTraining.DayArray.Day[DayIndex].DayWorkoutArray.Length; NameIndex++)
            {
                GameObject newWorkoutButton = Instantiate (TrainingWorkoutButton) as GameObject;
				TrainingDayButtonArray.Add(newWorkoutButton);
				//newWorkoutButton.name = CurrentTraining.DayArray[DayIndex].DayWorkoutArray[NameIndex].WorkoutName;
                newWorkoutButton.name = CurrentTraining.DayArray.Day[DayIndex].DayWorkoutArray[NameIndex].WorkoutName;
                //string tempWorkoutButtonText = CurrentTraining.DayArray[DayIndex].DayWorkoutArray[NameIndex].WorkoutName;
                string tempWorkoutButtonText = CurrentTraining.DayArray.Day[DayIndex].DayWorkoutArray[NameIndex].WorkoutName;
                newWorkoutButton.GetComponentInChildren<Text>().text = tempWorkoutButtonText;
				newWorkoutButton.GetComponentInChildren<Text>().fontSize = 50;
				int tempWorkoutButtonIndex = ButtonIndex;
				int tempWorkoutNameIndex = NameIndex;
				newWorkoutButton.GetComponent<Button>().onClick.AddListener(() => TrainingWorkoutButtonClicked(tempWorkoutButtonIndex, tempDayIndex, tempWorkoutNameIndex));
				newWorkoutButton.transform.SetParent (TrainingContentPanel);
				ButtonIndex++;
			}
		}
		if (TrainingDayButtonArray.Count > 0)
		{
			TrainingDayButtonArray[SelectedTrainingButtonIndex].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void ExcerciseButtonClicked(string myText)
	{
		WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = Color.white;
		//		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindWorkoutByName (myText);
		int myIndex = FindWorkoutByName (myText);
		SelectedWorkout = myIndex;
		WorkoutButtonArray[myIndex].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void TrainingDayButtonClicked(int myButtonIndex, int DayIndex)
	{
		TrainingDayButtonArray[SelectedTrainingButtonIndex].GetComponent<Image> ().color = Color.white;
		SelectedTrainingDay = DayIndex;
		SelectedTrainingButtonIndex = myButtonIndex;
		TrainingDayButtonArray[myButtonIndex].GetComponent<Image> ().color = SelectedColor;
	}

	public void TrainingWorkoutButtonClicked(int myButtonIndex, int DayIndex, int WorkoutIndex)
	{
		TrainingDayButtonArray[SelectedTrainingButtonIndex].GetComponent<Image> ().color = Color.white;
		SelectedTrainingDay = DayIndex;
		SelectedTrainingWorkout = WorkoutIndex;
		SelectedTrainingButtonIndex = myButtonIndex;
		TrainingDayButtonArray[myButtonIndex].GetComponent<Image> ().color = SelectedColor;
	}

	public void AddDayButtonPressed()
	{
		DayData tempDay = new DayData ();
		CurrentTraining.DayArray.Add (tempDay);
		ClearTrainingScrollList ();
		PopulateTrainingScrollList ();
	}

	public void AddWorkoutButtonPressed()
	{
		DayWorkoutData tempDayWorkoutData = new DayWorkoutData ();
		tempDayWorkoutData.WorkoutName = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[SelectedWorkout].Name;
//		CurrentTraining.DayArray [SelectedTrainingDay].DayWorkoutArray.Add (tempDayWorkoutData);
		CurrentTraining.DayArray.Day [SelectedTrainingDay].Add (tempDayWorkoutData);
		ClearTrainingScrollList ();
		PopulateTrainingScrollList ();
	}
	
	public void DeleteDayButtonPressed()
	{
		//if(CurrentTraining.DayArray.Count > 0)
        if (CurrentTraining.DayArray.Day.Length > 0)
        {
            CurrentTraining.DayArray.RemoveAt (SelectedTrainingDay);
			SelectedTrainingDay--;
			if(SelectedTrainingDay < 0) { SelectedTrainingDay = 0;}
			SelectedTrainingButtonIndex--;
			if(SelectedTrainingButtonIndex < 0) { SelectedTrainingButtonIndex = 0;}
			ClearTrainingScrollList ();
			PopulateTrainingScrollList ();
		}
	}

	public void DeleteWorkoutButtonPressed()
	{
		//if(CurrentTraining.DayArray[SelectedTrainingDay].DayWorkoutArray.Length > 0)
        if (CurrentTraining.DayArray.Day[SelectedTrainingDay].DayWorkoutArray.Length > 0)
        {
            //CurrentTraining.DayArray[SelectedTrainingDay].DayWorkoutArray.RemoveAt (SelectedTrainingWorkout);
            //CurrentTraining.DayArray[SelectedTrainingDay].RemoveAt (SelectedTrainingWorkout);
            CurrentTraining.DayArray.Day[SelectedTrainingDay].RemoveAt(SelectedTrainingWorkout);
            SelectedTrainingWorkout--;
			if(SelectedTrainingWorkout < 0) { SelectedTrainingWorkout = 0;}
			SelectedTrainingButtonIndex--;
			if(SelectedTrainingButtonIndex < 0) { SelectedTrainingButtonIndex = 0;}
			ClearTrainingScrollList ();
			PopulateTrainingScrollList ();
		}
	}

	public void EditWorkoutButtonPressed()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("EditTrainingWorkoutState");
	}
	
	public void FilterButtonPressed()
	{
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("FilterWorkoutState");
	}
	
	public void OkButtonPressed()
	{
		BackgroundTimer.Stop();
		// copy data from UI to User Blob
		int CurrentTrainingIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex;
		UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training[CurrentTrainingIndex] = CurrentTraining;
		
		// save data
		UserBlobManager.GetComponent<UserBlobManager> ().SaveTraining ();
		
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateTrainingState");
	}

	public void CancelButtonPressed()
	{
		BackgroundTimer.Stop();
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateTrainingState");
	}
	
	public void OnTrainingScrollBarChanged()
	{
		if (TrainingScrollBarMove == true && TrainingDayButtonArray.Count > 6)
		{
			int ButtonHeight = 100;
			double ButtonOffset = 2.6;
			int NumButtons = TrainingDayButtonArray.Count;
			float ScrollPercentage =  TrainingContentPanelScrollBar.GetComponent<Scrollbar>().value * (NumButtons - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			TrainingContentPanel.localPosition = tempPos;
		}
		TrainingScrollBarMove = true;
	}
	
	public void OnTrainingPanelValueChanged()
	{		
		TrainingScrollBarMove = false;
		if (TrainingDayButtonArray.Count > 6)
		{
			int ButtonHeight = 100;
			//			double ButtonOffset = 2.6;
			int NumButtons = TrainingDayButtonArray.Count; //CurrentTraining.DayArray.Count;
			float ScrollValue =  ((TrainingContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
			TrainingContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
		}
	}
	
	public void OnWorkoutScrollBarChanged()
	{
		if (WorkoutScrollBarMove == true && NumFilteredWorkouts > 6)
		{
			int ButtonHeight = 100;
			double ButtonOffset = 2.6;
			int NumButtons = NumFilteredWorkouts;
			float ScrollPercentage =  WorkoutContentPanelScrollBar.GetComponent<Scrollbar>().value * (NumButtons - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			WorkoutContentPanel.localPosition = tempPos;
		}
		WorkoutScrollBarMove = true;
	}
	
	public void OnWorkoutPanelValueChanged()
	{		
		WorkoutScrollBarMove = false;
		if (NumFilteredWorkouts > 6)
		{
			int ButtonHeight = 100;
			//			double ButtonOffset = 2.6;
			int NumButtons = NumFilteredWorkouts;
			float ScrollValue =  ((WorkoutContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
			WorkoutContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
		}
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		//myScrollPanel.transform.localPosition = tempPos;
		myScrollPanel.localPosition = tempPos;
	}
	
	public int FindWorkoutByName(string SearchText)
	{
		int foundIndex = -1;
		for (var i = 0; i < UserWorkoutData.Workout.Length; i++) 
		{
			if (UserWorkoutData.Workout[i].Name == SearchText)
			{
				foundIndex = i;
				return foundIndex;
			}
		}
		return foundIndex;
	}
}
