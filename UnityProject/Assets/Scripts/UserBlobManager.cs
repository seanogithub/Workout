using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text;
using System.Linq;

public class UserBlobManager : MonoBehaviour
{
    public string VersionNumber = "";
    public SaveDownloadTrainingData UserDownloadTrainingData;
    public SaveDownloadWorkoutData UserDownloadWorkoutData;
    public SaveDownloadExerciseData UserDownloadExerciseData;

    public string UserDownloadTrainingDataString;
    public string UserDownloadWorkoutDataString;
    public string UserDownloadExerciseDataString;
    public SaveTrainingData UserTrainingData; 
	public SaveWorkoutData UserWorkoutData;
	public SaveExerciseData UserExerciseData;
	public SaveDayData UserDayData;
	public SettingsData UserSettingsData = new SettingsData();
	public SaveFriendData UserFriendData;

	public List<TrainingData> ShareTrainingData = new List<TrainingData> ();
	public List<WorkoutData> ShareWorkoutData = new List<WorkoutData>();
	public List<ExerciseData> ShareExerciseData = new List<ExerciseData>();


	public GameObject UIManager;

	public System.DateTime CurrentTime = new System.DateTime(); 
	public string CurrentTimeString = "";	

	public SaveData myData = new SaveData();
	public SaveSettingsData mySettingsData = new SaveSettingsData();

	public int CurrentTrainingIndex = -1;
	public int CurrentWorkoutIndex = -1;
	public int CurrentExerciseIndex = -1;
	public int CurrentFriendIndex = 0;
		
	public List<string> ShareFriendList = new List<string> ();

	public string ExerciseFilterType = "None";
	public string ExerciseFilterBodyPart = "None";
	
	public int CountDownAtStartTimeLength = 10;

	Rect _Save, _Load, _SaveMSG, _LoadMSG; 
	bool _ShouldSave, _ShouldLoad,_SwitchSave,_SwitchLoad; 
	string _FileLocation,_FileName, _DownloadTrainingDataFileName, _DownloadWorkoutDataFileName, _DownloadExerciseDataFileName,_TrainingDataFileName, _WorkoutDataFileName,_ExerciseDataFileName,_DayDataFileName,_SettingsDataFileName,_FriendDataFileName; 	 	
	string _data; 	
		
	public List<string> ExerciseTypeList = new List<string>();
    public List<string> WorkoutTypeList = new List<string>();
    public List<string> TrainingTypeList = new List<string>();
    public List<string> BodyPartList = new List<string>();
	public List<string> BodySide = new List<string>();
	public List<string> FilterExerciseTypeList = new List<string>();
	public List<string> FilterBodyPartList = new List<string>();
	public List<int> NumberList = new List<int>();
	public List<int> NumberListToFive = new List<int>();
	public List<string> YesNoList = new List<string>();
	public List<string> MonthList = new List<string>();

    //public string ServerURL = "http://www.blankcartridge.com/UW/";
    public string ServerURL = "http://ultimateworkoutapp.com/UW/";
    //public string ServerHash = "d4bd418a38282a6c1a7c1801536eba97faed654a0c48f4603ae744e71ddecb2e5139c3c7e256afaf6f8a816745bc8a8010e6f566846647ad6f572a07368f93de";
    public string ServerHash = "Qt90nU71kTCxout12TeHyfWXV2eh4NgLhBOpDyULIrTPhgIvJxazmQSZftBGlVV17sTchofJsITnrpkyS854VW4V16";

