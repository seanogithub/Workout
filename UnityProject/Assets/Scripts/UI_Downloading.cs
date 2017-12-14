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

public class UI_Downloading : MonoBehaviour {

    public bool Initialize = false;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject MessageText;
    public GameObject OKButton;
    public GameObject WaitAnimationImage;

    public List<string> TrainingFileList = new List<string>();
    public List<string> WorkoutFileList = new List<string>();
    public List<string> ExerciseFileList = new List<string>();
    public bool TrainingFileDownloaded = false;
    public bool WorkoutFileDownloaded = false;
    public bool ExerciseFileDownloaded = false;
    public bool FriendTrainingFileDownloaded = false;
    public bool FriendWorkoutFileDownloaded = false;
    public bool FriendExerciseFileDownloaded = false;
    public bool DownloadFromFriends = false;
    public bool AllDownloadingComplete = false;
    public int DownloadCount = 0;

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
    void Start () {
	
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

        MessageText.GetComponent<Text>().text = "";
        DownloadCount = 0;
        TrainingFileDownloaded = false;
        WorkoutFileDownloaded = false;
        ExerciseFileDownloaded = false;
        FriendTrainingFileDownloaded = false;
        FriendWorkoutFileDownloaded = false;
        FriendExerciseFileDownloaded = false;
        AllDownloadingComplete = false;
        OKButton.SetActive(false);
        if (TrainingFileList.Count > 0 && DownloadFromFriends == false)
        {
            DownloadTraining();
        }
        if (WorkoutFileList.Count > 0 && DownloadFromFriends == false)
        {
            DownloadWorkout();
        }
        if (ExerciseFileList.Count > 0 && DownloadFromFriends == false)
        {
            DownloadExercise();
        }
        if (DownloadFromFriends == true)
        {
            DownloadFriendTraining();
            DownloadFriendWorkout();
            DownloadFriendExercise();
        }
    }

