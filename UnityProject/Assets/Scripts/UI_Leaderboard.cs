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

public class UI_Leaderboard : MonoBehaviour {

    public bool Initialize = false;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject LeaderboardButton;
    public GameObject WaitAnimationImage;

    public string LeaderboardTextString = "";
    public List<string> FriendScreenName = new List<string>();
    public List<int> FriendTotalWorkoutScore = new List<int>();
    public List<int> FriendDayWorkoutScore = new List<int>();

    public int NumberOfFriendsDownloaded = 0;
    public bool DownloadComplete = false;

    public List<GameObject> LeaderboardButtonArray = new List<GameObject>();

    public Transform LeaderboardContentPanel;
    public GameObject LeaderboardContentPanelScrollBar;
    public bool ScrollBarMove = false;

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

        LeaderboardTextString = "";
        NumberOfFriendsDownloaded = 0;
        FriendScreenName = new List<string>();
        FriendTotalWorkoutScore = new List<int>();
        FriendDayWorkoutScore = new List<int>();
        DownloadComplete = true;
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

        // get friends workout complete data
        if (NumberOfFriendsDownloaded < UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length)
        {
            if(DownloadComplete == true)
            {
                DownloadComplete = false;
                FriendScreenName.Add(UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend[NumberOfFriendsDownloaded].ScreenName);
                FriendTotalWorkoutScore.Add(0);
                FriendDayWorkoutScore.Add(0);
                StartCoroutine(GetWorkoutCompleteFile(UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend[NumberOfFriendsDownloaded].ScreenName, NumberOfFriendsDownloaded));
            }
        }

        // get your workout complete data
        if (NumberOfFriendsDownloaded == UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length)
        {
            if (DownloadComplete == true)
            {
                DownloadComplete = false;
                FriendScreenName.Add(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin);
                FriendTotalWorkoutScore.Add(0);
                FriendDayWorkoutScore.Add(0);
                StartCoroutine(GetWorkoutCompleteFile(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin, (UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length)));
            }
        }

        // create text string
        if (NumberOfFriendsDownloaded > UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length)
        {
            CreateLeaderboardText();
            WaitAnimationTimer.Stop();
            WaitAnimationImage.SetActive(false);
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

    public void ClearScrollList()
    {
        for (int i = LeaderboardContentPanel.childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(LeaderboardContentPanel.GetChild(i).gameObject);
        }
    }

    public void PopulateScrollList()
    {
        LeaderboardButtonArray.Clear();

        for (int i = 0; i < FriendScreenName.Count; i++)
        {
            GameObject newButton = Instantiate(LeaderboardButton) as GameObject;
            LeaderboardButtonArray.Add(newButton);
            newButton.name = ("Button_" + FriendScreenName[i]);
            newButton.transform.Find("Text_Place").GetComponent<Text>().text = (i+1).ToString();
            newButton.transform.Find("Text_Name").GetComponent<Text>().text = FriendScreenName[i];
            newButton.transform.Find("Text_Type").GetComponent<Text>().text = FriendTotalWorkoutScore[i].ToString();
            newButton.transform.Find("Text_Time").GetComponent<Text>().text = "0";
            newButton.transform.SetParent(LeaderboardContentPanel);
        }
    }

    public void CreateLeaderboardText()
    {
        LeaderboardTextString = "";

        // sort
        SortLeaderboard();

        // add to panel
        ClearScrollList();
        PopulateScrollList();
    }

    public void SortLeaderboard()
    {
        for (int iterator = 0; iterator < FriendTotalWorkoutScore.Count; iterator++)
        {
            for (int index = 0; index < FriendTotalWorkoutScore.Count - 1; index++)
            {
                if (FriendTotalWorkoutScore[index] < FriendTotalWorkoutScore[index + 1])
                {
                    //Swap(ref FriendTotalWorkoutScore[index], ref FriendTotalWorkoutScore[index + 1]);
                    int tempTotalWorkoutScore = FriendTotalWorkoutScore[index];
                    int tempDayWorkoutScore = FriendDayWorkoutScore[index];
                    string tempFriendScreenName = FriendScreenName[index];

                    FriendTotalWorkoutScore[index] = FriendTotalWorkoutScore[index + 1];
                    FriendDayWorkoutScore[index] = FriendDayWorkoutScore[index + 1];
                    FriendScreenName[index] = FriendScreenName[index + 1];

                    FriendTotalWorkoutScore[index+1] = tempTotalWorkoutScore;
                    FriendDayWorkoutScore[index+1] = tempDayWorkoutScore;
                    FriendScreenName[index+1] = tempFriendScreenName;
                }
            }
        }
    }

    public void CalculateTotalWorkoutScore(string DownloadString, int FriendIndex)
    {
        int TotalWorkoutScore = 0;
        int DayWorkoutScore = 0;
        // deserialize the day data
        SaveDayData tempDayData = new SaveDayData();
        tempDayData = (SaveDayData)DeserializeObject(DownloadString, "SaveDayData");

        // add up the score
        for(int d = 0; d < tempDayData.Day.Length; d++)
        {
            for(int i = 0; i < tempDayData.Day[d].DayWorkoutArray.Length; i++)
            {
                //only add the score if its less than a week from next sunday
                System.DateTime Today = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
                System.DateTime PrevSunday = Today.AddDays(-1 * (int)Today.DayOfWeek);
                int result = System.DateTime.Compare(PrevSunday, tempDayData.Day[d].Day);
                if(result <= 0)
                {
                    TotalWorkoutScore += tempDayData.Day[d].DayWorkoutArray[i].WorkoutScore;
                }
            }

            // calculate day workout score for today
            if(tempDayData.Day[d].Day.Day == System.DateTime.Now.Day)
            {
                for (int i = 0; i < tempDayData.Day[d].DayWorkoutArray.Length; i++)
                {
                    DayWorkoutScore += tempDayData.Day[d].DayWorkoutArray[i].WorkoutScore;
                }
            }
        }
        FriendTotalWorkoutScore[FriendIndex] = TotalWorkoutScore;
        FriendDayWorkoutScore[FriendIndex] = DayWorkoutScore;
        DownloadComplete = true;
    }

    public void AddNoWorkoutScore(string DownloadString, int FriendIndex)
    {
        FriendTotalWorkoutScore[FriendIndex] = 0;
        FriendDayWorkoutScore[FriendIndex] = 0;
        DownloadComplete = true;
    }

    IEnumerator GetWorkoutCompleteFile(string ScreenName, int FriendIndex)
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
                    CalculateTotalWorkoutScore(formText, FriendIndex);
                }
                else
                {
                    AddNoWorkoutScore(formText, FriendIndex);
                }
                NumberOfFriendsDownloaded++;
            }
        }
        w.Dispose();
    }

    public void OnBackButtonPressed()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
    }


    /* The following methods came from the referenced URL */
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
