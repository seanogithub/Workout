using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_EditExercise : MonoBehaviour {

	public GameObject UserBlobManager;
	public GameObject UIManager;
	public bool Initialize = false;

	public GameObject TextName;
	public GameObject ExerciseTypeScrollPanel;
	public GameObject ExerciseBodyPartScrollPanel;
	public GameObject ExerciseWeightOnesScrollPanel;
	public GameObject ExerciseWeightTensScrollPanel;
	public GameObject ExerciseWeightHundredsScrollPanel;
	public GameObject ExerciseRepsOnesScrollPanel;
	public GameObject ExerciseRepsTensScrollPanel;
	public GameObject ExerciseTimeOnesScrollPanel;
	public GameObject ExerciseTimeTensScrollPanel;
	public GameObject ExerciseTimeHundredsScrollPanel;
	public GameObject ExerciseTimeThousandsScrollPanel;
	public GameObject ExerciseTimeTenThousandsScrollPanel;
/*
	public GameObject ExerciseRestTimeOnesScrollPanel;
	public GameObject ExerciseRestTimeTensScrollPanel;
	public GameObject ExerciseRestTimeHundredsScrollPanel;
	public GameObject ExerciseRestTimeThousandsScrollPanel;
*/
	public GameObject ExerciseSideScrollPanel;
	public GameObject ExerciseCountDownAtStartScrollPanel;

	private string CurrentExerciseName = "";
	private string CurrentExerciseDescription = "";
	private string CurrentExerciseType = "";
	private string CurrentExerciseBodyPart = "";
	private int CurrentExerciseWeight = 0;
	private int CurrentExerciseReps = 0;
	private int CurrentExerciseTime = 0;
	private int CurrentExerciseRestTime = 0;
	private string CurrentExerciseSide = "None";
	private bool CurrentExerciseCountDownAtStart = true;
	private int CurrentExcerciseNumAnimationFrames = -1;

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

		int CurrentExerciseIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex;

		CurrentExerciseName = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].Name;
		CurrentExerciseDescription = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].Description;
		CurrentExerciseType = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].Type;
		CurrentExerciseBodyPart = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].BodyPart;
		CurrentExerciseWeight = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].Weight;
		CurrentExerciseReps = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].Reps;
		CurrentExerciseTime = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].Time;
		CurrentExerciseRestTime = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].RestTime;
		CurrentExerciseSide = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].Side;
		CurrentExerciseCountDownAtStart = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].CountDownAtStart;
		CurrentExcerciseNumAnimationFrames = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[CurrentExerciseIndex].NumAnimationFrames;

		TextName.GetComponent<Text>().text = CurrentExerciseName;

		// Convert Body Part string to an int to a position
		int ExcerciseTypeIndex = ExerciseTypeStringToInt (CurrentExerciseType);
		SetScrollRectPositionFromInt (ExcerciseTypeIndex, 100, UserBlobManager.GetComponent<UserBlobManager>().ExerciseTypeList.Count, ExerciseTypeScrollPanel);	

		int BodyPartIndex = BodyPartStringToInt (CurrentExerciseBodyPart);
		SetScrollRectPositionFromInt (BodyPartIndex, 100, UserBlobManager.GetComponent<UserBlobManager>().BodyPartList.Count, ExerciseBodyPartScrollPanel);	

		// Convert Weight Ones to scroll rect
		int ExcerciseWeightOnes = 0;
		if (CurrentExerciseWeight > 0) 
		{
			ExcerciseWeightOnes = (int)(CurrentExerciseWeight.ToString () [CurrentExerciseWeight.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseWeightOnes, 100, 10, ExerciseWeightOnesScrollPanel);

		// Convert Weight Tens to scroll rect
		int ExcerciseWeightTens = 0;
		if (CurrentExerciseWeight >= 10) 
		{
			ExcerciseWeightTens = (int)(CurrentExerciseWeight.ToString () [CurrentExerciseWeight.ToString ().Length - 2]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseWeightTens, 100, 10, ExerciseWeightTensScrollPanel);

		// Convert Weight Tens to scroll rect
		int ExcerciseWeightHundreds = 0;
		if (CurrentExerciseWeight >= 100) 
		{
			ExcerciseWeightHundreds = (int)(CurrentExerciseWeight.ToString () [CurrentExerciseWeight.ToString ().Length - 3]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseWeightHundreds, 100, 10, ExerciseWeightHundredsScrollPanel);

		// Convert reps Ones to scroll rect
		int ExcerciseRepsOnes = 0;
		if (CurrentExerciseReps > 0) 
		{
			ExcerciseRepsOnes = (int)(CurrentExerciseReps.ToString () [CurrentExerciseReps.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRepsOnes, 100, 10, ExerciseRepsOnesScrollPanel);
		
		// Convert reps Tens to scroll rect
		int ExcerciseRepsTens = 0;
		if (CurrentExerciseReps >= 10) 
		{
			ExcerciseRepsTens = (int)(CurrentExerciseReps.ToString () [CurrentExerciseReps.ToString ().Length - 2]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRepsTens, 100, 10, ExerciseRepsTensScrollPanel);

		// Convert time Ones to scroll rect
		int ExcerciseTimeOnes = 0;
		if (CurrentExerciseTime > 0) 
		{
			ExcerciseTimeOnes = (int)(CurrentExerciseTime.ToString () [CurrentExerciseTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeOnes, 100, 10, ExerciseTimeOnesScrollPanel);

		// Convert time tens to scroll rect
		int ExcerciseTimeTens = 0;
		if (CurrentExerciseTime >= 10) 
		{
			int tempTime = CurrentExerciseTime % 60;
			tempTime = tempTime / 10;
			ExcerciseTimeTens = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeTens, 100, 6, ExerciseTimeTensScrollPanel);

		// Convert time hundreds to scroll rect
		int ExcerciseTimeHundreds = 0;
		if (CurrentExerciseTime >= 60) 
		{
			int tempTime = CurrentExerciseTime/60;
			ExcerciseTimeHundreds = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeHundreds, 100, 10, ExerciseTimeHundredsScrollPanel);

		// Convert time thousands to scroll rect
		int ExcerciseTimeThousands = 0;
		if (CurrentExerciseTime >= 600) 
		{
			int tempTime = CurrentExerciseTime/600;
			ExcerciseTimeThousands = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeThousands, 100, 10, ExerciseTimeThousandsScrollPanel);

		// Convert time ten thousands to scroll rect
		int ExcerciseTimeTenThousands = 0;
		if (CurrentExerciseTime >= 3600) 
		{
			int tempTime = CurrentExerciseTime/3600;
			ExcerciseTimeTenThousands = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeTenThousands, 100, 10, ExerciseTimeTenThousandsScrollPanel);

		// Convert exercise count down to scroll rect		
		int SideIndex = SideStringToInt (CurrentExerciseSide);
		SetScrollRectPositionFromInt (SideIndex, 100, UserBlobManager.GetComponent<UserBlobManager>().BodySide.Count, ExerciseSideScrollPanel);	

		// Convert exercise count down to scroll rect
		int ExcerciseCountDownAtStartInt = 1;
		if (CurrentExerciseCountDownAtStart)
		{
			ExcerciseCountDownAtStartInt = 0;
		}
		SetScrollRectPositionFromInt (ExcerciseCountDownAtStartInt, 100, 2, ExerciseCountDownAtStartScrollPanel);
	}

	public void UpdateExerciseDataFromUI ()
	{
		CurrentExerciseName = TextName.GetComponent<Text>().text;

		CurrentExerciseType = GetScrollRectStringFromPosition (ExerciseTypeScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().ExerciseTypeList.Count, UserBlobManager.GetComponent<UserBlobManager> ().ExerciseTypeList);
		CurrentExerciseBodyPart = GetScrollRectStringFromPosition (ExerciseBodyPartScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().BodyPartList.Count, UserBlobManager.GetComponent<UserBlobManager> ().BodyPartList);

		int ExerciseWeightOnes = GetScrollRectIntFromPosition (ExerciseWeightOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseWeightTens = GetScrollRectIntFromPosition (ExerciseWeightTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseWeightHundreds = GetScrollRectIntFromPosition (ExerciseWeightHundredsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		CurrentExerciseWeight = (ExerciseWeightHundreds * 100) + (ExerciseWeightTens * 10) + (ExerciseWeightOnes);

		int ExerciseRepsOnes = GetScrollRectIntFromPosition (ExerciseRepsOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseRepsTens = GetScrollRectIntFromPosition (ExerciseRepsTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		CurrentExerciseReps = (ExerciseRepsTens * 10) + (ExerciseRepsOnes);

		int ExerciseTimeOnes = GetScrollRectIntFromPosition (ExerciseTimeOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseTimeTens = GetScrollRectIntFromPosition (ExerciseTimeTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberListToFive.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberListToFive);
		int ExerciseTimeHundreds = GetScrollRectIntFromPosition (ExerciseTimeHundredsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseTimeThousands = GetScrollRectIntFromPosition (ExerciseTimeThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseTimeTenThousands = GetScrollRectIntFromPosition (ExerciseTimeTenThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		CurrentExerciseTime = (ExerciseTimeTenThousands * 3600) + (ExerciseTimeThousands * 600) + (ExerciseTimeHundreds * 60) + (ExerciseTimeTens * 10) + (ExerciseTimeOnes);

		string ExcerciseSideString = GetScrollRectStringFromPosition (ExerciseSideScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().BodySide.Count, UserBlobManager.GetComponent<UserBlobManager> ().BodySide);
		CurrentExerciseSide = ExcerciseSideString;

		string ExcerciseCountDownAtStartString = GetScrollRectStringFromPosition (ExerciseCountDownAtStartScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().YesNoList.Count, UserBlobManager.GetComponent<UserBlobManager> ().YesNoList);
		CurrentExerciseCountDownAtStart = true;
		if (ExcerciseCountDownAtStartString == "No") {CurrentExerciseCountDownAtStart = false;}

        int CurrentExerciseIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].Name = CurrentExerciseName;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].Description = CurrentExerciseDescription;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].Type = CurrentExerciseType;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].BodyPart = CurrentExerciseBodyPart;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].Weight = CurrentExerciseWeight;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].Reps = CurrentExerciseReps;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].Time = CurrentExerciseTime;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].RestTime = CurrentExerciseRestTime;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].Side = CurrentExerciseSide;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].CountDownAtStart = CurrentExerciseCountDownAtStart;
        UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[CurrentExerciseIndex].NumAnimationFrames = CurrentExcerciseNumAnimationFrames;
    }

    public string ExerciseValid()
    {
        int ExerciseTimeOnes = GetScrollRectIntFromPosition(ExerciseTimeOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int ExerciseTimeTens = GetScrollRectIntFromPosition(ExerciseTimeTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberListToFive.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberListToFive);
        int ExerciseTimeHundreds = GetScrollRectIntFromPosition(ExerciseTimeHundredsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int ExerciseTimeThousands = GetScrollRectIntFromPosition(ExerciseTimeThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int ExerciseTimeTenThousands = GetScrollRectIntFromPosition(ExerciseTimeTenThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int tempCurrentExerciseTime = (ExerciseTimeTenThousands * 3600) + (ExerciseTimeThousands * 600) + (ExerciseTimeHundreds * 60) + (ExerciseTimeTens * 10) + (ExerciseTimeOnes);

        if(tempCurrentExerciseTime == 0)
        {
            return "BadTime";
        }

        return "OK";
    }

    public void OkButtonPressed()
	{
        if(ExerciseValid() == "BadTime")
        {
            if (PopUpActive == false)
            {
                PopUpOkDialog("Time value must be greater than 0", this.gameObject.GetComponent<UI_EditExercise>(), "BadTime");
            }
        }
        else
        {
            // copy data from UI to User Blob
            UpdateExerciseDataFromUI();
            // save data
            UserBlobManager.GetComponent<UserBlobManager>().SaveExercise();
            // switch states
            UIManager.GetComponent<UI_Manager>().SwitchStates("CreateExerciseState");
        }
    }

    public void CancelButtonPressed()
    {
        if (PopUpActive == false)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("CreateExerciseState");
        }
    }

    private string GetScrollRectStringFromPosition(float myPosition, int ButtonHeight, int NumButtons, List<string> myList)
	{
		string myString = "";
		int myIndex = 0;
		float temp = (ButtonHeight * NumButtons);
		myPosition = myPosition + (ButtonHeight * NumButtons / 2);
		myIndex = (int)Mathf.Floor(myPosition / temp * (float)NumButtons);
		myString = myList[myIndex];
		return myString;
	}

	private int GetScrollRectIntFromPosition(float myPosition, int ButtonHeight, int NumButtons, List<int> myList)
	{
		int myInt = 0;
		int myIndex = 0;
		float temp = (ButtonHeight * NumButtons);
		myPosition = myPosition + (ButtonHeight * NumButtons / 2);
		myIndex = (int)Mathf.Floor(myPosition / temp * (float)NumButtons);
		myInt = myList[myIndex];
		return myInt;
	}

	private void SetScrollRectPositionFromInt(int myInteger, int ButtonHeight, int NumButtons, GameObject myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2); 
		myScrollPanel.transform.localPosition = tempPos;
	}

	public int BodyPartStringToInt(string myText)
	{
		for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().BodyPartList.Count; i++) 
		{
			string tempBodyPartString = UserBlobManager.GetComponent<UserBlobManager>().BodyPartList[i];
			if(tempBodyPartString == myText)
			{
				return (i);
			}
		}
		return 0;
	}

	public int ExerciseTypeStringToInt(string myText)
	{
		for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ExerciseTypeList.Count; i++) 
		{
			string tempExerciseTypePartString = UserBlobManager.GetComponent<UserBlobManager>().ExerciseTypeList[i];
			if(tempExerciseTypePartString == myText)
			{
				return (i);
			}
		}
		return 0;
	}

	public int SideStringToInt(string myText)
	{
		for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().BodySide.Count; i++) 
		{
			string tempSideString = UserBlobManager.GetComponent<UserBlobManager>().BodySide[i];
			if(tempSideString == myText)
			{
				return (i);
			}
		}
		return 0;
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
            case "BadTime":
                if (DialogState == "ok")
                {
                    print("Bad Time");
                    //RemoveData();
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }

}
