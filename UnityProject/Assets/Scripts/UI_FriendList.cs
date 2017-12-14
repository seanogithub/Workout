using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_FriendList : MonoBehaviour {

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
	
	public int SelectedFriend = -1;
	public List<string> ShareFriendList = new List<string> ();
	
	public Color SelectedColor = Color.red;
	
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
		SelectedFriend = -1;
		//		UserBlobManager.GetComponent<UserBlobManager> ().CurrentExersiceIndex = SelectedFriend;
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
		//		FriendButtonArray[SelectedFriend].GetComponent<Image> ().color = SelectedColor;
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
}