    void Update()
    {
        if (Initialize)
        {
            Init();
        }

        // update wait animation
        WaitAnimationImage.GetComponent<RawImage>().texture = WaitAnimationImageArray[WaitAnimationImageIndex];

        if (TrainingFileList.Count > 0)
        {
            if (DownloadCount == TrainingFileList.Count)
            {
                TrainingFileDownloaded = true;
            }
        }

        if (WorkoutFileList.Count > 0)
        {
            if (DownloadCount == WorkoutFileList.Count)
            {
                WorkoutFileDownloaded = true;
            }
        }

        if (ExerciseFileList.Count > 0)
        {
            if(DownloadCount == ExerciseFileList.Count)
            {
                ExerciseFileDownloaded = true;
            }
        }

        if (DownloadFromFriends == true && FriendTrainingFileDownloaded == true && FriendWorkoutFileDownloaded == true && FriendExerciseFileDownloaded == true)
        {
            if (AllDownloadingComplete == false)
            {
                AllDownloadingComplete = true;
                DownloadFromFriends = false;
                MessageText.GetComponent<Text>().text += "Downloading Complete\n";
                OKButton.SetActive(true);
                WaitAnimationTimer.Stop();
                WaitAnimationImage.SetActive(false);
            }
        }

        if(TrainingFileDownloaded == true || WorkoutFileDownloaded == true || ExerciseFileDownloaded == true)
        {
            if(AllDownloadingComplete == false)
            {
                AllDownloadingComplete = true;
                DownloadFromFriends = false;
                MessageText.GetComponent<Text>().text += "Downloading Complete\n";
                OKButton.SetActive(true);
                WaitAnimationTimer.Stop();
                WaitAnimationImage.SetActive(false);
            }
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

    public void DownloadFriendTraining()
    {
        MessageText.GetComponent<Text>().text += "Downloading Training From Friends\n";
        //string FileName = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Upload/Training/" + UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + ".xml";
        StartCoroutine(DownloadTrainingFile(UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Upload/Training/", UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + "_Training", "Friends"));
    }

    public void DownloadFriendWorkout()
    {
        MessageText.GetComponent<Text>().text += "Downloading Workout From Friends\n";
        //string FileName = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Upload/Workout/" + UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + ".xml";
        StartCoroutine(DownloadWorkoutFile(UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Upload/Workout/", UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + "_Workout", "Friends"));
    }

    public void DownloadFriendExercise()
    {
        MessageText.GetComponent<Text>().text += "Downloading Exercise From Friends\n";
        //string FileName = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Upload/Exercise/" + UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + ".xml";
        StartCoroutine(DownloadExerciseFile(UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Upload/Exercise/", UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + "_Exercise", "Friends"));
    }

    public void DownloadTraining()
    {
        for (int i = 0; i < TrainingFileList.Count; i++)
        {
            string name = TrainingFileList[i].Replace(".xml", "");
            MessageText.GetComponent<Text>().text += name + "\n";
            //string FileName = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Download/Training/" + TrainingFileList[i];
            StartCoroutine(DownloadTrainingFile(UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Download/Training/", TrainingFileList[i], "Download"));
        }
    }

    public void DownloadWorkout()
    {
        for (int i = 0; i < WorkoutFileList.Count; i++)
        {
            string name = WorkoutFileList[i].Replace(".xml", "");
            MessageText.GetComponent<Text>().text += name + "\n";
            //string FileName = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Download/Workout/" + WorkoutFileList[i];
            StartCoroutine(DownloadWorkoutFile(UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Download/Workout/", WorkoutFileList[i], "Download"));
        }
    }

    public void DownloadExercise()
    {
        for(int i = 0; i < ExerciseFileList.Count; i++)
        {
            string name = ExerciseFileList[i].Replace(".xml", "");
            MessageText.GetComponent<Text>().text += name + "\n";
            //string FileName = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Download/Exercise/" + ExerciseFileList[i];
            StartCoroutine(DownloadExerciseFile(UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "Download/Exercise/", ExerciseFileList[i], "Download"));
        }
    }

    IEnumerator DownloadTrainingFile(string FilePath, string FileString, string ActionType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "get_download_data";
        if(ActionType == "Friends")
        {
            Action = "get_upload_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("action", Action);
        form.AddField("myform_screennametype", FileString);
        form.AddField("myform_name", FileString);
        form.AddField("myform_type", "Training");
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;

        formText = w.text.ToString();
        if (w.error != null || formText.Contains("Cant Find Download Data") || formText.Contains("Cant Find Upload Data"))
        {
            if(formText.Contains("Cant Find Download Data"))
            {
                MessageText.GetComponent<Text>().text += "Failed to Download " + FileString + "\n";
                print(w.error);
            }
        }
        else
        {
            string DownloadString = formText;
            SaveTrainingData tempTraining = new SaveTrainingData();
            tempTraining = (SaveTrainingData)DeserializeObject(DownloadString, "SaveTrainingData");

            // need to check for duplicate Trainings
            for (var k = 0; k < tempTraining.Training.Length; k++)
            {
                int foundIndex = -1;
                for (var i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training.Length; i++)
                {
                    if (UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[i].Name == tempTraining.Training[k].Name)
                    {
                        foundIndex = i;
                    }
                }
                if (foundIndex < 0)
                {
                    //add the Training
                    UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Add(tempTraining.Training[k]);
                    UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training.OrderBy(x => x.Name).ToArray();
                    UserBlobManager.GetComponent<UserBlobManager>().SaveTraining();
                    print(" downloaded " + tempTraining.Training[k].Name);
                }
                else
                {
                    // found duplicate dont add the Training
                }
            }

            if (DownloadFromFriends == true)
            {
                StartCoroutine(DeleteFile(FileString, "remove_upload_data"));
            }
        }

        DownloadCount++;
        if (DownloadFromFriends == true)
        {
            FriendTrainingFileDownloaded = true;
        }
    }

    IEnumerator DownloadWorkoutFile(string FilePath, string FileString, string ActionType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "get_download_data";
        if (ActionType == "Friends")
        {
            Action = "get_upload_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("action", Action);
        form.AddField("myform_screennametype", FileString);
        form.AddField("myform_name", FileString);
        form.AddField("myform_type", "Workout");
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;

        formText = w.text.ToString();
        if (w.error != null || formText.Contains("Cant Find Download Data") || formText.Contains("Cant Find Upload Data"))
        {
            if (formText.Contains("Cant Find Download Data"))
            {
                MessageText.GetComponent<Text>().text += "Failed to Download " + FileString + "\n";
                print(w.error);
            }
        }
        else
        {
            string DownloadString = formText;
            SaveWorkoutData tempWorkout = new SaveWorkoutData();
            tempWorkout = (SaveWorkoutData)DeserializeObject(DownloadString, "SaveWorkoutData");

            // need to check for duplicate Workouts
            for (var k = 0; k < tempWorkout.Workout.Length; k++)
            {
                int foundIndex = -1;
                for (var i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.Length; i++)
                {
                    if (UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout[i].Name == tempWorkout.Workout[k].Name)
                    {
                        foundIndex = i;
                    }
                }
                if (foundIndex < 0)
                {
                    //add the Workout
                    UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Add(tempWorkout.Workout[k]);
                    UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.OrderBy(x => x.Name).ToArray();
                    UserBlobManager.GetComponent<UserBlobManager>().SaveWorkout();
                    print(" downloaded " + tempWorkout.Workout[k].Name);
                }
                else
                {
                    // found duplicate dont add the Workout
                }
            }

            if (DownloadFromFriends == true)
            {
                StartCoroutine(DeleteFile(FileString, "remove_upload_data"));
            }
        }

        DownloadCount++;
        if (DownloadFromFriends == true)
        {
            FriendWorkoutFileDownloaded = true;
        }
    }

    IEnumerator DownloadExerciseFile(string FilePath, string FileString, string ActionType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string Action = "get_download_data";
        if (ActionType == "Friends")
        {
            Action = "get_upload_data";
        }

        WWWForm form = new WWWForm();
        form.AddField("action", Action);
        form.AddField("myform_screennametype", FileString);
        form.AddField("myform_name", FileString);
        form.AddField("myform_type", "Exercise");
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;

        formText = w.text.ToString();
        if (w.error != null || formText.Contains("Cant Find Download Data") || formText.Contains("Cant Find Upload Data"))
        {
            if (formText.Contains("Cant Find Download Data"))
            {
                MessageText.GetComponent<Text>().text += "Failed to Download " + FileString + "\n";
                print(w.error);
            }
        }
        else
        {
            string DownloadString = formText;
            SaveExerciseData tempExercise = new SaveExerciseData();
            tempExercise = (SaveExerciseData)DeserializeObject(DownloadString, "SaveExerciseData");

            // need to check for duplicate Exercises
            for (var k = 0; k < tempExercise.Exercise.Length; k++)
            {
                int foundIndex = -1;
                for (var i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise.Length; i++)
                {
                    if (UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[i].Name == tempExercise.Exercise[k].Name)
                    {
                        foundIndex = i;
                    }
                }
                if (foundIndex < 0)
                {
                    //add the Exercise
                    UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Add(tempExercise.Exercise[k]);
                    UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise.OrderBy(x => x.Name).ToArray();
                    UserBlobManager.GetComponent<UserBlobManager>().SaveExercise();
                    print(" downloaded " + tempExercise.Exercise[k].Name);
                }
                else
                {
                    // found duplicate dont add the Exercise
                }
            }

            if (DownloadFromFriends == true)
            {
                StartCoroutine(DeleteFile(FileString, "remove_upload_data"));
            }
        }

        DownloadCount++;
        if (DownloadFromFriends == true)
        {
            FriendExerciseFileDownloaded = true;
        }
    }

    IEnumerator DeleteFile(string FileString, string ActionType)
    {
        // delete the file now that its been downloaded
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash; 
        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", ActionType);
        form.AddField("myform_screennametype", FileString);
        WWW w = new WWW(URL, form);
        yield return w;

        print(w.error);
        print(w.text);
        if (w.text.Contains("HASH code is different from your app"))
        {
            print("Delete failed.");
        }
        else
        {
            print("Delete sucessful.");
        }
    }

    public void OnOkButtonPressed()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadState");
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
}
