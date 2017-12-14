using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UI_CalendarDay : MonoBehaviour {
	
	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject UICalendar;
	public GameObject DateText;
	public GameObject WorkoutButton;
    public GameObject StartWorkoutButton;
	public Sprite WorkoutButtonBackground;
	public Sprite WorkoutButtonCompletedBackground;
	public Color ButtonTextColorWorkout = new Color ();
	public Color ButtonTextColorWorkoutCompleted = new Color ();
	
	public SaveExerciseData UserExerciseData;
	public SaveWorkoutData UserWorkoutData;
	public SaveDayData UserDayData;

	public List<GameObject> WorkoutButtonArray = new List<GameObject>();
	
	public WorkoutData item = new WorkoutData();
	
	public Transform WorkoutContentPanel;
	public GameObject WorkoutContentPanelScrollBar;
	public bool WorkoutScrollBarMove = false;
	
	public int SelectedWorkout = 0;
	public int DayIndex = 0;
	public Color SelectedColor = Color.red;
	public System.DateTime CurrentDate = new System.DateTime();

    public string PopUpYesNoDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		UICalendar = GameObject.Find("UI_Calendar_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
//		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserExerciseData = new SaveExerciseData();
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
        CurrentDate = UICalendar.GetComponent<UI_Calendar> ().SelectedDay;
        StartWorkoutButton.SetActive(false);
        if (CurrentDate.Year == System.DateTime.Now.Year && CurrentDate.Month == System.DateTime.Now.Month && CurrentDate.Day == System.DateTime.Now.Day)
        {
            StartWorkoutButton.SetActive(true);
        }
        SelectedWorkout = 0;
		DayIndex = GetDayIndex (CurrentDate);
		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
		UserDayData = UserBlobManager.GetComponent<UserBlobManager>().UserDayData;
		string CurrentDateString = (MonthIntToString (CurrentDate.Month))+ " " + CurrentDate.Day.ToString()+ ", "+ CurrentDate.Year.ToString();
		DateText.GetComponent<Text> ().text = CurrentDateString;
		ClearScrollList ();
		PopulateScrollList ();

		if(UserDayData.Day[DayIndex].DayWorkoutArray.Length > 5)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.0, 200, UserDayData.Day[DayIndex].DayWorkoutArray.Length, WorkoutContentPanel);
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
		DayIndex = GetDayIndex (CurrentDate);

		for(int i = 0; i < UserDayData.Day[DayIndex].DayWorkoutArray.Length; i ++)
		{
			GameObject newButton = Instantiate (WorkoutButton) as GameObject;
			WorkoutButtonArray.Add(newButton);
			newButton.name = ("Button_" + UserDayData.Day[DayIndex].DayWorkoutArray[i].WorkoutName);
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = UserDayData.Day[DayIndex].DayWorkoutArray[i].WorkoutName;
			newButton.GetComponent<Image>().sprite = WorkoutButtonBackground;
			newButton.GetComponentInChildren<Text>().color = ButtonTextColorWorkout;
			string CompletedText = "";
			if(UserDayData.Day[DayIndex].DayWorkoutArray[i].WorkoutCompleted == true)
			{
				CompletedText = "Completed";
				newButton.GetComponent<Image>().sprite =WorkoutButtonCompletedBackground;
				newButton.GetComponentInChildren<Text>().color = ButtonTextColorWorkoutCompleted;
			}
			newButton.transform.Find("Text_Time").GetComponent<Text>().text = CompletedText;
			string selectedButton = UserDayData.Day[DayIndex].DayWorkoutArray[i].WorkoutName;
			int ButtonArrayIndex = i;
			newButton.GetComponent<Button>().onClick.AddListener(() => WorkoutButtonClicked(selectedButton, ButtonArrayIndex));
			newButton.transform.SetParent (WorkoutContentPanel);
		}

		if(WorkoutButtonArray.Count > 0)
		{
			WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void WorkoutButtonClicked(string myText, int ButtonArrayIndex)
	{
		WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = Color.white;
		// userblob workout index
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindWorkoutByName (myText);
		UserBlobManager.GetComponent<UserBlobManager> ().CurrentWorkoutIndex = myIndex;

		SelectedWorkout = ButtonArrayIndex;
		WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
	}

	public void StartWorkoutButtonPressed()
	{
		if(UserDayData.Day[DayIndex].DayWorkoutArray.Length > 0)
		{
			string myWorkoutName = UserDayData.Day[DayIndex].DayWorkoutArray [SelectedWorkout].WorkoutName;
			int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindWorkoutByName (myWorkoutName);
			UserBlobManager.GetComponent<UserBlobManager> ().CurrentWorkoutIndex = myIndex;
			UIManager.GetComponent<UI_Manager>().SwitchStates("WorkoutState");
		}
	}

	public void DeleteDayWorkout()
	{
		int myIndex = SelectedWorkout;
		if (UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.Day[DayIndex].DayWorkoutArray.Length > 0)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.Day[DayIndex].RemoveAt(myIndex);
//			UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.Day[DayIndex].DayWorkoutArray.TrimExcess();
		}

		// make sure myIndex is not greater than the number of entries in the list
		if(myIndex >= UserDayData.Day[DayIndex].DayWorkoutArray.Length)
		{
			myIndex = UserDayData.Day[DayIndex].DayWorkoutArray.Length - 1;
			if(myIndex < 0)
			{
				myIndex = 0;
			}
		}

		// remove day data if there are no workouts on that day
		if(UserDayData.Day[DayIndex].DayWorkoutArray.Length == 0)
		{
			// don't delete the first day entry
			if(DayIndex != 0)
			{
				UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.RemoveAt(DayIndex);
//				UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.TrimExcess();
				DayIndex = 0;
			}
		}

		UserDayData = UserBlobManager.GetComponent<UserBlobManager>().UserDayData;
		UserBlobManager.GetComponent<UserBlobManager> ().SaveDay();
		SelectedWorkout = myIndex;
		ClearScrollList ();
		PopulateScrollList ();
	}

    public void OnDeleteButtonPressed()
    {
        if (UserDayData.Day[DayIndex].DayWorkoutArray.Length > 0)
        {
            if (PopUpActive == false)
            {
                PopUpYesNoDialog("Are you sure you want to delete this workout?", this.gameObject.GetComponent<UI_CalendarDay>(), "DeleteDayWorkout");
            }
        }
    }

    public void OnWorkoutScrollBarChanged()
	{
		if (WorkoutScrollBarMove == true && UserDayData.Day[DayIndex].DayWorkoutArray.Length > 5)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.0;
			int NumButtons = UserDayData.Day[DayIndex].DayWorkoutArray.Length;
			float ScrollPercentage =  WorkoutContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserDayData.Day[DayIndex].DayWorkoutArray.Length - 5);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			WorkoutContentPanel.localPosition = tempPos;
		}
		WorkoutScrollBarMove = true;
	}
	
	public void OnWorkoutPanelValueChanged()
	{			
		WorkoutScrollBarMove = false;
		if (UserDayData.Day[DayIndex].DayWorkoutArray.Length > 5)
		{
			int ButtonHeight = 200;
			//			double ButtonOffset = 2.6;
			int NumButtons = UserDayData.Day[DayIndex].DayWorkoutArray.Length;
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

	public int GetDayIndex(System.DateTime myDate)
	{
		int tempDayIndex = 0;
		for(int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++ )
		{
			if((myDate.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
			   (myDate.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month ) &&
			   (myDate.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
			{
				tempDayIndex = index;
			}
		}
		return tempDayIndex;
	}

	public string MonthIntToString (int myMonth) 
	{
		string MonthString = "January";
		switch (myMonth) 
		{
		case 1:
			MonthString = "January";
			break;
		case 2:
			MonthString = "February";
			break;
		case 3:
			MonthString = "March";
			break;
		case 4:
			MonthString = "April";
			break;
		case 5:
			MonthString = "May";
			break;
		case 6:
			MonthString = "June";
			break;
		case 7:
			MonthString = "July";
			break;
		case 8:
			MonthString = "August";
			break;
		case 9:
			MonthString = "September";
			break;
		case 10:
			MonthString = "October";
			break;
		case 11:
			MonthString = "November";
			break;
		case 12:
			MonthString = "December";
			break;
		}
		return MonthString;
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
            case "DeleteDayWorkout":
                if (DialogState == "ok")
                {
                    print("DeleteDayWorkout ok");
                    DeleteDayWorkout();
                }
                if (DialogState == "cancel")
                {
                    print("DeleteDayWorkout cancel");
                }
                break;
        }
        PopUpYesNoDialogState = "";
        PopUpActive = false;
    }
}
