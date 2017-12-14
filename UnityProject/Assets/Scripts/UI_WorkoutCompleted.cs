using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class UI_WorkoutCompleted : MonoBehaviour 
{
	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject UIHome;
	public GameObject UICalendar;
    public GameObject UIWorkout;
	public GameObject WorkoutCompletedText;
	public GameObject NextWorkoutButton;

	public int CurrentWorkoutIndex;
	public string CurrentWorkoutName;

    public int WorkoutScore;

	public System.DateTime CurrentDate = new System.DateTime ();

	public AudioClip SoundWorkoutCompleted;

	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		UIHome = GameObject.Find("UI_Home_Prefab");
		UICalendar = GameObject.Find("UI_Calendar_Prefab");
        UIWorkout = GameObject.Find("UI_Workout_Prefab");
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
        WorkoutScore = UIWorkout.GetComponent<UI_Workout>().WorkoutScore;
        CurrentDate = System.DateTime.Now; //UICalendar.GetComponent<UI_Calendar> ().SelectedDay;
		GetComponent<AudioSource>().PlayOneShot(SoundWorkoutCompleted);
		CurrentWorkoutIndex = UserBlobManager.GetComponent<UserBlobManager> ().CurrentWorkoutIndex;
		CurrentWorkoutName = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].Name;
		WorkoutCompletedText.GetComponent<Text> ().text = ("Congradulations, " + CurrentWorkoutName + " Workout Completed" + "\n\n Workout Score = " + WorkoutScore);
		AddWorkoutToCalendar (CurrentDate);
        UploadWorkout(CurrentDate);
        GetNextWorkout (CurrentDate);
	}

	public void NextWorkoutButtonPressed()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("WorkoutState");
	}

	public void HomeButtonPressed()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("HomeState");
	}

	public void GetNextWorkout(System.DateTime myDate)
	{
		System.DateTime CalendarDayToday = new System.DateTime();
		CalendarDayToday = new System.DateTime(myDate.Year, myDate.Month, myDate.Day);
		string DayWorkoutStatus = GetDayWorkoutData(CalendarDayToday);
		
		switch(DayWorkoutStatus)
		{
		case "NoWorkout":
			NextWorkoutButton.SetActive(false);
			break;
		case "Workout":
			NextWorkoutButton.SetActive(true);
			string WorkoutName = GetFirstWorkoutNameForDay(CalendarDayToday);
			int WorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().FindWorkoutByName(WorkoutName);
			UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = WorkoutIndex;
			break;
		case "WorkoutSomeCompleted":
			NextWorkoutButton.SetActive(true);
			string WorkoutNameSome = GetFirstWorkoutNameForDay(CalendarDayToday);
			int WorkoutIndexSome = UserBlobManager.GetComponent<UserBlobManager>().FindWorkoutByName(WorkoutNameSome);
			UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = WorkoutIndexSome;
			break;
		case "WorkoutCompleted":
			NextWorkoutButton.SetActive(false);
			break;
		default:
			break;
		}
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
				int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length;
				int NumCompletedWorkouts = 0;
				if(NumWorkouts > 0 )
				{
					CurrentWorkoutStatus = "Workout";
				}
				for(int WorkoutIndex = 0; WorkoutIndex < NumWorkouts; WorkoutIndex++)
				{
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

	public string GetFirstWorkoutNameForDay(System.DateTime myDate)
	{
		string WorkoutName = "";
		for(int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++ )
		{
			if((myDate.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
			   (myDate.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month ) &&
			   (myDate.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
			{
				WorkoutName = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[0].WorkoutName;
				int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length;
				for(int WorkoutIndex = NumWorkouts - 1; WorkoutIndex >= 0; WorkoutIndex--)
				{
					if(UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutCompleted == false)
					{
						WorkoutName = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutName;
					}
				}
			}
		}
		return WorkoutName;
	}

	public void AddWorkoutToCalendar(System.DateTime myDate)
	{
		DayWorkoutData tempDayWorkoutData = new DayWorkoutData ();
		tempDayWorkoutData.WorkoutName = CurrentWorkoutName;
		tempDayWorkoutData.WorkoutCompleted = true;
		tempDayWorkoutData.CompletedDateTime = new System.DateTime(myDate.Year, myDate.Month, myDate.Day);
		tempDayWorkoutData.TotalWorkoutTime = 0;
		tempDayWorkoutData.TotalWorkoutWeight = 0;
        tempDayWorkoutData.WorkoutScore = WorkoutScore;

        // need to find the day first, and if it exists add the data
        System.DateTime Today = new System.DateTime(myDate.Year, myDate.Month, myDate.Day);
		int DayIndex = -1;
		int NameIndex = -1;
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
                        if (UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutNameIndex].WorkoutCompleted == false)
                        {
                            NameIndex = WorkoutNameIndex;
                        }
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
            if (NameIndex < 0)
			{
				//new workout
				UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].Add(tempDayWorkoutData);
				UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
			}
			else
			{
                // workout already exists, change completed bool and time
                UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].DayWorkoutArray[NameIndex].CompletedDateTime = Today;
                UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].DayWorkoutArray[NameIndex].WorkoutCompleted = true;
                UserBlobManager.GetComponent<UserBlobManager>().SaveDay();
            }
		}
	}


    public void AddWorkoutToDayData(SaveDayData myDayData, System.DateTime myDate)
    {
        DayWorkoutData tempDayWorkoutData = new DayWorkoutData();
        tempDayWorkoutData.WorkoutName = CurrentWorkoutName;
        tempDayWorkoutData.WorkoutCompleted = true;
        tempDayWorkoutData.CompletedDateTime = new System.DateTime(myDate.Year, myDate.Month, myDate.Day);
        tempDayWorkoutData.TotalWorkoutTime = 0;
        tempDayWorkoutData.TotalWorkoutWeight = 0;
        tempDayWorkoutData.WorkoutScore = WorkoutScore;

        // need to find the day first, and if it exists add the data
        System.DateTime Today = new System.DateTime(myDate.Year, myDate.Month, myDate.Day);
        int DayIndex = -1;
        int NameIndex = -1;
        for (int index = 0; index < myDayData.Day.Length; index++)
        {
            if ((Today.Year == myDayData.Day[index].Day.Year) &&
               (Today.Month == myDayData.Day[index].Day.Month) &&
               (Today.Day == myDayData.Day[index].Day.Day))
            {
                DayIndex = index;
                for (int WorkoutNameIndex = 0; WorkoutNameIndex < myDayData.Day[index].DayWorkoutArray.Length; WorkoutNameIndex++)
                {
                    if (CurrentWorkoutName == myDayData.Day[index].DayWorkoutArray[WorkoutNameIndex].WorkoutName)
                    {
                        if (myDayData.Day[index].DayWorkoutArray[WorkoutNameIndex].WorkoutCompleted == false)
                        {
                            NameIndex = WorkoutNameIndex;
                        }
                    }
                }
            }
        }

        if (DayIndex < 0)
        {
            // add new day
            DayData tempDayData = new DayData();
            tempDayData.Day = Today;
            tempDayData.Add(tempDayWorkoutData);
            myDayData.Add(tempDayData);
            myDayData.Day = myDayData.Day.OrderBy(x => x.Day).ToArray();
            UserBlobManager.GetComponent<UserBlobManager>().SaveDay();
        }
        else
        {
            if (NameIndex < 0)
            {
                //new workout
                myDayData.Day[DayIndex].Add(tempDayWorkoutData);
            }
            else
            {
                // workout already exists, change completed bool and time
                myDayData.Day[DayIndex].DayWorkoutArray[NameIndex].CompletedDateTime = Today;
                myDayData.Day[DayIndex].DayWorkoutArray[NameIndex].WorkoutCompleted = true;
            }
        }
    }

    public void UploadWorkout(System.DateTime myDate)
    {
        if(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin != "" && UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserPassword != "")
        {
            // create the data for the current workout
            DayWorkoutData tempDayWorkoutData = new DayWorkoutData();
            tempDayWorkoutData.WorkoutName = CurrentWorkoutName;
            tempDayWorkoutData.WorkoutCompleted = true;
            tempDayWorkoutData.CompletedDateTime = new System.DateTime(myDate.Year, myDate.Month, myDate.Day);
            tempDayWorkoutData.TotalWorkoutTime = 0;
            tempDayWorkoutData.TotalWorkoutWeight = 0;
            tempDayWorkoutData.WorkoutScore = WorkoutScore;
            StartCoroutine( UploadWorkoutCompleteFile(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin, tempDayWorkoutData, myDate));
        }
    }

    IEnumerator UploadWorkoutCompleteFile(string ScreenName, DayWorkoutData CompletedWorkout, System.DateTime myDate)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "get_workout_complete_data";

        WWWForm form = new WWWForm();
        form.AddField("action", Action);
        form.AddField("myform_screenname", ScreenName);
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;
        formText = w.text.ToString();
        print(formText);

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            if (formText.Contains("HASH code is different from your app"))
            {
                print("Can't connect");
            }
            else
            {
                if (!formText.Contains("Cant Find Workout Complete Data") && formText != "\r\n")
                {
                    // merge file
                    print("Merge Upload File");
                    StartCoroutine(MergeDayFile(ScreenName, formText, myDate));
                }
                else
                {
                    // serialize
                    SaveDayData UserDayData = new SaveDayData();
                    AddWorkoutToDayData(UserDayData, myDate);

                    string Data = SerializeObject(UserDayData, "SaveDayData");
                    int index = Data.IndexOf(System.Environment.NewLine);
                    Data = Data.Substring(index + System.Environment.NewLine.Length);
                    // upload file
                    print("Upload File");
                    StartCoroutine(UploadFile(ScreenName, Data));
                }
            }
        }
        w.Dispose();
    }

    IEnumerator MergeDayFile(string ScreenName, string DownloadString, System.DateTime myDate)
    {
        // remove old data
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "remove_workout_complete_data";

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", Action);
        form.AddField("myform_screenname", ScreenName);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            // deserialize the downloaded day data
            SaveDayData tempDayData = new SaveDayData();
            tempDayData = (SaveDayData)DeserializeObject(DownloadString, "SaveDayData");

            // check for workouts that are more than a week old?
            RemoveOldCompleteWorkouts(tempDayData);

            // add the workout to the day data
            AddWorkoutToDayData(tempDayData, myDate);

            // upload file
            string Data = SerializeObject(tempDayData, "SaveDayData");
            int index = Data.IndexOf(System.Environment.NewLine);
            Data = Data.Substring(index + System.Environment.NewLine.Length);
            StartCoroutine(UploadFile(ScreenName, Data));
        }
        w.Dispose();
    }

    IEnumerator UploadFile(string ScreenName, string Data)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "set_workout_complete_data";
        string date = System.DateTime.Now.Year.ToString("D4");
        date += System.DateTime.Now.Month.ToString("D2");
        date += System.DateTime.Now.Day.ToString("D2");

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", Action);
        form.AddField("myform_screenname", ScreenName);
        form.AddField("myform_xml", Data);
        form.AddField("myform_date", date);

        WWW w = new WWW(URL, form);
        yield return w;

        formText = w.text.ToString();
        //print(formText);

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            if (formText.Contains("HASH code is different from your app"))
            {
                print("File failed to upload");
            }
            else
            {
                print("Completed Workout File Uploaded" );
            }
        }
        w.Dispose();
    }

    public void RemoveOldCompleteWorkouts(SaveDayData UserDayData)
    {
        System.DateTime Today = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
        //System.DateTime Today = new System.DateTime(2016, 2, 9);
        System.DateTime PrevSunday = Today.AddDays(-1 *(int)Today.DayOfWeek);
        for (int i = 0; i < UserDayData.Day.Length; i++)
        {
            System.DateTime CurrentUserDay = new System.DateTime(UserDayData.Day[i].Day.Year, UserDayData.Day[i].Day.Month, UserDayData.Day[i].Day.Day);
            CurrentUserDay = CurrentUserDay.AddDays(-1 *  (int)CurrentUserDay.DayOfWeek);
            int result = System.DateTime.Compare(PrevSunday, CurrentUserDay);

            if (result > 0)
            {
                print("old day");
                UserDayData.RemoveAt(i);
            }
        }
    }

    /* The following metods came from the referenced URL */
    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }

    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }

    string SerializeObject(object pObject, string myType)
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();
        // type of need to be the type of data we are saving
        XmlSerializer xs = new XmlSerializer(typeof(SaveWorkoutData));
        switch (myType)
        {
            case "SaveDownloadTrainingData":
                xs = new XmlSerializer(typeof(SaveDownloadTrainingData));
                break;
            case "SaveDownloadWorkoutData":
                xs = new XmlSerializer(typeof(SaveDownloadWorkoutData));
                break;
            case "SaveDownloadExerciseData":
                xs = new XmlSerializer(typeof(SaveDownloadExerciseData));
                break;
            case "SaveTrainingData":
                xs = new XmlSerializer(typeof(SaveTrainingData));
                break;
            case "SaveWorkoutData":
                xs = new XmlSerializer(typeof(SaveWorkoutData));
                break;
            case "SaveExerciseData":
                xs = new XmlSerializer(typeof(SaveExerciseData));
                break;
            case "SaveDayData":
                xs = new XmlSerializer(typeof(SaveDayData));
                break;
            case "SaveSettingsData":
                xs = new XmlSerializer(typeof(SaveSettingsData));
                break;
            case "SaveFriendData":
                xs = new XmlSerializer(typeof(SaveFriendData));
                break;
        }

        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xmlTextWriter.Settings.Indent = true;
        xmlTextWriter.Formatting = Formatting.Indented;
        xs.Serialize(xmlTextWriter, pObject);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
        return XmlizedString;
    }


    // Here we deserialize it back into its original form 
    object DeserializeObject(string pXmlizedString, string myType)
    {
        // type of need to be the type of data we are saving
        //		XmlSerializer xs = new XmlSerializer(typeof(MapBuildable[])); 
        XmlSerializer xs = new XmlSerializer(typeof(SaveData));
        switch (myType)
        {
            case "SaveDownloadTrainingData":
                xs = new XmlSerializer(typeof(SaveDownloadTrainingData));
                break;
            case "SaveDownloadWorkoutData":
                xs = new XmlSerializer(typeof(SaveDownloadWorkoutData));
                break;
            case "SaveDownloadExerciseData":
                xs = new XmlSerializer(typeof(SaveDownloadExerciseData));
                break;
            case "SaveData":
                xs = new XmlSerializer(typeof(SaveData));
                break;
            case "SaveTrainingData":
                xs = new XmlSerializer(typeof(SaveTrainingData));
                break;
            case "SaveWorkoutData":
                xs = new XmlSerializer(typeof(SaveWorkoutData));
                break;
            case "SaveExerciseData":
                xs = new XmlSerializer(typeof(SaveExerciseData));
                break;
            case "SaveDayData":
                xs = new XmlSerializer(typeof(SaveDayData));
                break;
            case "SaveSettingsData":
                xs = new XmlSerializer(typeof(SaveSettingsData));
                break;
            case "SaveFriendData":
                xs = new XmlSerializer(typeof(SaveFriendData));
                break;
        }
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        return xs.Deserialize(memoryStream);
    }
}
