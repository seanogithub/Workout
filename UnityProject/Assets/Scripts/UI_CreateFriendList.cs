using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using System.Text;

public class UI_CreateFriendList : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
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

    public string PopUpYesNoDialogState = "";
    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
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
		SelectedFriend = 0;
		UserBlobManager.GetComponent<UserBlobManager> ().CurrentFriendIndex = SelectedFriend;
		ClearScrollList ();
		PopulateScrollList ();
		
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserFriendData.Friend.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserFriendData.Friend.Length, FriendContentPanel);
		}
		else
		{
			FriendContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}
	
	public void ClearScrollList()
	{
		for (int i = FriendContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(FriendContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateScrollList () 
	{
		FriendButtonArray.Clear ();
		foreach (var item in UserFriendData.Friend)
		{
			GameObject newButton = Instantiate (FriendButton) as GameObject;
			FriendButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.ScreenName);
			//			string tempText = item.Name;
			//			if(item.Weight > 0) {tempText += ("-" + item.Weight + "lbs");}
			//			if(item.Reps > 0) {tempText += ("-" + item.Reps + "reps");}
			//			newButton.GetComponentInChildren<Text>().text = tempText;
			//			newButton.GetComponentInChildren<Text>().fontSize = 50;
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.ScreenName;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Email;
			string selectedButton = item.ScreenName;
			newButton.GetComponent<Button>().onClick.AddListener(() => FriendButtonClicked(selectedButton));
			newButton.transform.SetParent (FriendContentPanel);
		}
		if(FriendButtonArray.Count > 0)
		{
			FriendButtonArray[SelectedFriend].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void FriendButtonClicked(string myText)
	{
		FriendButtonArray[SelectedFriend].GetComponent<Image> ().color = Color.white;
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindFriendByScreenName (myText);
		SelectedFriend = myIndex;
		UserBlobManager.GetComponent<UserBlobManager> ().CurrentFriendIndex = myIndex;
		FriendButtonArray[SelectedFriend].GetComponent<Image> ().color = SelectedColor;
	}
	
    public void DeleteButtonPressed()
    {
        if (PopUpActive == false)
        {
            PopUpYesNoDialog("Are you sure you want to delete this friend?", this.gameObject.GetComponent<UI_CreateFriendList>(), "DeleteFriend");
        }
    }

    public void DeleteFriend()
	{
        int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().CurrentFriendIndex;
		if(myIndex < UserBlobManager.GetComponent<UserBlobManager> ().UserFriendData.Friend.Length)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserFriendData.RemoveAt(myIndex);
			UserFriendData = UserBlobManager.GetComponent<UserBlobManager>().UserFriendData;
			//UserBlobManager.GetComponent<UserBlobManager> ().SaveFriend();
			if(myIndex >= UserFriendData.Friend.Length)
			{
				myIndex = UserFriendData.Friend.Length - 1;
				UserBlobManager.GetComponent<UserBlobManager> ().CurrentFriendIndex = myIndex;
			}
            StartCoroutine(SetFriendList());
            SelectedFriend = myIndex;
			ClearScrollList ();
			PopulateScrollList ();
		}
	}
	
	public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserFriendData.Friend.Length;
			float ScrollPercentage =  FriendContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserFriendData.Friend.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
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
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserFriendData.Friend.Length;
		float ScrollValue =  ((FriendContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		FriendContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		myScrollPanel.localPosition = tempPos;
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


    void PopUpYesNoDialog(string myMessage, Component mySender, string myState)
    {
        var temp = Resources.Load("UI/UI_PopUpYesNoDialogBox_Prefab") as GameObject;
        var myPopUpYesNo = GameObject.Instantiate(temp, (new Vector3(0.0f, 0.0f, 1.0f)), Quaternion.identity) as GameObject;
        myPopUpYesNo.GetComponent<UI_PopUpYesNoDialogBox>().Sender = mySender;
        myPopUpYesNo.GetComponent<UI_PopUpYesNoDialogBox>().TextMessage.GetComponent<Text>().text = myMessage;
        myPopUpYesNo.SetActive(true);
        PopUpYesNoDialogState = myState;
        PopUpActive = true;
    }

    public void YesNoDialog(string DialogState)
    {
        switch (PopUpYesNoDialogState)
        {
            case "DeleteFriend":
                if (DialogState == "ok")
                {
                    print("DeleteDailyData ok");
                    DeleteFriend();
                }
                if (DialogState == "cancel")
                {
                    print("DeleteDailyData cancel");
                }
                break;
        }
        PopUpYesNoDialogState = "";
        PopUpActive = false;
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
            case "WrongScreenNamePassword":
                if (DialogState == "ok")
                {
                    print("DeleteDailyData ok");
                    //RemoveData();
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }
}
