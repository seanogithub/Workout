using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class UI_NewFriend : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;

//	public List<FriendData> UserFriendData = new List<FriendData>();	
	public SaveFriendData UserFriendData;
	public List<GameObject> FriendButtonArray = new List<GameObject>();
	public GameObject TextScreenName;
	public GameObject TextEmail;

    public bool FriendFound;
    public string FriendName;
    public string FriendEmail;

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
		UserFriendData = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData;
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
		UserFriendData = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData;
        FriendName = "";
        FriendEmail = "";
        TextScreenName.GetComponent<InputField>().text = "";
        TextEmail.GetComponent<InputField>().text = "";
    }

	public void OnFindButtonClicked()
	{
        FriendName = "";
        FriendEmail = "";
        string SearchName = TextScreenName.GetComponent<InputField>().text.ToLower();
        string SearchEmail = TextEmail.GetComponent<InputField>().text.ToLower();
        if (SearchName == null)
        {
            SearchName = "";
        }

        if (SearchEmail == null)
        {
            SearchEmail = "";
        }

        if (SearchName != "" || SearchEmail != "")
        {
            if (SearchName == UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin.ToLower() ||
                SearchEmail == UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserEmail.ToLower())
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Can't add yourself to the friend list", this.gameObject.GetComponent<UI_NewFriend>(), "Can Not Connect");
                }
            }
            else
            {
                StartCoroutine(FindFriends(TextScreenName.GetComponent<InputField>().text, TextEmail.GetComponent<InputField>().text));
            }
        }
        else
        {
            if (PopUpActive == false)
            {
                PopUpOkDialog("Please enter either a screen name or an email", this.gameObject.GetComponent<UI_NewFriend>(), "Can Not Connect");
            }
        }
    }

    IEnumerator FindFriends(string formScreenName, string formEmail)
    {
        //UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");

        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string myScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string myEmail = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserEmail;
        string dateString = System.DateTime.Now.Year.ToString("D4");
        dateString += System.DateTime.Now.Month.ToString("D2");
        dateString += System.DateTime.Now.Day.ToString("D2");

        WWWForm form = new WWWForm();
        form.AddField("action", "find_friends");
        form.AddField("myform_hash", hash);
        form.AddField("myform_ScreenName", formScreenName);
        form.AddField("myform_Email", formEmail);
        form.AddField("myform_myScreenName", myScreenName);
        form.AddField("myform_myEmail", myEmail);
        form.AddField("myform_date", dateString);

        WWW w = new WWW(URL, form);
        yield return w;
        print(w.error);
        print(w.text);

        if (w.error != null)
        {
            // connection error
            print(w.error);

            if (w.error.Contains("Could not resolve host"))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Can NOT connect to server.\nPlease check your internet connection.", this.gameObject.GetComponent<UI_Login>(), "Can Not Connect");
                }
            }
        }
        else
        {
            formText = w.text;
            print(formText);
            w.Dispose();

            if (formText.Contains("HASH code is different from your app"))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Can NOT connect to server.", this.gameObject.GetComponent<UI_Login>(), "Can Not Connect");
                }
            }
            else
            {
                if (formText.Contains("Not Found!"))
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog("User Not found!", this.gameObject.GetComponent<UI_NewFriend>(), "Can Not Connect");
                    }
                }

                if (formText.Contains("Screen name found"))
                {
                    int emailStart = formText.IndexOf("Email=") + 6;
                    int emailEnd = formText.IndexOf("#");
                    string email = formText.Substring(emailStart, (emailEnd - emailStart)); // get exact email from database
                    FriendName = formText.Substring(formText.IndexOf("ScreenName=") + 11);
                    FriendEmail = email;

                    // check for duplicate friends
                    if (UserBlobManager.GetComponent<UserBlobManager>().FindFriendByScreenName(FriendName) < 0)
                    {
                        if (PopUpActive == false)
                        {
                            PopUpOkDialog(("Found " + FriendName + "\nSending Friend Request"), this.gameObject.GetComponent<UI_NewFriend>(), "Found Friend");
                        }
                    }
                    else
                    {
                        if (PopUpActive == false)
                        {
                            PopUpOkDialog((FriendName + " is already in the friend list"), this.gameObject.GetComponent<UI_NewFriend>(), "Can Not Connect");
                        }
                    }
                    print("Screen name found");
                }
                if (formText.Contains("Email found"))
                {
                    int nameStart = formText.IndexOf("ScreenName=") + 11;
                    int nameEnd = formText.IndexOf("#");
                    string name = formText.Substring(nameStart, (nameEnd - nameStart)); // get exact name from database
                    FriendName = name;
                    FriendEmail = formText.Substring(formText.IndexOf("Email=") + 6);

                    // check for duplicate friends
                    if (UserBlobManager.GetComponent<UserBlobManager>().FindFriendByScreenName(FriendName) < 0)
                    {
                        if (PopUpActive == false)
                        {
                            PopUpOkDialog(("Found " + FriendName), this.gameObject.GetComponent<UI_NewFriend>(), "Found Friend");
                        }
                    }
                    else
                    {
                        if (PopUpActive == false)
                        {
                            PopUpOkDialog((FriendName + " already in the list"), this.gameObject.GetComponent<UI_NewFriend>(), "Can Not Connect");
                        }
                    }
                    print("Email found");

                }
            }
        }
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
            case "Can Not Connect":
                if (DialogState == "ok")
                {
                    print("ok");
                }
                break;
            case "Found Friend":
                if (DialogState == "ok")
                {
                    print("ok");
                    UIManager.GetComponent<UI_Manager>().SwitchStates("CreateFriendListState");
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }
}

