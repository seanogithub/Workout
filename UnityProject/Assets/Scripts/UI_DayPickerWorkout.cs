using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UI_DayPickerWorkout : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject UICreateWorkout;
	
	private string CurrentMonth = "January";
	private int CurrentDay = 0;
	private int CurrentYear = 0;
	int CurrentMonthIndex = System.DateTime.Now.Month;

    public GameObject DayButtons;
    public GameObject MonthText;
    public List<GameObject> DayButtonArray = new List<GameObject>();
    public Sprite ButtonBackgroundNoWorkout = new Sprite();
    public Sprite ButtonBackgroundWorkout = new Sprite();
    public Sprite ButtonBackgroundWorkoutSomeCompleted = new Sprite();
    public Sprite ButtonBackgroundWorkoutCompleted = new Sprite();
    public Color ButtonTextColorNoWorkout = new Color();
    public Color ButtonTextColorWorkout = new Color();
    public Color ButtonTextColorWorkoutCompleted = new Color();
    public Color ButtonSelectedColor = new Color();
    private System.DateTime CurrentDate = new System.DateTime();
    private System.DateTime TodaysDate = new System.DateTime();
    private string CurrentMonthString = "";
    public int AddMonths = 0;
    public int StartDay = 0;
    public int EndDay = 0;
    public System.DateTime SelectedDay = new System.DateTime();
    public int PreviousSelectedDayIndex = -1;
    public bool Done = false;

    public string PopUpYesNoDialogState = "";
    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		UICreateWorkout = GameObject.Find("UI_CreateWorkout_Prefab");
        CurrentDate = System.DateTime.Now;
    }
	// Use this for initialization
	void Start () 
	{
        CurrentDate = System.DateTime.Now;
        SelectedDay = CurrentDate;

        CurrentMonthIndex = System.DateTime.Now.Month;
		CurrentMonth = MonthIntToString (CurrentMonthIndex);
		CurrentDay = System.DateTime.Now.Day;
		CurrentYear = System.DateTime.Now.Year;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Initialize) 
		{
			Init ();
		}

        if (Done == true)
        {
            if (PreviousSelectedDayIndex > 0)
            {
                DayButtonArray[PreviousSelectedDayIndex].GetComponent<Image>().color = Color.white;
            }
            UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
        }
    }
	public void Init()
	{
        Initialize = false;
        Done = false;
        PreviousSelectedDayIndex = -1;
        TodaysDate = System.DateTime.Now;
        // create day buttons
        for (int i = 1; i <= 42; i++)
        {
            string tempString = "Button_Day";
            if (i < 10)
            {
                tempString += "0" + i.ToString();
            }
            else
            {
                tempString += i.ToString();
            }
            // add buttons to array
            int tempIndex = i;
            DayButtonArray.Add(GameObject.Find(tempString));
            DayButtonArray[i - 1].GetComponentInChildren<Text>().text = tempIndex.ToString();
            DayButtonArray[i - 1].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
            DayButtonArray[i - 1].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
            DayButtonArray[i - 1].GetComponent<Button>().onClick.AddListener(() => DayButtonPressed(tempIndex));
        }

        CurrentMonthIndex = System.DateTime.Now.Month;
        CurrentMonth = MonthIntToString(CurrentMonthIndex);
        CurrentDay = System.DateTime.Now.Day;
        CurrentYear = System.DateTime.Now.Year;

        UpdateCalendar();
    }


    public void UpdateCalendar()
    {

        CurrentDate = System.DateTime.Now.AddMonths(AddMonths);
        switch (CurrentDate.Month)
        {
            case 1:
                CurrentMonthString = "January";
                break;
            case 2:
                CurrentMonthString = "February";
                break;
            case 3:
                CurrentMonthString = "March";
                break;
            case 4:
                CurrentMonthString = "April";
                break;
            case 5:
                CurrentMonthString = "May";
                break;
            case 6:
                CurrentMonthString = "June";
                break;
            case 7:
                CurrentMonthString = "July";
                break;
            case 8:
                CurrentMonthString = "August";
                break;
            case 9:
                CurrentMonthString = "September";
                break;
            case 10:
                CurrentMonthString = "October";
                break;
            case 11:
                CurrentMonthString = "November";
                break;
            case 12:
                CurrentMonthString = "December";
                break;

        }

        int delta = Convert.ToInt32(CurrentDate.Day);
        System.DateTime FirstDayOfMonth = CurrentDate.AddDays(-delta + 1);
        //		print (CurrentDate);

        StartDay = 0;

        switch (FirstDayOfMonth.DayOfWeek.ToString())
        {
            case "Sunday":
                StartDay = 0;
                break;
            case "Monday":
                StartDay = 1;
                break;
            case "Tuesday":
                StartDay = 2;
                break;
            case "Wednesday":
                StartDay = 3;
                break;
            case "Thursday":
                StartDay = 4;
                break;
            case "Friday":
                StartDay = 5;
                break;
            case "Saturday":
                StartDay = 6;
                break;
        }

        EndDay = System.DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month);

        // clear days in calendar
        for (int i = 0; i < 42; i++)
        {
            DayButtonArray[i].GetComponentInChildren<Text>().text = "";
            DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
            DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
            DayButtonArray[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }

        // fill in days
        var count = 1;
        for (int i = StartDay; i < (StartDay + EndDay); i++)
        {
            int tempIndex = i;
            DayButtonArray[i].GetComponentInChildren<Text>().text = count.ToString();
            DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
            DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
            DayButtonArray[i].GetComponent<Button>().onClick.AddListener(() => DayButtonPressed(tempIndex + 1 - StartDay));



            System.DateTime CalendarDay = new System.DateTime(CurrentDate.Year, CurrentDate.Month, count);
            string DayWorkoutStatus = GetDayWorkoutData(CalendarDay);

            switch (DayWorkoutStatus)
            {
                case "NoWorkout":
                    DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
                    DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
                    break;
                case "Workout":
                    DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorWorkout;
                    DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundWorkout;
                    break;
                case "WorkoutSomeCompleted":
                    DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorWorkoutCompleted;
                    DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundWorkoutSomeCompleted;
                    break;
                case "WorkoutCompleted":
                    DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorWorkoutCompleted;
                    DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundWorkoutCompleted;
                    break;
                default:
                    DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
                    DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
                    break;
            }

            // make todays text white
            if (TodaysDate.Year == CurrentDate.Year && TodaysDate.Month == CurrentDate.Month && TodaysDate.Day == count)
            {
                DayButtonArray[i].GetComponentInChildren<Text>().color = Color.black;
            }

            count += 1;
        }
        MonthText.GetComponent<Text>().text = CurrentMonthString + " " + CurrentDate.Year.ToString();
    }

    public void NextMonthButtonPressed()
    {
        if (PreviousSelectedDayIndex > 0)
        {
            DayButtonArray[PreviousSelectedDayIndex].GetComponent<Image>().color = Color.white;
        }
        PreviousSelectedDayIndex = -1;
        AddMonths++;
        UpdateCalendar();
    }

    public void PrevMonthButtonPressed()
    {
        if (PreviousSelectedDayIndex > 0)
        {
            DayButtonArray[PreviousSelectedDayIndex].GetComponent<Image>().color = Color.white;
        }
        PreviousSelectedDayIndex = -1;
        AddMonths--;
        UpdateCalendar();
    }

    public void DayButtonPressed(int day)
    {
        if (PreviousSelectedDayIndex > 0)
        {
            DayButtonArray[PreviousSelectedDayIndex].GetComponent<Image>().color = Color.white;
        }
        SelectedDay = new System.DateTime(CurrentDate.Year, CurrentDate.Month, day);
        PreviousSelectedDayIndex = day - 1 + StartDay;
        DayButtonArray[PreviousSelectedDayIndex].GetComponent<Image>().color = ButtonSelectedColor;
    }

    private bool ValidateDate(int myMonth, int myDay, int myYear)
	{
		bool Valid = false;
		try
		{
			System.DateTime ValidDate = new System.DateTime (myYear, myMonth, myDay);
			ValidDate.AddDays(0);
			Valid = true;
		}
		catch
		{
			Valid = false;
		}
		return Valid;
	}
	
	public void OnOkPressed()
	{
        if (PreviousSelectedDayIndex > 0)
        {
            CurrentMonthIndex = SelectedDay.Month;
            CurrentDay = SelectedDay.Day;
            CurrentYear = SelectedDay.Year;
            bool Valid = ValidateDate(CurrentMonthIndex, CurrentDay, CurrentYear);
            if (Valid == true)
            {
                AddToCalendar();
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Workout sucessfully added to calendar", this.gameObject.GetComponent<UI_DayPickerWorkout>(), "GoodDay");
                }
            }
            else
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Please pick a day", this.gameObject.GetComponent<UI_DayPickerWorkout>(), "BadDay");
                }
            }
        }
        else
        {
            if (PopUpActive == false)
            {
                PopUpOkDialog("Please pick a day", this.gameObject.GetComponent<UI_DayPickerWorkout>(), "BadDay");
            }
        }
    }

    public void OnCancelPressed()
    {
        Done = true;
    }

    public string GetDayWorkoutData(System.DateTime myDate)
    {
        string CurrentWorkoutStatus = "NoWorkout";
        for (int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++)
        {
            if ((myDate.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
               (myDate.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month) &&
               (myDate.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
            {
                //				int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Count;
                int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length;
                int NumCompletedWorkouts = 0;
                if (NumWorkouts > 0)
                {
                    CurrentWorkoutStatus = "Workout";
                }
                for (int WorkoutIndex = 0; WorkoutIndex < NumWorkouts; WorkoutIndex++)
                {
                    //					if(UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutCompleted == true)
                    if (UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutCompleted == true)
                    {
                        NumCompletedWorkouts++;
                    }
                }
                if (NumCompletedWorkouts > 0 && NumCompletedWorkouts < NumWorkouts)
                {
                    CurrentWorkoutStatus = "WorkoutSomeCompleted";
                }
                if (NumCompletedWorkouts > 0 && NumWorkouts == NumCompletedWorkouts)
                {
                    CurrentWorkoutStatus = "WorkoutCompleted";
                }
            }
        }
        return CurrentWorkoutStatus;
    }

    public void AddToCalendar()
	{
		int SelectedWorkout = UICreateWorkout.GetComponent<UI_CreateWorkout> ().SelectedWorkout;

		string addWorkoutName = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[SelectedWorkout].Name;
		System.DateTime addWorkoutDay = new System.DateTime(CurrentYear,CurrentMonthIndex,CurrentDay);
		AddWorkoutToCalendar(addWorkoutName, addWorkoutDay);

		UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.OrderBy(x => x.Day).ToArray();
		UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
	}
	
	public void AddWorkoutToCalendar(string CurrentWorkoutName, System.DateTime Today)
	{
		DayWorkoutData tempDayWorkoutData = new DayWorkoutData ();
		tempDayWorkoutData.WorkoutName = CurrentWorkoutName;
		tempDayWorkoutData.WorkoutCompleted = false;
		tempDayWorkoutData.CompletedDateTime = System.DateTime.Now;
		tempDayWorkoutData.TotalWorkoutTime = 0;
		tempDayWorkoutData.TotalWorkoutWeight = 0;
		
		int DayIndex = -1;
		//int NameIndex = -1;
		for(int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++ )
		{
			if((Today.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
			   (Today.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month ) &&
			   (Today.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
			{
				DayIndex = index;
				for(int WorkoutNameIndex = 0; WorkoutNameIndex < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length; WorkoutNameIndex++)
				{
					if(CurrentWorkoutName == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutNameIndex].WorkoutName)
					{
						//NameIndex = WorkoutNameIndex;
					}
				}
			}
		}
		
		if (DayIndex < 0)
		{
			// add new day
			DayData tempDayData = new DayData ();
			tempDayData.Day = Today;
			tempDayData.Add (tempDayWorkoutData);
			UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.Add (tempDayData);
			UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.OrderBy(x => x.Day).ToArray();
			UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
		}
		else
		{
            UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].Add(tempDayWorkoutData);
            UserBlobManager.GetComponent<UserBlobManager>().SaveDay();
            /*
            if (NameIndex < 0)
			{
				//new workout
                //UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].DayWorkoutArray.Add(tempDayWorkoutData);
				UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].Add(tempDayWorkoutData);
				UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
			}
			else
			{
				// workout already exists, change completed bool and time
				//UserBlobManager.GetComponent<UserBlobManager>().UserDayData[DayIndex].DayWorkoutArray[NameIndex].CompletedDateTime = Today;
				//UserBlobManager.GetComponent<UserBlobManager>().UserDayData[DayIndex].DayWorkoutArray[NameIndex].WorkoutCompleted = false;
				UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
			}
            */
		}
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
	
	public int MonthStringToInt (string myMonth) 
	{
		int MonthInt = 0;
		switch (myMonth) 
		{
		case "January":
			MonthInt = 1;
			break;
		case "February":
			MonthInt = 2;
			break;
		case "March":
			MonthInt = 3;
			break;
		case "April":
			MonthInt = 4;
			break;
		case "May":
			MonthInt = 5;
			break;
		case "June":
			MonthInt = 6;
			break;
		case "July":
			MonthInt = 7;
			break;
		case "August":
			MonthInt = 8;
			break;
		case "September":
			MonthInt = 9;
			break;
		case "October":
			MonthInt = 10;
			break;
		case "November":
			MonthInt = 11;
			break;
		case "December":
			MonthInt = 12;
			break;
		}
		return MonthInt;
	}

    void PopUpOkDialog(string myMessage, Component mySender, string myState)
    {
        var temp = Resources.Load("UI/UI_PopUpOkDialogBox_Prefab") as GameObject;
        var myPopUpOK = GameObject.Instantiate(temp, (new Vector3(0.0f, 0.0f, 1.0f)), Quaternion.identity) as GameObject;
        myPopUpOK.GetComponent<UI_PopUpOkDialogBox>().Sender = mySender;
        myPopUpOK.GetComponent<UI_PopUpOkDialogBox>().TextMessage.GetComponent<Text>().text = myMessage;
        myPopUpOK.SetActive(true);
        PopUpOkDialogState = myState;
        PopUpActive = true;
    }

    public void OkDialog(string DialogState)
    {
        switch (PopUpOkDialogState)
        {
            case "BadDay":
                if (DialogState == "ok")
                {
                    print("Bad Day");
                }
                break;
            case "GoodDay":
                if (DialogState == "ok")
                {
                    print("Good Day");
                    Done = true;
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }
}
