﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class UI_NewWorkout : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	
	public GameObject TextName;
	public GameObject TextDescription;
    public GameObject WorkoutTypeScrollPanel;

    public WorkoutData CurrentWorkout = new WorkoutData();

    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    // Use this for initialization
    void Start () {
	
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
		CurrentWorkout = new WorkoutData();
		CurrentWorkout.Name = "";
		CurrentWorkout.Description = "";
        CurrentWorkout.Type = "";
        CurrentWorkout.ExerciseArray = new SaveExerciseData();

		TextName.GetComponent<InputField>().text = CurrentWorkout.Name;
		TextDescription.GetComponent<InputField>().text = CurrentWorkout.Description;

    }

	public bool FindDuplicateWorkoutName ( string myName)
	{
		SaveWorkoutData tempWorkoutData = new SaveWorkoutData ();
		tempWorkoutData = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData;
		for (int i = 0; i < tempWorkoutData.Workout.Length; i++)
		{
			if (myName.ToLower() == tempWorkoutData.Workout[i].Name.ToLower())
			{
				return true;
			}
		}
		return false;
	}

	public void CreateButtonClicked()
	{
        //string validLetters = "^[a-zA-Z- ,]*$";
        //string validNumbers = "^[0-9- ,]*$";
        string validLettersNumbers = "^[a-zA-Z0-9- ,]*$";
        //Regex RegLetters = new Regex(validLetters);
        //Regex RegNumbers = new Regex(validNumbers);
        Regex RegLettersNumbers = new Regex(validLettersNumbers);

        // validate data
        if ((TextName.GetComponent<InputField>().text == "") || (TextDescription.GetComponent<InputField>().text == ""))
		{
            if (PopUpActive == false)
            {
                PopUpOkDialog("Please fill in all the fields", this.gameObject.GetComponent<UI_NewWorkout>(), "BadData");
            }
        }
		else
		{
            if (!RegLettersNumbers.IsMatch(TextName.GetComponent<InputField>().text))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Workout name can only contain letters and numbers", this.gameObject.GetComponent<UI_NewWorkout>(), "BadData");
                }
            }
            else
            {
                // check for duplicate name
                if (FindDuplicateWorkoutName(TextName.GetComponent<InputField>().text) == true)
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog("Name is already used. Please enter a unique name.", this.gameObject.GetComponent<UI_NewWorkout>(), "BadData");
                    }
                }
                else
                {
                    CurrentWorkout.Name = TextName.GetComponent<InputField>().text;
                    CurrentWorkout.Description = TextDescription.GetComponent<InputField>().text;
                    CurrentWorkout.Type = GetScrollRectStringFromPosition(WorkoutTypeScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().WorkoutTypeList.Count, UserBlobManager.GetComponent<UserBlobManager>().WorkoutTypeList);

                    UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Add(CurrentWorkout);

                    // sort list
                    UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.OrderBy(x => x.Name).ToArray();

                    int CurrentWorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().FindWorkoutByName(CurrentWorkout.Name);
                    UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = CurrentWorkoutIndex;
                    UserBlobManager.GetComponent<UserBlobManager>().SaveWorkout();
                    UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutState");
                }
            }
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
            case "BadData":
                if (DialogState == "ok")
                {
                    print("BadData");
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }
}
