using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UI_Calendar : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject DayButtons;
	public GameObject MonthText;
	public List<GameObject> DayButtonArray = new List<GameObject>();
	public Sprite ButtonBackgroundNoWorkout = new Sprite();
	public Sprite ButtonBackgroundWorkout = new Sprite();
	public Sprite ButtonBackgroundWorkoutSomeCompleted = new Sprite();
	public Sprite ButtonBackgroundWorkoutCompleted = new Sprite();
	public Color ButtonTextColorNoWorkout = new Color();
	public Color ButtonTextColorWorkout = new Color();
	public Color ButtonTextColorWorkoutCompleted = new Color ();
	private System.DateTime CurrentDate = new System.DateTime(); 
	private System.DateTime TodaysDate = new System.DateTime(); 
	private string CurrentMonthString = "";
	private int AddMonths = 0;
	private int StartDay = 0;
	private int EndDay = 0;
	public System.DateTime SelectedDay = new System.DateTime();

	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
        CurrentDate = System.DateTime.Now;
        SelectedDay = CurrentDate;
    }

    // Use this for initialization
    void Start () 
	{
        CurrentDate = System.DateTime.Now;
        SelectedDay = CurrentDate;
	}

	public void Init()
	{
		Initialize = false;
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
			DayButtonArray[i-1].GetComponentInChildren<Text>().text = tempIndex.ToString();
			DayButtonArray[i-1].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
			DayButtonArray[i-1].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
			DayButtonArray[i-1].GetComponent<Button>().onClick.AddListener(() => DayButtonPressed(tempIndex));
		}

		UpdateCalendar ();
	}


	// Update is called once per frame
	void Update () 
	{
		if (Initialize) 
		{
			Init ();
		}
	}

	public void UpdateCalendar ()
	{
		
		CurrentDate = System.DateTime.Now.AddMonths(AddMonths);
		switch(CurrentDate.Month)
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
		
		switch(FirstDayOfMonth.DayOfWeek.ToString())
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
		for(int i = 0; i < 42; i++)
		{
			DayButtonArray[i].GetComponentInChildren<Text>().text = "";
			DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
			DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
			DayButtonArray[i].GetComponent<Button>().onClick.RemoveAllListeners();
		}

		// fill in days
		var count = 1;
		for(int i = StartDay; i < (StartDay + EndDay); i++ )
		{
			int tempIndex = i;
			DayButtonArray[i].GetComponentInChildren<Text>().text = count.ToString();
			DayButtonArray[i].GetComponentInChildren<Text>().color = ButtonTextColorNoWorkout;
			DayButtonArray[i].GetComponent<Image>().sprite = ButtonBackgroundNoWorkout;
			DayButtonArray[i].GetComponent<Button>().onClick.AddListener(() => DayButtonPressed(tempIndex+1-StartDay));



			System.DateTime CalendarDay = new System.DateTime(CurrentDate.Year, CurrentDate.Month, count);
			string DayWorkoutStatus = GetDayWorkoutData(CalendarDay);

			switch(DayWorkoutStatus)
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
			if(TodaysDate.Year == CurrentDate.Year && TodaysDate.Month == CurrentDate.Month && TodaysDate.Day == count )
			{
				DayButtonArray[i].GetComponentInChildren<Text>().color = Color.black;
			}

			count +=1;
		}
		MonthText.GetComponent<Text>().text = CurrentMonthString + " " + CurrentDate.Year.ToString();
	}

	public void NextMonthButtonPressed()
	{
		AddMonths++;
		UpdateCalendar ();
	}

	public void PrevMonthButtonPressed()
	{
		AddMonths--;
		UpdateCalendar ();
	}

	public void DayButtonPressed(int day)
	{
		SelectedDay = new System.DateTime (CurrentDate.Year, CurrentDate.Month, day);
		UIManager.GetComponent<UI_Manager>().SwitchStates("CalendarDayState");
	}

	public void AddDayData(DayData myDay)
	{
		UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.Add (myDay);
		UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.OrderBy(x => x.Day).ToArray();
	}

	public string GetDayWorkoutData(System.DateTime myDate)
	{
		string CurrentWorkoutStatus = "NoWorkout";
		for(int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++ )
		{
			if((myDate.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
			   (myDate.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month ) &&
			   (myDate.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
			{
//				int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Count;
				int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length;
				int NumCompletedWorkouts = 0;
				if(NumWorkouts > 0 )
				{
					CurrentWorkoutStatus = "Workout";
				}
				for(int WorkoutIndex = 0; WorkoutIndex < NumWorkouts; WorkoutIndex++)
				{
//					if(UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutCompleted == true)
					if(UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutCompleted == true)
					{
						NumCompletedWorkouts++;
					}
				}
				if(NumCompletedWorkouts > 0 && NumCompletedWorkouts < NumWorkouts)
				{
					CurrentWorkoutStatus = "WorkoutSomeCompleted";
				}
				if(NumCompletedWorkouts > 0 && NumWorkouts == NumCompletedWorkouts )
				{
					CurrentWorkoutStatus = "WorkoutCompleted";
				}
			}
		}
		return CurrentWorkoutStatus;
	}
}
