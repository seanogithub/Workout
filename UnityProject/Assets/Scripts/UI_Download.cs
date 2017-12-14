using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;


public class UI_Download : MonoBehaviour {

    public bool Initialize = false;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject UIDownloading;

    public bool DownloadedTrainingComplete = false;
    public bool DownloadedWorkoutComplete = false;
    public bool DownloadedExerciseComplete = false;

    // Use this for initialization
    void Start () {

    }

	
	void Awake()
    {
        UserBlobManager = GameObject.Find("UserBlob_Prefab");
        UIManager = GameObject.Find("UI_Manager_Prefab");
    }

    public void Init()
    {
        Initialize = false;
        DownloadedTrainingComplete = false;
        DownloadedWorkoutComplete = false;
        DownloadedExerciseComplete = false;
        string DownloadTrainingDataString = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadTrainingDataString;
        if (DownloadTrainingDataString == "" && DownloadedTrainingComplete == false)
        {
            StartCoroutine(GetTrainingDownloadables());
        }
        string DownloadWorkoutDataString = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadWorkoutDataString;
        if (DownloadWorkoutDataString == "" && DownloadedWorkoutComplete == false)
        {
            StartCoroutine(GetWorkoutDownloadables());
        }
        string DownloadExerciseDataString = UserBlobManager.GetComponent<UserBlobManager>().UserDownloadExerciseDataString;
        if (DownloadExerciseDataString == "" && DownloadedExerciseComplete == false)
        {
            StartCoroutine(GetExerciseDownloadables());
        }
    }

    public void OnFromFriendsButtonPressed()
    {
        UIDownloading.GetComponent<UI_Downloading>().DownloadFromFriends = true;
        UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadingState");
    }

    IEnumerator GetTrainingDownloadables()
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;

        WWWForm form = new WWWForm();
        form.AddField("action", "get_training_download_list");
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);
        }
        else
        {
            formText = w.text.ToString();
            UserBlobManager.GetComponent<UserBlobManager>().UserDownloadTrainingDataString = formText;
            //UserBlobManager.GetComponent<UserBlobManager>().SendMessage("LoadDownloadTrainingData");

            string UserDownloadTrainingDataString = formText;
            if (UserDownloadTrainingDataString.ToString() != "")
            {
                UserBlobManager.GetComponent<UserBlobManager>().UserDownloadTrainingData = (SaveDownloadTrainingData)DeserializeObject(UserDownloadTrainingDataString, "SaveDownloadTrainingData");
            }

            DownloadedTrainingComplete = true;
            print("Training downloaded");
        }
    }

    IEnumerator GetWorkoutDownloadables()
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;

        WWWForm form = new WWWForm();
        form.AddField("action", "get_workout_download_list");
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);
        }
        else
        {
            formText = w.text.ToString();
            UserBlobManager.GetComponent<UserBlobManager>().UserDownloadWorkoutDataString = formText;
            //UserBlobManager.GetComponent<UserBlobManager>().SendMessage("LoadDownloadWorkoutData");

            string UserDownloadWorkoutDataString = formText;
            if (UserDownloadWorkoutDataString.ToString() != "")
            {
                UserBlobManager.GetComponent<UserBlobManager>().UserDownloadWorkoutData = (SaveDownloadWorkoutData)DeserializeObject(UserDownloadWorkoutDataString, "SaveDownloadWorkoutData");
            }

            DownloadedWorkoutComplete = true;
            print("Workout downloaded");
        }
    }

    IEnumerator GetExerciseDownloadables()
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;

        WWWForm form = new WWWForm();
        form.AddField("action", "get_exercise_download_list");
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);
        }
        else
        {
            formText = w.text.ToString();
            UserBlobManager.GetComponent<UserBlobManager>().UserDownloadExerciseDataString = formText;
            //UserBlobManager.GetComponent<UserBlobManager>().SendMessage("LoadDownloadExerciseData");

            string UserDownloadExerciseDataString = formText;
            if (UserDownloadExerciseDataString.ToString() != "")
            {
                UserBlobManager.GetComponent<UserBlobManager>().UserDownloadExerciseData = (SaveDownloadExerciseData)DeserializeObject(UserDownloadExerciseDataString, "SaveDownloadExerciseData");
            }

            DownloadedExerciseComplete = true;
            print("Exercise downloaded");
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Initialize)
        {
            Init();
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
