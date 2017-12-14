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
using System.Timers;

public class UI_Uploading : MonoBehaviour {

    public bool Initialize = false;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject MessageText;
    public GameObject OKButton;
    public GameObject WaitAnimationImage;

    public List<TrainingData> TrainingFileList = new List<TrainingData>();
    public List<WorkoutData> WorkoutFileList = new List<WorkoutData>();
    public List<ExerciseData> ExerciseFileList = new List<ExerciseData>();
    public List<string> FriendList = new List<string>();

    public bool FriendTrainingFileUploaded = false;
    public bool FriendWorkoutFileUploaded = false;
    public bool FriendExerciseFileUploaded = false;

    public bool AllUploadingComplete = false;

    private Texture2D[] WaitAnimationImageArray;
    private Timer WaitAnimationTimer = new Timer();
    private int WaitAnimationImageIndex = 0;

    void Awake()
    {
        UserBlobManager = GameObject.Find("UserBlob_Prefab");
        UIManager = GameObject.Find("UI_Manager_Prefab");
        WaitAnimationImageArray = Resources.LoadAll<Texture2D>("UI/WaitAnimation");
    }

    // Use this for initialization
    void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Initialize)
        {
            Init();
        }
        
        // update wait animation
        WaitAnimationImage.GetComponent<RawImage>().texture = WaitAnimationImageArray[WaitAnimationImageIndex];

        if (FriendTrainingFileUploaded == true || FriendWorkoutFileUploaded == true || FriendExerciseFileUploaded == true)
        {
            if(AllUploadingComplete == false)
            {
                AllUploadingComplete = true;
                MessageText.GetComponent<Text>().text += "Uploading Complete\n";
                OKButton.SetActive(true);
                WaitAnimationTimer.Stop();
                WaitAnimationImage.SetActive(false);
            }
        }
    }

    public void Init()
    {
        Initialize = false;

        WaitAnimationImageIndex = 0;
        WaitAnimationTimer = new Timer();
        WaitAnimationTimer.Interval = 30;
        WaitAnimationTimer.Elapsed += new ElapsedEventHandler(OnWaitAnimationTimerEvent);
        WaitAnimationTimer.Start();
        WaitAnimationImage.GetComponent<RawImage>().texture = WaitAnimationImageArray[0];
        WaitAnimationImage.SetActive(true);

        AllUploadingComplete = false;
        MessageText.GetComponent<Text>().text = "";
        OKButton.SetActive(false);
        TrainingFileList = UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData;
        WorkoutFileList = UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData;
        ExerciseFileList = UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData;
        FriendTrainingFileUploaded = false;
        FriendWorkoutFileUploaded = false;
        FriendExerciseFileUploaded = false;

        if (FriendList.Count > 0)
        {
            UploadFriendFiles();
        }
        else
        {
            UploadShareFiles();
        }

    }

    public void OnWaitAnimationTimerEvent(object source, ElapsedEventArgs e)
    {
        WaitAnimationImageIndex++;
        if (WaitAnimationImageIndex >= WaitAnimationImageArray.Length - 1)
        {
            WaitAnimationImageIndex = 0;
        }
    }

    public void OnOkButtonPressed()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
    }

    public void UploadFriendFiles ()
    {
        for (int i = 0; i < FriendList.Count; i++)
        {
            int FriendIndex = UserBlobManager.GetComponent<UserBlobManager>().FindFriendByScreenName(FriendList[i]);
            string formFriendName = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend[FriendIndex].ScreenName;
            string formFriendEmail = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend[FriendIndex].Email;


            if (UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData.Count > 0)
            {
                UploadTraining(formFriendName, formFriendEmail);
            }
            if (UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData.Count > 0)
            {
                UploadWorkout(formFriendName, formFriendEmail);
            }
            if (UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData.Count > 0)
            {
                UploadExercise(formFriendName, formFriendEmail);
            }
        }
    }

    public void UploadShareFiles()
    {
        string ScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        if (UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData.Count > 0)
        {
            StartCoroutine(UploadTrainingFile(ScreenName, "Everyone"));
        }
        if (UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData.Count > 0)
        {
            StartCoroutine(UploadWorkoutFile(ScreenName, "Everyone"));
        }
        if (UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData.Count > 0)
        {
            StartCoroutine(UploadExerciseFile(ScreenName, "Everyone"));
        }
    }

    public void UploadTraining(string FriendName, string FriendEmail)
    {
        MessageText.GetComponent<Text>().text += "Uploading Trainings To " + FriendName + "\n";
        StartCoroutine(UploadTrainingFile(FriendName, "Friends"));

        // send email
        string myScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string myEmail = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserEmail;
        string SubjectText = "New Trainings from " + myScreenName;
        string BodyText = myScreenName + " sent you some new Trainings. Check your downloads from friends in the Ultimate Training App.";
        StartCoroutine(SendEmail(myScreenName, myEmail, FriendName, FriendEmail, SubjectText, BodyText));
    }

    public void UploadWorkout(string FriendName, string FriendEmail)
    {
        MessageText.GetComponent<Text>().text += "Uploading Workouts To " + FriendName + "\n";
        StartCoroutine(UploadWorkoutFile(FriendName, "Friends"));

        // send email
        string myScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string myEmail = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserEmail;
        string SubjectText = "New Workouts from " + myScreenName;
        string BodyText = myScreenName + " sent you some new Workouts. Check your downloads from friends in the Ultimate Workout App.";
        StartCoroutine(SendEmail(myScreenName, myEmail, FriendName, FriendEmail, SubjectText, BodyText));
    }

    public void UploadExercise(string FriendName, string FriendEmail)
    {
        MessageText.GetComponent<Text>().text += "Uploading Exercises To " + FriendName + "\n";
        StartCoroutine(UploadExerciseFile(FriendName, "Friends"));

        // send email
        string myScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string myEmail = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserEmail;
        string SubjectText = "New Exercises from " + myScreenName;
        string BodyText = myScreenName + " sent you some new exercises. Check your downloads from friends in the Ultimate Workout App.";
        StartCoroutine(SendEmail(myScreenName, myEmail, FriendName, FriendEmail, SubjectText, BodyText));
    }


    IEnumerator UploadTrainingFile(string FriendName, string ActionType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string ScreenNameType = FriendName + "_Training";
        string Action = "get_upload_data";
        if (ActionType == "Everyone")
        {
            Action = "get_share_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("action", Action);
        form.AddField("myform_screennametype", ScreenNameType);
        form.AddField("myform_type", "Training");
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
                if (!formText.Contains("Cant Find Upload Data") && formText != "\r\n")
                {
                    // merge file
                    print("Merge Upload File");
                    StartCoroutine(MergeTrainingFile(ScreenNameType, "Training", formText, ActionType));
                }
                else
                {
                    // serialize
                    SaveTrainingData UserTrainingData = new SaveTrainingData();
                    for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData.Count; i++)
                    {
                        UserTrainingData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData[i]);
                    }

                    string Data = SerializeObject(UserTrainingData, "SaveTrainingData");
                    int index = Data.IndexOf(System.Environment.NewLine);
                    Data = Data.Substring(index + System.Environment.NewLine.Length);
                    // upload file
                    print("Upload File");
                    StartCoroutine(UploadFile(ScreenNameType, "Training", Data, ActionType));
                }
            }
        }
        w.Dispose();
    }

    IEnumerator UploadWorkoutFile(string FriendName, string ActionType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string ScreenNameType = FriendName + "_Workout";
        string Action = "get_upload_data";
        if (ActionType == "Everyone")
        {
            Action = "get_share_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("action", Action);
        form.AddField("myform_screennametype", ScreenNameType);
        form.AddField("myform_type", "Workout");
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
                if (!formText.Contains("Cant Find Upload Data") && formText != "\r\n")
                {
                    // merge file
                    print("Merge Upload File");
                    StartCoroutine(MergeWorkoutFile(ScreenNameType, "Workout", formText, ActionType));
                }
                else
                {
                    // serialize
                    SaveWorkoutData UserWorkoutData = new SaveWorkoutData();
                    for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData.Count; i++)
                    {
                        UserWorkoutData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData[i]);
                    }

                    string Data = SerializeObject(UserWorkoutData, "SaveWorkoutData");
                    int index = Data.IndexOf(System.Environment.NewLine);
                    Data = Data.Substring(index + System.Environment.NewLine.Length);
                    // upload file
                    print("Upload File");
                    StartCoroutine(UploadFile(ScreenNameType, "Workout", Data, ActionType));
                }
            }
        }
        w.Dispose();
    }

    IEnumerator UploadExerciseFile(string FriendName, string ActionType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string ScreenNameType = FriendName + "_Exercise";
        string Action = "get_upload_data";
        if (ActionType == "Everyone")
        {
            Action = "get_share_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("action", Action);
        form.AddField("myform_screennametype", ScreenNameType);
        form.AddField("myform_type", "Exercise");
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
                if (!formText.Contains("Cant Find Upload Data") && formText != "\r\n")
                {
                    // merge file
                    print("Merge Upload File");
                    StartCoroutine(MergeExerciseFile(ScreenNameType, "Exercise", formText, ActionType));
                }
                else
                {
                    // serialize
                    SaveExerciseData UserExerciseData = new SaveExerciseData();
                    for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData.Count; i++)
                    {
                        UserExerciseData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData[i]);
                    }

                    string Data = SerializeObject(UserExerciseData, "SaveExerciseData");
                    int index = Data.IndexOf(System.Environment.NewLine);
                    Data = Data.Substring(index + System.Environment.NewLine.Length);
                    // upload file
                    print("Upload File");
                    StartCoroutine(UploadFile(ScreenNameType, "Exercise", Data, ActionType));
                }
            }
        }
        w.Dispose();
    }


    IEnumerator MergeTrainingFile(string ScreenNameType, string Type, string DownloadString, string ActionType)
    {
        // remove old data
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "remove_upload_data";
        if (ActionType == "Everyone")
        {
            Action = "remove_share_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", Action);
        form.AddField("myform_screennametype", ScreenNameType);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            SaveTrainingData tempTraining = new SaveTrainingData();
            tempTraining = (SaveTrainingData)DeserializeObject(DownloadString, "SaveTrainingData");

            // get data to add
            SaveTrainingData UserTrainingData = new SaveTrainingData();
            for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData.Count; i++)
            {
                UserTrainingData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData[i]);
            }

            // merge data
            for (int i = 0; i < tempTraining.Training.Length; i++)
            {
                // check for duplicates
                bool duplicateFound = false;
                for (int j = 0; j < UserTrainingData.Training.Length; j++)
                {
                    if (tempTraining.Training[i].Name == UserTrainingData.Training[j].Name)
                    {
                        duplicateFound = true;
                    }
                }
                if (!duplicateFound)
                {
                    UserTrainingData.Add(tempTraining.Training[i]);
                }
            }

            // upload file
            string Data = SerializeObject(UserTrainingData, "SaveTrainingData");
            int index = Data.IndexOf(System.Environment.NewLine);
            Data = Data.Substring(index + System.Environment.NewLine.Length);
            StartCoroutine(UploadFile(ScreenNameType, "Training", Data, ActionType));
        }
        w.Dispose();
    }

    IEnumerator MergeWorkoutFile(string ScreenNameType, string Type, string DownloadString, string ActionType)
    {
        // remove old data
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "remove_upload_data";
        if (ActionType == "Everyone")
        {
            Action = "remove_share_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", Action);
        form.AddField("myform_screennametype", ScreenNameType);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            SaveWorkoutData tempWorkout = new SaveWorkoutData();
            tempWorkout = (SaveWorkoutData)DeserializeObject(DownloadString, "SaveWorkoutData");

            // get data to add
            SaveWorkoutData UserWorkoutData = new SaveWorkoutData();
            for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData.Count; i++)
            {
                UserWorkoutData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData[i]);
            }

            // merge data
            for (int i = 0; i < tempWorkout.Workout.Length; i++)
            {
                // check for duplicates
                bool duplicateFound = false;
                for (int j = 0; j < UserWorkoutData.Workout.Length; j++)
                {
                    if (tempWorkout.Workout[i].Name == UserWorkoutData.Workout[j].Name)
                    {
                        duplicateFound = true;
                    }
                }
                if (!duplicateFound)
                {
                    UserWorkoutData.Add(tempWorkout.Workout[i]);
                }
            }

            // upload file
            string Data = SerializeObject(UserWorkoutData, "SaveWorkoutData");
            int index = Data.IndexOf(System.Environment.NewLine);
            Data = Data.Substring(index + System.Environment.NewLine.Length);
            StartCoroutine(UploadFile(ScreenNameType, "Workout", Data, ActionType));
        }
        w.Dispose();
    }


    IEnumerator MergeExerciseFile(string ScreenNameType, string Type, string DownloadString, string ActionType)
    {
        // remove old data
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "remove_upload_data";
        if (ActionType == "Everyone")
        {
            Action = "remove_share_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", Action);
        form.AddField("myform_screennametype", ScreenNameType);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            SaveExerciseData tempExercise = new SaveExerciseData();
            tempExercise = (SaveExerciseData)DeserializeObject(DownloadString, "SaveExerciseData");

            // get data to add
            SaveExerciseData UserExerciseData = new SaveExerciseData();
            for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData.Count; i++)
            {
                UserExerciseData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData[i]);
            }

            // merge data
            for (int i = 0; i < tempExercise.Exercise.Length; i++)
            {
                // check for duplicates
                bool duplicateFound = false;
                for (int j = 0; j < UserExerciseData.Exercise.Length; j++)
                {
                    if (tempExercise.Exercise[i].Name == UserExerciseData.Exercise[j].Name)
                    {
                        duplicateFound = true;
                    }
                }
                if (!duplicateFound)
                {
                    UserExerciseData.Add(tempExercise.Exercise[i]);
                }
            }

            // upload file
            string Data = SerializeObject(UserExerciseData, "SaveExerciseData");
            int index = Data.IndexOf(System.Environment.NewLine);
            Data = Data.Substring(index + System.Environment.NewLine.Length);
            StartCoroutine(UploadFile(ScreenNameType, "Exercise", Data, ActionType));
        }
        w.Dispose();
    }

    IEnumerator UploadFile(string ScreenNameType, string Type, string Data, string ActionType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "set_upload_data";
        if (ActionType == "Everyone")
        {
            Action = "set_share_data";
        }
        string date = System.DateTime.Now.Year.ToString("D4");
        date += System.DateTime.Now.Month.ToString("D2");
        date += System.DateTime.Now.Day.ToString("D2");

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", Action);
        form.AddField("myform_screennametype", ScreenNameType);
        form.AddField("myform_type", Type);
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
                print("File Uploaded: " + Type);
                if (Type == "Training")
                {
                    FriendTrainingFileUploaded = true;
                }
                if (Type == "Workout")
                {
                    FriendWorkoutFileUploaded = true;
                }
                if (Type == "Exercise")
                {
                    FriendExerciseFileUploaded = true;
                }
            }
        }
        w.Dispose();
    }
   

    IEnumerator SendEmail(string fromName, string fromEmail, string formFriendName, string formFriendEmail, string SubjectText, string BodyText)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;

        WWWForm form = new WWWForm();
        form.AddField("action", "send_to_friends");
        form.AddField("myform_hash", hash);
        form.AddField("myform_FromName", fromName);
        form.AddField("myform_FromEmail", fromEmail);
        form.AddField("myform_FriendName", formFriendName);
        form.AddField("myform_FriendEmail", formFriendEmail);
        form.AddField("myform_SubjectText", SubjectText);
        form.AddField("myform_BodyText", BodyText);

        WWW w = new WWW(URL, form);
        yield return w;
        //print(w.error);
        //print(w.text);
        formText = w.text;
        if (w.error != null)
        {
            // connection error
            print(w.error);
        }
        else
        {
            if (formText.Contains("HASH code is different from your app"))
            {
                print("Email failed to send.");
            }
            else
            {
                print(w.text);
                print("Email sent.");

            }
        }
        w.Dispose();
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