    // Use this for initialization
    void Awake () 
	{
        VersionNumber = "1.0";

        ExerciseTypeList.Clear ();
		ExerciseTypeList.Add("General");
		ExerciseTypeList.Add("Warm-Up");
		ExerciseTypeList.Add("Stretch");
		ExerciseTypeList.Add("Weights");
		ExerciseTypeList.Add("Cardio-Light");
        ExerciseTypeList.Add("Cardio-Moderate");
        ExerciseTypeList.Add("Cardio-Intense");
        ExerciseTypeList.Add("Yoga");
		ExerciseTypeList.Add("Body Weight");
		ExerciseTypeList.Add("Cross-Fit");
		ExerciseTypeList.Add("Fighting");

        WorkoutTypeList.Clear();
        WorkoutTypeList.Add("General");
        WorkoutTypeList.Add("Warm-Up");
        WorkoutTypeList.Add("Stretch");
        WorkoutTypeList.Add("Weights");
        WorkoutTypeList.Add("Cardio");
        WorkoutTypeList.Add("Yoga");
        WorkoutTypeList.Add("Fighting");
        WorkoutTypeList.Add("Cross-Fit");

        TrainingTypeList.Clear();
        TrainingTypeList.Add("General");
        TrainingTypeList.Add("Warm-Up");
        TrainingTypeList.Add("Stretch");
        TrainingTypeList.Add("Weights");
        TrainingTypeList.Add("Cardio");
        TrainingTypeList.Add("Yoga");
        TrainingTypeList.Add("Fighting");
        TrainingTypeList.Add("Cross-Fit");

        BodyPartList.Clear ();
		BodyPartList.Add("Body");
		BodyPartList.Add("Arms");
		BodyPartList.Add("Abs");
		BodyPartList.Add("Back");
		BodyPartList.Add("Chest");
		BodyPartList.Add("Core");
		BodyPartList.Add("Legs");

		BodySide.Clear ();
		BodySide.Add("None");
		BodySide.Add("Left");
		BodySide.Add("Right");

		NumberList.Clear ();
		NumberList.Add(0);
		NumberList.Add(1);
		NumberList.Add(2);
		NumberList.Add(3);
		NumberList.Add(4);
		NumberList.Add(5);
		NumberList.Add(6);
		NumberList.Add(7);
		NumberList.Add(8);
		NumberList.Add(9);

		NumberListToFive.Clear ();
		NumberListToFive.Add(0);
		NumberListToFive.Add(1);
		NumberListToFive.Add(2);
		NumberListToFive.Add(3);
		NumberListToFive.Add(4);
		NumberListToFive.Add(5);

		YesNoList.Clear ();
		YesNoList.Add("Yes");
		YesNoList.Add("No");

		MonthList.Clear ();
		MonthList.Add("January");
		MonthList.Add("February");
		MonthList.Add("March");
		MonthList.Add("April");
		MonthList.Add("May");
		MonthList.Add("June");
		MonthList.Add("July");
		MonthList.Add("August");
		MonthList.Add("September");
		MonthList.Add("October");
		MonthList.Add("November");
		MonthList.Add("December");

		FilterExerciseTypeList.Clear ();
		FilterExerciseTypeList.Add ("None");
		foreach (string item in ExerciseTypeList)
		{
			FilterExerciseTypeList.Add (item);
		}

		FilterBodyPartList.Clear ();
		FilterBodyPartList.Add ("None");
		foreach (string item in BodyPartList)
		{
			FilterBodyPartList.Add (item);
		}
		
		UIManager = GameObject.Find("UI_Manager_Prefab");

        UserDownloadTrainingData = new SaveDownloadTrainingData();
        UserDownloadWorkoutData = new SaveDownloadWorkoutData();
        UserDownloadExerciseData = new SaveDownloadExerciseData();
        UserDownloadTrainingDataString = "";
        UserDownloadWorkoutDataString = "";
        UserDownloadExerciseDataString = "";
        UserWorkoutData = new SaveWorkoutData ();
		UserExerciseData = new SaveExerciseData();
		UserFriendData = new SaveFriendData ();
		UserTrainingData = new SaveTrainingData ();
		UserDayData = new SaveDayData ();

		_FileLocation=Application.persistentDataPath;
        _DownloadTrainingDataFileName = "DownloadTrainingData.xml";  // temporarily get these locally. change this to be downloaded from the server
        _DownloadWorkoutDataFileName = "DownloadWorkoutData.xml";  // temporarily get these locally. change this to be downloaded from the server
        _DownloadExerciseDataFileName = "DownloadExerciseData.xml";  // temporarily get these locally. change this to be downloaded from the server
        _FileName = "SaveData.xml";  
		_TrainingDataFileName = "TrainingData.xml";
		_WorkoutDataFileName = "WorkoutData.xml";
		_ExerciseDataFileName = "ExerciseData.xml";
		_DayDataFileName = "DayData.xml";
		_SettingsDataFileName = "SettingsData.xml";
		_FriendDataFileName = "FriendData.xml";

		myData=new SaveData(); 		
		mySettingsData = new SaveSettingsData();


	}
	
