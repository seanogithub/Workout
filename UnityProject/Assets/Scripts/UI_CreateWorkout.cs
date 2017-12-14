using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_CreateWorkout : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject WorkoutButton;

    //	public List<ExerciseData> UserExerciseData = new List<ExerciseData>();	
    public SaveExerciseData UserExerciseData;
//	public List<WorkoutData> UserWorkoutData = new List<WorkoutData>();
	public SaveWorkoutData UserWorkoutData;

	public List<GameObject> WorkoutButtonArray = new List<GameObject>();

	public WorkoutData item = new WorkoutData();

	public Transform WorkoutContentPanel;
	public GameObject WorkoutContentPanelScrollBar;
	public bool WorkoutScrollBarMove = false;

	public int SelectedWorkout = -1;
	
	public Color SelectedColor = Color.red;

    public string PopUpYesNoDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		
	}
	
	// Use this for initialization
	void Start () 
	{
//		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserExerciseData = new SaveExerciseData ();
//		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
		UserWorkoutData = new SaveWorkoutData ();
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
		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
		SelectedWorkout = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;

        if(UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex > UserWorkoutData.Workout.Length)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = 0;
        }

        if(UserWorkoutData.Workout.Length == 0)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = -1;
        }
        if(UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex < 0 && UserWorkoutData.Workout.Length > 0)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = 0;
        }

        SelectedWorkout = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;
        int scrollIndex = SelectedWorkout;

        if (scrollIndex > UserWorkoutData.Workout.Length - 5)
        {
            scrollIndex = UserWorkoutData.Workout.Length - 5;
        }

        ClearScrollList();
		PopulateScrollList ();

		if(UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.Length > 5)
		{
			SetScrollRectPositionFromIntWithOffset (scrollIndex, 2.0, 200, UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.Length, WorkoutContentPanel);
		}
		else
		{
			WorkoutContentPanel.localPosition = new Vector3 (0, 0, 0);
		}
	}

	public void ClearScrollList()
	{
		for (int i = WorkoutContentPanel.childCount - 1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(WorkoutContentPanel.GetChild(i).gameObject);
		}
	}

	public void PopulateScrollList () 
	{
		WorkoutButtonArray.Clear ();
		foreach (var item in UserWorkoutData.Workout)
		{
			int TotalWorkoutTime = 0;
			for(int i = 0; i < item.ExerciseArray.Exercise.Length; i ++)
			{
				TotalWorkoutTime += item.ExerciseArray.Exercise[i].Time;
				TotalWorkoutTime += item.ExerciseArray.Exercise[i].RestTime;
				if(item.ExerciseArray.Exercise[i].CountDownAtStart)
				{
					TotalWorkoutTime += UserBlobManager.GetComponent<UserBlobManager> ().CountDownAtStartTimeLength;
				}
			}

			GameObject newButton = Instantiate (WorkoutButton) as GameObject;
			WorkoutButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
            newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
            newButton.transform.Find("Text_Time").GetComponent<Text>().text = ConvertSecondsToTimeHoursString(TotalWorkoutTime);
			string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => WorkoutButtonClicked(selectedButton));
			newButton.transform.SetParent (WorkoutContentPanel);
		}
		if(WorkoutButtonArray.Count > 0)
		{
			WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
		}
	}

	public void WorkoutButtonClicked(string myText)
	{
		WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = Color.white;
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindWorkoutByName (myText);
		UserBlobManager.GetComponent<UserBlobManager> ().CurrentWorkoutIndex = myIndex;
		SelectedWorkout = myIndex;
		WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
	}

	public void DeleteWorkout()
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().CurrentWorkoutIndex;
		if(myIndex < UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout.Length)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.RemoveAt(myIndex);
//			UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.TrimExcess();
			UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
			UserBlobManager.GetComponent<UserBlobManager> ().SaveWorkout();
			if(myIndex >= UserWorkoutData.Workout.Length)
			{
				myIndex = UserWorkoutData.Workout.Length - 1;
				UserBlobManager.GetComponent<UserBlobManager> ().CurrentWorkoutIndex = myIndex;
			}
			SelectedWorkout = myIndex;
			ClearScrollList ();
			PopulateScrollList ();
		}
	}

    public void OnDeleteButtonPressed()
    {
        if (SelectedWorkout >= 0)
        {
            if (PopUpActive == false)
            {
                PopUpYesNoDialog("Are you sure you want to delete this workout?", this.gameObject.GetComponent<UI_CreateWorkout>(), "DeleteWorkout");
            }
        }
    }

    public void AddToCalendarButtonPressed()
	{
		SelectedWorkout = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;
        if(SelectedWorkout >= 0)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("DayPickerWorkoutState");
        }
	}

    public void OnEditPressed()
    {
        SelectedWorkout = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;
        if (SelectedWorkout >= 0)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutState");
        }
    }

	public void OnWorkoutScrollBarChanged()
	{
		if (WorkoutScrollBarMove == true && UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout.Length > 5)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.0;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout.Length;
			float ScrollPercentage =  WorkoutContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout.Length - 5);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			WorkoutContentPanel.localPosition = tempPos;
		}
		WorkoutScrollBarMove = true;
	}
	
	public void OnWorkoutPanelValueChanged()
	{		
		WorkoutScrollBarMove = false;
		if (UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout.Length > 5)
		{
			int ButtonHeight = 200;
			//			double ButtonOffset = 2.6;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout.Length;
			float ScrollValue =  ((WorkoutContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 5) / 2)) / (NumButtons - 5) / ButtonHeight);
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

	public string ConvertSecondsToTimeHoursString(int mySeconds)
	{
		string SecondsString = ((int)(mySeconds % 60)).ToString();
		if (SecondsString.Length < 2) {SecondsString = "0" + SecondsString;}
		string MinuteString = ((int)(mySeconds / 60)).ToString();
		if (MinuteString.Length < 2) {MinuteString = "0" + MinuteString;}
		string HourString = ((int)(mySeconds / 3600)).ToString();
		//		if (HourString < 10) {HourString = "0" + MinuteString;}
		string TimeString = HourString + ":" + MinuteString + ":" + SecondsString;
		return TimeString;
	}

    void PopUpYesNoDialog(string myMessage, Component mySender, string myState)
    {
        var temp = Resources.Load("UI/UI_PopUpYesNoDialogBox_Prefab") as GameObject;
        var myPopUpYesNo = GameObject.Instantiate(temp, (new Vector3(0.0f, 0.0f, 1.0f)), Quaternion.identity) as GameObject;
        myPopUpYesNo.GetComponent<UI_PopUpYesNoDialogBox>().Sender = mySender;
        myPopUpYesNo.GetComponent<UI_PopUpYesNoDialogBox>().TextMessage.GetComponent<Text>().text = myMessage;
        myPopUpYesNo.SetActive(true);
        PopUpYesNoDialogState = myState;
        PopUpActive = true;
    }

    public void YesNoDialog(string DialogState)
    {
        switch (PopUpYesNoDialogState)
        {
            case "DeleteWorkout":
                if (DialogState == "ok")
                {
                    print("DeleteWorkout ok");
                    DeleteWorkout();
                }
                if (DialogState == "cancel")
                {
                    print("DeleteWorkout cancel");
                }
                break;
        }
        PopUpYesNoDialogState = "";
        PopUpActive = false;
    }
}
