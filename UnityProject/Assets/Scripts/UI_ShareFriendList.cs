using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;


public class UI_ShareFriendList : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIUploading;
	public GameObject FriendButton;
	
	public SaveFriendData UserFriendData;

	public FriendData item = new FriendData();
	
	public List<GameObject> FriendButtonArray = new List<GameObject>();
	
	public Transform FriendContentPanel;
	public GameObject FriendContentPanelScrollBar;
	public bool ScrollBarMove = false;
	
	public int SelectedFriend = -1;
	public List<string> ShareFriendList = new List<string> ();
	
	public Color SelectedColor = Color.red;
	
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
		ShareFriendList = new List<string> ();
		SelectedFriend = -1;
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
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.ScreenName;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Email;
			string selectedButton = item.ScreenName;
			newButton.GetComponent<Button>().onClick.AddListener(() => FriendButtonClicked(selectedButton));
			newButton.transform.SetParent (FriendContentPanel);
		}
	}
	
	public void FriendButtonClicked(string myText)
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindFriendByScreenName (myText);
		SelectedFriend = myIndex;
		
		bool sel = false;
		foreach (var item in ShareFriendList) 
		{
			if (item == myText)
			{
				sel = true;
			}
		}
		if (sel) 
		{
			// remove from list
			ShareFriendList.Remove(myText);
			UserBlobManager.GetComponent<UserBlobManager> ().ShareFriendList = ShareFriendList;
			FriendButtonArray[SelectedFriend].GetComponent<Image> ().color = Color.white;
		}
		else
		{
			ShareFriendList.Add(myText);
			UserBlobManager.GetComponent<UserBlobManager> ().ShareFriendList = ShareFriendList;
			FriendButtonArray[SelectedFriend].GetComponent<Image> ().color = SelectedColor;
		}
	}

	public void OnSendToButtonClicked()
	{
        if (ShareFriendList.Count > 0)
		{
            // new stuff
            UIUploading.GetComponent<UI_Uploading>().FriendList = ShareFriendList;
            UIManager.GetComponent<UI_Manager>().SwitchStates("UploadingState");
        }
        else
		{
            // no friends selected
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
