using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;

public class UI_ShareWorkout : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIUploading;
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
	public List<string> ShareWorkoutList = new List<string> ();
    public List<WorkoutData> ShareWorkoutData = new List<WorkoutData>();

    public Color SelectedColor = Color.red;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
//		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserExerciseData = new SaveExerciseData();
		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
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
		ShareWorkoutList  = new List<string> (); 
		ShareWorkoutData = new List<WorkoutData>();
		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
//		SelectedWorkout = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;
		ClearScrollList ();
		PopulateScrollList ();
		if(UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.Length > 5)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.0, 200, UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.Length, WorkoutContentPanel);
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
			newButton.transform.Find("Text_Time").GetComponent<Text>().text = ConvertSecondsToTimeHoursString(TotalWorkoutTime);
			string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => WorkoutButtonClicked(selectedButton));
			newButton.transform.SetParent (WorkoutContentPanel);
		}
//		WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void WorkoutButtonClicked(string myText)
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindWorkoutByName (myText);
		SelectedWorkout = myIndex;
		
		bool sel = false;
		foreach (var item in ShareWorkoutList) 
		{
			if (item == myText)
			{
				sel = true;
			}
		}
		if (sel) 
		{
			// remove from list
			ShareWorkoutList.Remove(myText);
			WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = Color.white;
		}
		else
		{
			ShareWorkoutList.Add(myText);
			WorkoutButtonArray[SelectedWorkout].GetComponent<Image> ().color = SelectedColor;
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

	public void OnShareButtonPressed ()
	{
		if(ShareWorkoutList.Count > 0)
		{
			//build shared exercise data
			for(int i = 0; i < ShareWorkoutList.Count; i++)
			{
				WorkoutData tempWorkout = new WorkoutData();
				int WorkoutIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindWorkoutByName(ShareWorkoutList[i]);
				tempWorkout = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[WorkoutIndex];
				ShareWorkoutData.Add(tempWorkout);
			}
            UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData = new List<TrainingData>();
            UserBlobManager.GetComponent<UserBlobManager> ().ShareWorkoutData = ShareWorkoutData;
            UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData = new List<ExerciseData>();

            UIManager.GetComponent<UI_Manager>().SwitchStates("ShareFriendListState");
		}
		else 
		{
		}
	}

    public void OnShareEveryoneButtonPressed()
    {
        if (ShareWorkoutList.Count > 0)
        {
            //build shared Workout data
            for (int i = 0; i < ShareWorkoutList.Count; i++)
            {
                WorkoutData tempWorkout = new WorkoutData();
                int WorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().FindWorkoutByName(ShareWorkoutList[i]);
                tempWorkout = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout[WorkoutIndex];
                ShareWorkoutData.Add(tempWorkout);
            }
            UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData = new List<TrainingData>();
            UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData = ShareWorkoutData;
            UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData = new List<ExerciseData>();
            //UploadWorkout();
            //UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
            UIUploading.GetComponent<UI_Uploading>().FriendList = new List<string>();
            UIManager.GetComponent<UI_Manager>().SwitchStates("UploadingState");
        }
        else
        {
        }
    }
    /*
    public void UploadWorkout()
    {
        // serialize
        SaveWorkoutData UserWorkoutData = new SaveWorkoutData();
        for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData.Count; i++)
        {
            UserWorkoutData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData[i]);
        }

        string Data = SerializeObject(UserWorkoutData, "SaveWorkoutData");
        string FileName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + ".xml";

        StartCoroutine(UploadFile(FileName, Data, "share_workout"));
    }

    IEnumerator UploadFile(string FileName, string Data, string FileType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        byte[] bytes = Encoding.UTF8.GetBytes(Data);
        print(Data);

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", FileType);
        form.AddBinaryData("fileUpload", bytes, FileName, "text/xml");

        WWW w = new WWW(URL, form);
        yield return w;
        print(w.error);
        print(w.text);

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            if (formText.Contains("HASH code is different from your app"))
            {
                print("File failed to upload.");
            }
            else
            {
                print(w.text);
                print("success !");
            }
        }
        w.Dispose();
    }

    // The following metods came from the referenced URL 
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
    */
}