	void Start ()
	{
        if (File.Exists(_FileLocation + "/" + _DownloadTrainingDataFileName))  // temporarily get these locally. change this to be downloaded from the server
        {
            //LoadDownloadTrainingData();
        }
        if (File.Exists(_FileLocation + "/" + _DownloadWorkoutDataFileName))  // temporarily get these locally. change this to be downloaded from the server
        {
            //LoadDownloadWorkoutData();
        }
        if (File.Exists(_FileLocation + "/" + _DownloadExerciseDataFileName))  // temporarily get these locally. change this to be downloaded from the server
        {
            //LoadDownloadExerciseData();
        }
        if (File.Exists(_FileLocation+"/"+ _TrainingDataFileName))
		{
			LoadTrainingData();
		}		
		if(File.Exists(_FileLocation+"/"+ _WorkoutDataFileName))
		{
			LoadWorkoutData();
		}		
		if(File.Exists(_FileLocation+"/"+ _ExerciseDataFileName))
		{
			LoadExerciseData();
		}
		if(File.Exists(_FileLocation+"/"+ _DayDataFileName))
		{
			LoadDayData();
		}
		if(File.Exists(_FileLocation+"/"+ _SettingsDataFileName))
		{
			LoadSettingsData();
		}	
/*
		if(File.Exists(_FileLocation+"/"+ _FriendDataFileName))
		{
			LoadFriendData();
		}	
*/
		if(!File.Exists(_FileLocation+"/"+ _TrainingDataFileName))
		{
			TrainingDataInit TrainingDataString = new TrainingDataInit();
			CreateFileFromString (_TrainingDataFileName, TrainingDataString.InitData);
			LoadTrainingData();
		}
		if(!File.Exists(_FileLocation+"/"+ _ExerciseDataFileName))
		{
			ExerciseDataInit ExerciseDataString = new ExerciseDataInit();
			CreateFileFromString (_ExerciseDataFileName, ExerciseDataString.InitData);
			LoadExerciseData();
		}
		if(!File.Exists(_FileLocation+"/"+ _WorkoutDataFileName))
		{
			WorkoutDataInit WorkoutDataString = new WorkoutDataInit();
			CreateFileFromString (_WorkoutDataFileName, WorkoutDataString.InitData);
			LoadWorkoutData();
		}
		if(!File.Exists(_FileLocation+"/"+ _DayDataFileName))
		{
			DayDataInit DayDataString = new DayDataInit();
			CreateFileFromString (_DayDataFileName, DayDataString.InitData);
			LoadDayData();
		}
		if(!File.Exists(_FileLocation+"/"+ _SettingsDataFileName))
		{
			SettingsDataInit SettingsDataString = new SettingsDataInit();
			CreateFileFromString (_SettingsDataFileName, SettingsDataString.InitData);
			LoadSettingsData();
		}
/*
		if(!File.Exists(_FileLocation+"/"+ _FriendDataFileName))
		{
			FriendDataInit FriendDataString = new FriendDataInit();
			CreateFileFromString (_FriendDataFileName, FriendDataString.InitData);
			LoadFriendData();
		}
*/
	}

	public void SaveTraining()
	{
//		myTrainingData.UserTrainingData = UserTrainingData;
		SaveTrainingDataXML();
	}
	public void SaveWorkout()
	{
		SaveWorkoutDataXML();
	}	

	public void SaveExercise()
	{
		SaveExerciseDataXML();
	}	

	public void SaveDay()
	{
		SaveDayDataXML();
	}

	public void SaveSettings()
	{
		mySettingsData.UserSettingsData = UserSettingsData;
		SaveSettingsDataXML();
	}

	public void SaveFriend()
	{
		SaveFriendDataXML();
	}

	public void SavePlayerData()
	{
		// Time to creat our XML! 
		_data = SerializeObject(myData, "SaveData"); 
		
		// This is the final resulting XML from the serialization process 
		CreateXML(_FileName, _data); 
	}

	public void SaveTrainingDataXML()
	{
		// Time to creat our XML! 
		_data = SerializeObject(UserTrainingData, "SaveTrainingData"); 
		
		// This is the final resulting XML from the serialization process 
		CreateXML(_TrainingDataFileName, _data); 
	}

	public void SaveWorkoutDataXML()
	{
		// Time to creat our XML! 
		_data = SerializeObject(UserWorkoutData, "SaveWorkoutData"); 
		
		// This is the final resulting XML from the serialization process 
		CreateXML(_WorkoutDataFileName, _data); 
	}

	public void SaveExerciseDataXML()
	{
		// Time to creat our XML! 
		_data = SerializeObject(UserExerciseData, "SaveExerciseData"); 

		// This is the final resulting XML from the serialization process 
		CreateXML(_ExerciseDataFileName, _data); 
	}

	public void SaveDayDataXML()
	{
		// Time to creat our XML! 
		_data = SerializeObject(UserDayData, "SaveDayData"); 
		
		// This is the final resulting XML from the serialization process 
		CreateXML(_DayDataFileName, _data); 
	}

