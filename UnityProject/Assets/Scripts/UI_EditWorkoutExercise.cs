using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_EditWorkoutExercise : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject UIEditWorkout;

	public GameObject TextName;
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

	public int CurrentExerciseIndex = 0;

	private string CurrentExcerciseName = "";
	private int CurrentExcerciseWeight = 0;
	private int CurrentExcerciseReps = 0;
	private int CurrentExcerciseTime = 0;
	private string CurrentExerciseSide = "None";
	private int CurrentExerciseRestTime = 0;
	private bool CurrentExerciseCountDownAtStart = true;

    public string PopUpYesNoDialogState = "";
    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		UIEditWorkout = GameObject.Find("UI_EditWorkout_Prefab");
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
		
		CurrentExerciseIndex = UIEditWorkout.GetComponent<UI_EditWorkout>().SelectedWorkoutExcercise;
		
		CurrentExcerciseName = UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Name;
		CurrentExcerciseWeight = UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Weight;
		CurrentExcerciseReps = UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps;
		CurrentExcerciseTime = UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
		CurrentExerciseSide = UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Side;
		CurrentExerciseRestTime = UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].RestTime;
		CurrentExerciseCountDownAtStart = UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].CountDownAtStart;

		TextName.GetComponent<Text>().text = CurrentExcerciseName;
		
		// Convert Weight Ones to scroll rect
		int ExcerciseWeightOnes = 0;
		if (CurrentExcerciseWeight > 0) 
		{
			ExcerciseWeightOnes = (int)(CurrentExcerciseWeight.ToString () [CurrentExcerciseWeight.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseWeightOnes, 100, 10, ExerciseWeightOnesScrollPanel);
		
		// Convert Weight Tens to scroll rect
		int ExcerciseWeightTens = 0;
		if (CurrentExcerciseWeight >= 10) 
		{
			ExcerciseWeightTens = (int)(CurrentExcerciseWeight.ToString () [CurrentExcerciseWeight.ToString ().Length - 2]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseWeightTens, 100, 10, ExerciseWeightTensScrollPanel);
		
		// Convert Weight Tens to scroll rect
		int ExcerciseWeightHundreds = 0;
		if (CurrentExcerciseWeight >= 100) 
		{
			ExcerciseWeightHundreds = (int)(CurrentExcerciseWeight.ToString () [CurrentExcerciseWeight.ToString ().Length - 3]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseWeightHundreds, 100, 10, ExerciseWeightHundredsScrollPanel);
		
		// Convert reps Ones to scroll rect
		int ExcerciseRepsOnes = 0;
		if (CurrentExcerciseReps > 0) 
		{
			ExcerciseRepsOnes = (int)(CurrentExcerciseReps.ToString () [CurrentExcerciseReps.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRepsOnes, 100, 10, ExerciseRepsOnesScrollPanel);
		
		// Convert reps Tens to scroll rect
		int ExcerciseRepsTens = 0;
		if (CurrentExcerciseReps >= 10) 
		{
			ExcerciseRepsTens = (int)(CurrentExcerciseReps.ToString () [CurrentExcerciseReps.ToString ().Length - 2]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRepsTens, 100, 10, ExerciseRepsTensScrollPanel);
		
		// Convert time Ones to scroll rect
		int ExcerciseTimeOnes = 0;
		if (CurrentExcerciseTime > 0) 
		{
			ExcerciseTimeOnes = (int)(CurrentExcerciseTime.ToString () [CurrentExcerciseTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeOnes, 100, 10, ExerciseTimeOnesScrollPanel);
		
		// Convert time tens to scroll rect
		int ExcerciseTimeTens = 0;
		if (CurrentExcerciseTime >= 10) 
		{
			int tempTime = CurrentExcerciseTime % 60;
			tempTime = tempTime / 10;
			ExcerciseTimeTens = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeTens, 100, 6, ExerciseTimeTensScrollPanel);
		
		// Convert time hundreds to scroll rect
		int ExcerciseTimeHundreds = 0;
		if (CurrentExcerciseTime >= 60) 
		{
			int tempTime = CurrentExcerciseTime/60;
			ExcerciseTimeHundreds = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeHundreds, 100, 10, ExerciseTimeHundredsScrollPanel);
		
		// Convert time thousands to scroll rect
		int ExcerciseTimeThousands = 0;
		if (CurrentExcerciseTime >= 600) 
		{
			int tempTime = CurrentExcerciseTime/600;
			ExcerciseTimeThousands = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeThousands, 100, 10, ExerciseTimeThousandsScrollPanel);
		
		// Convert time ten thousands to scroll rect
		int ExcerciseTimeTenThousands = 0;
		if (CurrentExcerciseTime >= 3600) 
		{
			int tempTime = CurrentExcerciseTime/3600;
			ExcerciseTimeTenThousands = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseTimeTenThousands, 100, 10, ExerciseTimeTenThousandsScrollPanel);
/*		
		// Convert rest time Ones to scroll rect
		int ExcerciseRestTimeOnes = 0;
		if (CurrentExerciseRestTime > 0) 
		{
			ExcerciseRestTimeOnes = (int)(CurrentExerciseRestTime.ToString () [CurrentExerciseRestTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRestTimeOnes, 100, 10, ExerciseRestTimeOnesScrollPanel);
		
		// Convert rest time tens to scroll rect
		int ExcerciseRestTimeTens = 0;
		if (CurrentExerciseRestTime >= 10) 
		{
			int tempTime = CurrentExerciseRestTime % 60;
			tempTime = tempTime / 10;
			ExcerciseRestTimeTens = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRestTimeTens, 100, 6, ExerciseRestTimeTensScrollPanel);
		
		// Convert rest time hundreds to scroll rect
		int ExcerciseRestTimeHundreds = 0;
		if (CurrentExerciseRestTime >= 60) 
		{
			int tempTime = CurrentExerciseRestTime/60;
			ExcerciseRestTimeHundreds = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRestTimeHundreds, 100, 10, ExerciseRestTimeHundredsScrollPanel);
		
		// Convert rest time thousands to scroll rect
		int ExcerciseRestTimeThousands = 0;
		if (CurrentExerciseRestTime >= 600) 
		{
			int tempTime = CurrentExerciseRestTime/600;
			ExcerciseRestTimeThousands = (int)(tempTime.ToString () [tempTime.ToString ().Length - 1]) - 48;
		}
		SetScrollRectPositionFromInt (ExcerciseRestTimeThousands, 100, 10, ExerciseRestTimeThousandsScrollPanel);
*/

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
		CurrentExcerciseName = TextName.GetComponent<Text>().text;

		int ExerciseWeightOnes = GetScrollRectIntFromPosition (ExerciseWeightOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseWeightTens = GetScrollRectIntFromPosition (ExerciseWeightTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseWeightHundreds = GetScrollRectIntFromPosition (ExerciseWeightHundredsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		CurrentExcerciseWeight = (ExerciseWeightHundreds * 100) + (ExerciseWeightTens * 10) + (ExerciseWeightOnes);
		
		int ExerciseRepsOnes = GetScrollRectIntFromPosition (ExerciseRepsOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseRepsTens = GetScrollRectIntFromPosition (ExerciseRepsTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		CurrentExcerciseReps = (ExerciseRepsTens * 10) + (ExerciseRepsOnes);
		
		int ExerciseTimeOnes = GetScrollRectIntFromPosition (ExerciseTimeOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseTimeTens = GetScrollRectIntFromPosition (ExerciseTimeTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberListToFive.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberListToFive);
		int ExerciseTimeHundreds = GetScrollRectIntFromPosition (ExerciseTimeHundredsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseTimeThousands = GetScrollRectIntFromPosition (ExerciseTimeThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseTimeTenThousands = GetScrollRectIntFromPosition (ExerciseTimeTenThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		CurrentExcerciseTime = (ExerciseTimeTenThousands * 3600) + (ExerciseTimeThousands * 600) + (ExerciseTimeHundreds * 60) + (ExerciseTimeTens * 10) + (ExerciseTimeOnes);
/*		
		int ExerciseRestTimeOnes = GetScrollRectIntFromPosition (ExerciseRestTimeOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseRestTimeTens = GetScrollRectIntFromPosition (ExerciseRestTimeTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberListToFive.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberListToFive);
		int ExerciseRestTimeHundreds = GetScrollRectIntFromPosition (ExerciseRestTimeHundredsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		int ExerciseRestTimeThousands = GetScrollRectIntFromPosition (ExerciseRestTimeThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager> ().NumberList);
		CurrentExerciseRestTime = (ExerciseRestTimeThousands * 600) + (ExerciseRestTimeHundreds * 60) + (ExerciseRestTimeTens * 10) + (ExerciseRestTimeOnes);
*/
		string ExcerciseSideString = GetScrollRectStringFromPosition (ExerciseSideScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().BodySide.Count, UserBlobManager.GetComponent<UserBlobManager> ().BodySide);
		CurrentExerciseSide = ExcerciseSideString;

		string ExcerciseCountDownAtStartString = GetScrollRectStringFromPosition (ExerciseCountDownAtStartScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager> ().YesNoList.Count, UserBlobManager.GetComponent<UserBlobManager> ().YesNoList);
		CurrentExerciseCountDownAtStart = true;
		if (ExcerciseCountDownAtStartString == "No") {CurrentExerciseCountDownAtStart = false;}

		UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Name = CurrentExcerciseName;
		UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Weight = CurrentExcerciseWeight;
		UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps = CurrentExcerciseReps;
		UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time = CurrentExcerciseTime;
		UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Side = CurrentExerciseSide;
		UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].RestTime = CurrentExerciseRestTime;
		UIEditWorkout.GetComponent<UI_EditWorkout>().CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].CountDownAtStart = CurrentExerciseCountDownAtStart;
	}

    public string ExerciseValid()
    {
        int ExerciseTimeOnes = GetScrollRectIntFromPosition(ExerciseTimeOnesScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int ExerciseTimeTens = GetScrollRectIntFromPosition(ExerciseTimeTensScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberListToFive.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberListToFive);
        int ExerciseTimeHundreds = GetScrollRectIntFromPosition(ExerciseTimeHundredsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int ExerciseTimeThousands = GetScrollRectIntFromPosition(ExerciseTimeThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int ExerciseTimeTenThousands = GetScrollRectIntFromPosition(ExerciseTimeTenThousandsScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().NumberList.Count, UserBlobManager.GetComponent<UserBlobManager>().NumberList);
        int tempCurrentExerciseTime = (ExerciseTimeTenThousands * 3600) + (ExerciseTimeThousands * 600) + (ExerciseTimeHundreds * 60) + (ExerciseTimeTens * 10) + (ExerciseTimeOnes);

        if (tempCurrentExerciseTime == 0)
        {
            return "BadTime";
        }
        return "OK";
    }

    public void OkButtonPressed()
	{
        if (ExerciseValid() == "BadTime")
        {
            if (PopUpActive == false)
            {
                PopUpOkDialog("Time value must be greater than 0", this.gameObject.GetComponent<UI_EditWorkoutExercise>(), "BadTime");
            }
        }
        else
        {
            // copy data from UI to User Blob
            UpdateExerciseDataFromUI();

            // switch states
            UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutState");
        }
    }

    public void CancelButtonPressed()
    {
        if (PopUpActive == false)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutState");
        }
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
	
	int GetScrollRectIntFromPosition(float myPosition, int ButtonHeight, int NumButtons, List<int> myList)
	{
		int myInt = 0;
		int myIndex = 0;
		float temp = (ButtonHeight * NumButtons);
		myPosition = myPosition + (ButtonHeight * NumButtons / 2);
		myIndex = (int)Mathf.Floor(myPosition / temp * (float)NumButtons);
		myInt = myList[myIndex];
		return myInt;
	}
	
	void SetScrollRectPositionFromInt(int myInteger, int ButtonHeight, int NumButtons, GameObject myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2); 
		myScrollPanel.transform.localPosition = tempPos;
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
