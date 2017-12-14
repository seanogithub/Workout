using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class UI_FriendRequestList : MonoBehaviour {

    public bool Initialize = false;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject FriendButton;

    //	public List<FriendData> UserFriendData = new List<FriendData>();	
    public SaveFriendData UserFriendData;
    public FriendData item = new FriendData();

    public List<GameObject> FriendButtonArray = new List<GameObject>();

    public Transform FriendContentPanel;
    public GameObject FriendContentPanelScrollBar;
    public bool ScrollBarMove = false;

    public int SelectedFriend = 0;

    public Color SelectedColor = Color.red;

    void Awake()
    {
        UserBlobManager = GameObject.Find("UserBlob_Prefab");
        UIManager = GameObject.Find("UI_Manager_Prefab");
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Initialize)
        {
            Init();
        }
    }

    public void Init()
    {
        Initialize = false;
        //UserFriendData = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData;
        UserFriendData = new SaveFriendData();
        SelectedFriend = 0;
        UserBlobManager.GetComponent<UserBlobManager>().CurrentFriendIndex = SelectedFriend;
        ClearScrollList();
        //PopulateScrollList();
/*
        if (UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length > 6)
        {
            SetScrollRectPositionFromIntWithOffset(0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length, FriendContentPanel);
        }
        else
        {
            FriendContentPanel.localPosition = new Vector3(0, 0, 0);
        }
*/
    }

    public void ClearScrollList()
    {
        for (int i = FriendContentPanel.childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(FriendContentPanel.GetChild(i).gameObject);
        }

        // download friend requests from server
        StartCoroutine(GetFriendRequestList());
    }

    public void PopulateScrollList()
    {
        // populate scroll list

        FriendButtonArray.Clear();
        foreach (var item in UserFriendData.Friend)
        {
            GameObject newButton = Instantiate(FriendButton) as GameObject;
            FriendButtonArray.Add(newButton);
            newButton.name = ("Button_" + item.ScreenName);
            newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.ScreenName;
            newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Email;
            string selectedButton = item.ScreenName;
            newButton.GetComponent<Button>().onClick.AddListener(() => FriendButtonClicked(selectedButton));
            newButton.transform.SetParent(FriendContentPanel);
        }
        if (FriendButtonArray.Count > 0)
        {
            FriendButtonArray[SelectedFriend].GetComponent<Image>().color = SelectedColor;
        }
    }

    public void FriendButtonClicked(string myText)
    {
        FriendButtonArray[SelectedFriend].GetComponent<Image>().color = Color.white;
        int myIndex = FindFriendByScreenName(myText);
        SelectedFriend = myIndex;
        //UserBlobManager.GetComponent<UserBlobManager>().CurrentFriendIndex = myIndex;
        FriendButtonArray[SelectedFriend].GetComponent<Image>().color = SelectedColor;
    }

    public void AcceptFriend()
    {
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string tempFromScreenName = UserFriendData.Friend[SelectedFriend].ScreenName;

        FriendData tempFriend = new FriendData();
        tempFriend.ScreenName = UserFriendData.Friend[SelectedFriend].ScreenName;
        tempFriend.Email = UserFriendData.Friend[SelectedFriend].Email;
        tempFriend.RequestAccepted = true;
        tempFriend.RequestSent = true;

        // check for duplicates
        bool FoundDuplicateFriend = false;
        for(int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length; i++)
        {
            if(UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend[i].ScreenName == tempFriend.ScreenName)
            {
                FoundDuplicateFriend = true;
            }
        }
        if(FoundDuplicateFriend == false)
        {
            UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Add(tempFriend);
            //UserBlobManager.GetComponent<UserBlobManager>().SaveFriend();
            StartCoroutine(SetFriendList());
        }


        StartCoroutine(SetFriendRequestList(formScreenName, tempFromScreenName, "1", "1"));
    }

    public void DenyFriend()
    {
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string tempFromScreenName = UserFriendData.Friend[SelectedFriend].ScreenName;

        StartCoroutine(SetFriendRequestList(formScreenName, tempFromScreenName, "0", "1"));
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

    IEnumerator SetFriendList()
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string xml = SerializeObject(UserBlobManager.GetComponent<UserBlobManager>().UserFriendData, "SaveFriendData");
        int index = xml.IndexOf(System.Environment.NewLine);
        xml = xml.Substring(index + System.Environment.NewLine.Length);

        string date = System.DateTime.Now.Year.ToString("D4");
        date += System.DateTime.Now.Month.ToString("D2");
        date += System.DateTime.Now.Day.ToString("D2");

        WWWForm form = new WWWForm();
        form.AddField("action", "set_friend_list");
        form.AddField("myform_hash", hash);
        form.AddField("myform_screenname", formScreenName);
        form.AddField("myform_xml", xml);
        form.AddField("myform_date", date);

        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);
        }
        else
        {
            formText = w.text;
            if (formText.Contains("HASH code is different from your app"))
            {
                print("Can't connect");
                w.Dispose();
            }
            else
            {
                if (formText.Contains("Upload OK"))
                {
                    print("Friend List Updated");
                }
                else
                {
                    print("Update Failed");
                }
            }
        }
        w.Dispose();
    }

    IEnumerator GetFriendRequestList()
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;

        WWWForm form = new WWWForm();
        form.AddField("action", "get_friend_request");
        form.AddField("myform_hash", hash);
        form.AddField("myform_ScreenName", formScreenName);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);

            //UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
        }
        else
        {
            formText = w.text;
            print(formText);

            if (formText.Contains("HASH code is different from your app"))
            {
                print("Can't connect");
                w.Dispose();
            }
            else
            {
                if(formText.Contains("Found No friend requests"))
                {
                    print("Found No friend requests");
                }
                else
                {
                    string[] tempArray = formText.Split('#');
                    UserFriendData = new SaveFriendData();
                    for (int i = 1; i < tempArray.Length; i=i+5) // start at 1 because the first entry is garbage.
                    {
                        if(tempArray[i] != "" && tempArray[i + 4] == "0")
                        {
                            FriendData tempFriend = new FriendData();
                            tempFriend.ScreenName = tempArray[i];
                            tempFriend.Email = tempArray[i + 2];
                            tempFriend.RequestAccepted = false;
                            if (tempArray[i + 3] == "1")
                            {
                                tempFriend.RequestAccepted = true;
                            }
                            tempFriend.RequestSent = false;
                            if (tempArray[i + 4] == "1")
                            {
                                tempFriend.RequestAccepted = true;
                            }

                            UserFriendData.Add(tempFriend);
                        }
                    }

                    PopulateScrollList();
                    if (UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length > 6)
                    {
                        SetScrollRectPositionFromIntWithOffset(0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length, FriendContentPanel);
                    }
                    else
                    {
                        FriendContentPanel.localPosition = new Vector3(0, 0, 0);
                    }
                }
            }
        }
        w.Dispose();
    }


    IEnumerator SetFriendRequestList(string ScreenName, string FromScreenName, string Accepted, string Responded)
    {
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;

        WWWForm form = new WWWForm();
        form.AddField("action", "set_friend_request");
        form.AddField("myform_hash", hash);
        form.AddField("myform_ScreenName", formScreenName);
        form.AddField("myform_FromScreenName", FromScreenName);
        form.AddField("myform_Accepted", Accepted);
        form.AddField("myform_Responded", Responded);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);

            //UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
        }
        else
        {
            print(w.text);
            ClearScrollList();
        }
    }

    public void OnScrollBarChanged()
    {
        if (ScrollBarMove == true)
        {
            int ButtonHeight = 200;
            double ButtonOffset = 2.5;
            int NumButtons = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length;
            float ScrollPercentage = FriendContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length - 6);
            Vector3 tempPos = new Vector3(0, 0, 0);
            tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight));
            FriendContentPanel.localPosition = tempPos;
        }
        ScrollBarMove = true;
    }

    public void OnPanelValueChanged()
    {
        ScrollBarMove = false;
        int ButtonHeight = 200;
        //		double ButtonOffset = 2.8;
        int NumButtons = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData.Friend.Length;
        float ScrollValue = ((FriendContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
        FriendContentPanelScrollBar.GetComponent<Scrollbar>().value = ScrollValue;
    }

    void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
    {
        Vector3 tempPos = new Vector3(0, 0, 0);
        tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight));
        myScrollPanel.localPosition = tempPos;
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
}