	public void SaveSettingsDataXML()
	{
		// Time to creat our XML! 
		_data = SerializeObject(mySettingsData, "SaveSettingsData"); 
		
		// This is the final resulting XML from the serialization process 
		CreateXML(_SettingsDataFileName, _data); 
	}

	public void SaveFriendDataXML()
	{
		// Time to creat our XML! 
		_data = SerializeObject(UserFriendData, "SaveFriendData"); 
		
		// This is the final resulting XML from the serialization process 
		CreateXML(_FriendDataFileName, _data); 
	}

    public void LoadDownloadTrainingData()
    {
        _data = LoadXML(ServerURL + "Download/" + _DownloadTrainingDataFileName);
        if (UserDownloadTrainingDataString.ToString() != "")
        {
            //UserDownloadTrainingData = (SaveDownloadTrainingData)DeserializeObject(_data, "SaveDownloadTrainingData");
            UserDownloadTrainingData = (SaveDownloadTrainingData)DeserializeObject(UserDownloadTrainingDataString, "SaveDownloadTrainingData");
        }
    }

    public void LoadDownloadWorkoutData()
    {
        _data = LoadXML(ServerURL + "Download/" + _DownloadWorkoutDataFileName);
        if (UserDownloadWorkoutDataString.ToString() != "")
        {
            //UserDownloadWorkoutData = (SaveDownloadWorkoutData)DeserializeObject(_data, "SaveDownloadWorkoutData");
            UserDownloadWorkoutData = (SaveDownloadWorkoutData)DeserializeObject(UserDownloadWorkoutDataString, "SaveDownloadWorkoutData");
        }
    }

    public void LoadDownloadExerciseData()
    {
        _data = LoadXML(ServerURL + "Download/" + _DownloadExerciseDataFileName);
        if (UserDownloadExerciseDataString.ToString() != "")
        {
            //UserDownloadExerciseData = (SaveDownloadExerciseData)DeserializeObject(_data, "SaveDownloadExerciseData");
            UserDownloadExerciseData = (SaveDownloadExerciseData)DeserializeObject(UserDownloadExerciseDataString, "SaveDownloadExerciseData");
        }
    }

    public void LoadTrainingData()
	{
		_data = LoadXML(_FileLocation + "/" + _TrainingDataFileName); 
		if(_data.ToString() != "") 
		{ 
			UserTrainingData = (SaveTrainingData)DeserializeObject(_data, "SaveTrainingData"); 
		}		
	}

	public void LoadWorkoutData()
	{
		_data = LoadXML(_FileLocation + "/" + _WorkoutDataFileName); 
		if(_data.ToString() != "") 
		{ 
			UserWorkoutData = (SaveWorkoutData)DeserializeObject(_data, "SaveWorkoutData"); 
		}		
	}

	public void LoadExerciseData()
	{
		_data = LoadXML(_FileLocation + "/" + _ExerciseDataFileName); 
		if(_data.ToString() != "") 
		{ 		
			UserExerciseData = (SaveExerciseData)DeserializeObject(_data, "SaveExerciseData"); 
		}		
	}

	public void LoadDayData()
	{
		_data = LoadXML(_FileLocation + "/" + _DayDataFileName); 
		if(_data.ToString() != "") 
		{ 
/*
			myDayData = (SaveDayData)DeserializeObject(_data, "SaveDayData"); 
			
			for(var i = 0; i < myDayData.UserDayData.Count; i++)
			{
				UserDayData.Add(myDayData.UserDayData[i]);
			}
*/
			UserDayData = (SaveDayData)DeserializeObject(_data, "SaveDayData"); 
		}		
	}

	public void LoadSettingsData()
	{
		_data = LoadXML(_FileLocation + "/" + _SettingsDataFileName); 
		if(_data.ToString() != "") 
		{ 
			mySettingsData = (SaveSettingsData)DeserializeObject(_data, "SaveSettingsData"); 
			UserSettingsData = mySettingsData.UserSettingsData;
		}		
	}

	public void LoadFriendData()
	{
		_data = LoadXML(_FileLocation + "/" + _FriendDataFileName); 
		if(_data.ToString() != "") 
		{ 		
			UserFriendData = (SaveFriendData)DeserializeObject(_data, "SaveFriendData"); 
		}
	}

	public int FindTrainingByName(string SearchText)
	{
		int foundIndex = -1;
		for (var i = 0; i < UserTrainingData.Training.Length; i++) 
		{
			if (UserTrainingData.Training[i].Name.ToLower() == SearchText.ToLower())
			{
				foundIndex = i;
				return foundIndex;
			}
		}
		return foundIndex;
	}

