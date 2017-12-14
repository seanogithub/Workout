using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;


public class UI_Share : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;

    public SaveFriendData UserFriendData;
    public bool UpdateFriendList = false;

    public int FriendRequestCount = 0;

    public string PopUpYesNoDialogState = "";
    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
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

        if(UpdateFriendList == true)
        {
            StartCoroutine(GetFriendList());
        }

	}


    IEnumerator GetFriendList()
    {
        UpdateFriendList = false;
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;

        WWWForm form = new WWWForm();
        form.AddField("action", "get_friend_list");
        form.AddField("myform_hash", hash);
        form.AddField("myform_screenname", formScreenName);
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
                if (formText.Contains("Cant Find Friend List Data"))
                {
                    print("No Friends Found");
                    StartCoroutine(GetFriendRequestAcceptedList());
                }
                else
                {
                    UserFriendData = (SaveFriendData)DeserializeObject(formText.ToString(), "SaveFriendData");
                    UserBlobManager.GetComponent<UserBlobManager>().UserFriendData = UserFriendData;
                    StartCoroutine(GetFriendRequestAcceptedList());
                }
            }
        }
        w.Dispose();

        StartCoroutine(GetFriendRequestList());
    }


    IEnumerator GetFriendRequestList()
    {
        FriendRequestCount = 0;
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
                if (formText.Contains("Found No friend requests"))
                {
                    print("Found No friend requests");
                }
                else
                {
                    string[] tempArray = formText.Split('#');
                    UserFriendData = new SaveFriendData();
                    for (int i = 1; i < tempArray.Length; i = i + 5) // start at 1 because the first entry is garbage.
                    {
                        if (tempArray[i] != "" && tempArray[i + 4] == "0")
                        {
                            FriendRequestCount++;
                        }
                    }
                    if(FriendRequestCount > 0)
                    {
                        if (PopUpActive == false)
                        {
                            PopUpOkDialog(("You have "+ FriendRequestCount + " friend requests.\nClick Friend Requests to Accept or Deny"), this.gameObject.GetComponent<UI_Share>(), "FriendRequestsWaiting");
                        }
                    }
                }
            }
        }
        w.Dispose();
    }

    IEnumerator GetFriendRequestAcceptedList()
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;

        WWWForm form = new WWWForm();
        form.AddField("action", "check_friend_request");
        form.AddField("myform_hash", hash);
        form.AddField("myform_ScreenName", formScreenName);
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
                if (formText.Contains("Found No friend requests"))
                {
                    print("Found No friend requests");
                }
                else
                {
                    string[] tempArray = formText.Split('#');
                    UserFriendData = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData;
                    for (int i = 1; i < tempArray.Length; i = i + 5) // start at 1 because the first entry is garbage.
                    {
                        if (tempArray[i] != "" && tempArray[i + 4] == "1")
                        {
                            FriendData tempFriend = new FriendData();
                            tempFriend.ScreenName = tempArray[i+1];
                            tempFriend.Email = tempArray[i + 2];
                            tempFriend.RequestAccepted = false;
                            if (tempArray[i + 3] == "1")
                            {
                                tempFriend.RequestAccepted = true;
                            }
                            tempFriend.RequestSent = false;
                            if (tempArray[i + 4] == "1")
                            {
                                tempFriend.RequestSent = true;
                            }
                            if(tempFriend.RequestAccepted == true)
                            {
                                // check for duplicate friends
                                if (UserBlobManager.GetComponent<UserBlobManager>().FindFriendByScreenName(tempFriend.ScreenName) < 0)
                                {
                                    UserFriendData.Add(tempFriend);
                                    UserBlobManager.GetComponent<UserBlobManager>().UserFriendData = UserFriendData;
                                    //UserBlobManager.GetComponent<UserBlobManager>().SaveFriend();
                                    StartCoroutine(SetFriendList());
                                }
                            }
                            StartCoroutine(RemoveFriendRequest());
                        }
                    }
                }
            }
        }
        w.Dispose();
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

    IEnumerator RemoveFriendRequest()
    {
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;

        WWWForm form = new WWWForm();
        form.AddField("action", "remove_friend_request");
        form.AddField("myform_hash", hash);
        form.AddField("myform_ScreenName", formScreenName);
        WWW w = new WWW(URL, form);
        yield return w;
        print(w.error);
        print(w.text);

        if (w.error != null)
        {
            // connection error
            print(w.error);

            //UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
        }
        else
        {
            print ("Friend requests removed");
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
            case "FriendRequestsWaiting":
                if (DialogState == "ok")
                {
                    print("Friend Requests Waiting");
                    //RemoveData();
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }

}
