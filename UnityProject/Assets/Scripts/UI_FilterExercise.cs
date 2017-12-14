using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_FilterExercise : MonoBehaviour {
	
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public bool Initialize = false;
	
	public GameObject ExerciseTypeScrollPanel;
	public GameObject ExerciseBodyPartScrollPanel;

	private string CurrentFilterExerciseType = "None";
	private string CurrentFilterExerciseBodyPart = "None";

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
		
		CurrentFilterExerciseType = UserBlobManager.GetComponent<UserBlobManager> ().ExerciseFilterType;
		CurrentFilterExerciseBodyPart = UserBlobManager.GetComponent<UserBlobManager> ().ExerciseFilterBodyPart;

		// Convert Body Part string to an int to a position
		int ExcerciseTypeIndex = FilterExerciseTypeStringToInt (CurrentFilterExerciseType);
		SetScrollRectPositionFromInt (ExcerciseTypeIndex, 100, UserBlobManager.GetComponent<UserBlobManager>().FilterExerciseTypeList.Count, ExerciseTypeScrollPanel);	
		
		int BodyPartIndex = FilterBodyPartStringToInt (CurrentFilterExerciseBodyPart);
		SetScrollRectPositionFromInt (BodyPartIndex, 100, UserBlobManager.GetComponent<UserBlobManager>().FilterBodyPartList.Count, ExerciseBodyPartScrollPanel);	
		
	}
	
	public void UpdateExerciseDataFromUI ()
	{
		CurrentFilterExerciseType = GetScrollRectStringFromPosition (ExerciseTypeScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().FilterExerciseTypeList.Count, UserBlobManager.GetComponent<UserBlobManager> ().FilterExerciseTypeList);
		CurrentFilterExerciseBodyPart = GetScrollRectStringFromPosition (ExerciseBodyPartScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().FilterBodyPartList.Count, UserBlobManager.GetComponent<UserBlobManager> ().FilterBodyPartList);

		UserBlobManager.GetComponent<UserBlobManager> ().ExerciseFilterType = CurrentFilterExerciseType;
		UserBlobManager.GetComponent<UserBlobManager> ().ExerciseFilterBodyPart = CurrentFilterExerciseBodyPart;
	}
	
	public void OkButtonPressed()
	{
		// copy data from UI to User Blob
		UpdateExerciseDataFromUI ();
		
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutState");
	}
	
	string GetScrollRectStringFromPosition(float myPosition, int ButtonHeight, int NumButtons, List<string> myList)
	{
		string myString = "";
		int myIndex = 0;
		float temp = (ButtonHeight * NumButtons);
		myPosition = myPosition + (ButtonHeight * NumButtons / 2);
		myIndex = (int)Mathf.Floor(myPosition / temp * (float)NumButtons);
		myString = myList[myIndex];
		return myString;
	}
	
	void SetScrollRectPositionFromInt(int myInteger, int ButtonHeight, int NumButtons, GameObject myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2); 
		myScrollPanel.transform.localPosition = tempPos;
	}
	
	public int FilterBodyPartStringToInt(string myText)
	{
		for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().FilterBodyPartList.Count; i++) 
		{
			string tempBodyPartString = UserBlobManager.GetComponent<UserBlobManager>().FilterBodyPartList[i];
			if(tempBodyPartString == myText)
			{
				return (i);
			}
		}
		return 0;
	}
	
	public int FilterExerciseTypeStringToInt(string myText)
	{
		for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().FilterExerciseTypeList.Count; i++) 
		{
			string tempExerciseTypePartString = UserBlobManager.GetComponent<UserBlobManager>().FilterExerciseTypeList[i];
			if(tempExerciseTypePartString == myText)
			{
				return (i);
			}
		}
		return 0;
	}
}