	public int FindWorkoutByName(string SearchText)
	{
		int foundIndex = -1;
		for (var i = 0; i < UserWorkoutData.Workout.Length; i++) 
		{
			if (UserWorkoutData.Workout[i].Name.ToLower() == SearchText.ToLower())
			{
				foundIndex = i;
				return foundIndex;
			}
		}
		return foundIndex;
	}

	public int FindExerciseByName(string SearchText)
	{
		int foundIndex = -1;
		for (var i = 0; i < UserExerciseData.Exercise.Length; i++) 
		{
			if (UserExerciseData.Exercise[i].Name.ToLower() == SearchText.ToLower())
			{
				foundIndex = i;
				return foundIndex;
			}
		}
		return foundIndex;
	}

	public int FindFriendByScreenName(string SearchText)
	{
		int foundIndex = -1;
		for (var i = 0; i < UserFriendData.Friend.Length; i++) 
		{
			if (UserFriendData.Friend[i].ScreenName.ToLower() == SearchText.ToLower())
			{
				foundIndex = i;
				return foundIndex;
			}
		}
		return foundIndex;
	}

    public int FindDownloadTrainingByName(string SearchText)
    {
        int foundIndex = -1;
        for (var i = 0; i < UserDownloadTrainingData.DownloadTraining.Length; i++)
        {
            if (UserDownloadTrainingData.DownloadTraining[i].Name.ToLower() == SearchText.ToLower())
            {
                foundIndex = i;
                return foundIndex;
            }
        }
        return foundIndex;
    }

    public int FindDownloadWorkoutByName(string SearchText)
    {
        int foundIndex = -1;
        for (var i = 0; i < UserDownloadWorkoutData.DownloadWorkout.Length; i++)
        {
            if (UserDownloadWorkoutData.DownloadWorkout[i].Name.ToLower() == SearchText.ToLower())
            {
                foundIndex = i;
                return foundIndex;
            }
        }
        return foundIndex;
    }

    public int FindDownloadExerciseByName(string SearchText)
    {
        int foundIndex = -1;
        for (var i = 0; i < UserDownloadExerciseData.DownloadExercise.Length; i++)
        {
            if (UserDownloadExerciseData.DownloadExercise[i].Name.ToLower() == SearchText.ToLower())
            {
                foundIndex = i;
                return foundIndex;
            }
        }
        return foundIndex;
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
		xmlTextWriter.Formatting = Formatting.Indented ;
		xs.Serialize(xmlTextWriter, pObject); 
		memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray()); 
		return XmlizedString; 
	} 
	
	void CreateXML(string myFileName, string myDataString) 
	{ 
		StreamWriter writer; 
		FileInfo t = new FileInfo(_FileLocation+"/"+ myFileName); 
		if(!t.Exists) 
		{ 
			writer = t.CreateText(); 
		} 
		else 
		{ 
			t.Delete(); 
			writer = t.CreateText(); 
		} 
		writer.Write(myDataString); 
		writer.Close(); 
		//		Debug.Log("File written."); 
	} 
	
	string LoadXML(string myFileName) 
	{ 
		StreamReader r = File.OpenText(myFileName); 
		string _info = r.ReadToEnd(); 
		r.Close(); 
		return _info;
		//		Debug.Log("File Read"); 
	} 	

	void CreateFileFromString(string myFileName, string myDataString) 
	{ 
		StreamWriter writer; 
		FileInfo t = new FileInfo(_FileLocation+"/"+ myFileName); 
		if(!t.Exists) 
		{ 
			writer = t.CreateText(); 
		} 
		else 
		{ 
			t.Delete(); 
			writer = t.CreateText(); 
		} 
		writer.Write(myDataString); 
		writer.Close(); 
		//		Debug.Log("File written."); 
	}

	void Update()
	{
		CurrentTime = System.DateTime.Now;
		if(CurrentTime.Hour > 12)
		{
			if (CurrentTime.Minute < 10)
			{
				CurrentTimeString = (CurrentTime.Hour - 12).ToString() + ":0" + CurrentTime.Minute.ToString() + " pm";
			}
			else
			{
				CurrentTimeString = (CurrentTime.Hour - 12).ToString() + ":" + CurrentTime.Minute.ToString() + " pm";
			}
		}
		else
		{
			if (CurrentTime.Minute < 10)
			{
				CurrentTimeString = CurrentTime.Hour.ToString() + ":0" + CurrentTime.Minute.ToString() + " am";
			}
			else
			{
				CurrentTimeString = CurrentTime.Hour.ToString() + ":" + CurrentTime.Minute.ToString() + " am";
			}
		}
	}
}
