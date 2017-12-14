using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class UI_NewExercise : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;

	public GameObject TextName;
	public GameObject TextDescription;

	private string CurrentExcerciseName = "";
	private string CurrentExcerciseDescription = "";
	private string CurrentExcerciseType = "General";
	private string CurrentExcerciseBodyPart = "Body";
	private int CurrentExcerciseWeight = 0;
	private int CurrentExcerciseReps = 0;
	private int CurrentExcerciseTime = 0;
	private int CurrentExcerciseRestTime = 0;
	private string CurrentExerciseSide = "None";
	private int CurrentExcerciseNumAnimationFrames = -1;

	private ExerciseData tempExercise = new ExerciseData();

    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		TextName = GameObject.Find ("InputField_NewExerciseName");
		TextDescription = GameObject.Find ("InputField_NewExerciseDescription");
	}

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
		tempExercise = new ExerciseData();
		CurrentExcerciseName = "";
		CurrentExcerciseDescription = "";
		CurrentExcerciseType = "General";
		CurrentExcerciseBodyPart = "Body";
		CurrentExcerciseWeight = 0;
		CurrentExcerciseReps = 0;
		CurrentExcerciseTime = 0;
		CurrentExcerciseRestTime = 0;
		CurrentExerciseSide = "None";
		CurrentExcerciseNumAnimationFrames = -1;

		TextName.GetComponent<InputField>().text = CurrentExcerciseName;
		TextDescription.GetComponent<InputField>().text = CurrentExcerciseDescription;

		tempExercise.Name = CurrentExcerciseName;
		tempExercise.Description = CurrentExcerciseDescription;
		tempExercise.Type = CurrentExcerciseType;
		tempExercise.BodyPart = CurrentExcerciseBodyPart;
		tempExercise.Weight = CurrentExcerciseWeight;
		tempExercise.Reps = CurrentExcerciseReps;
		tempExercise.Time = CurrentExcerciseTime;
		tempExercise.RestTime = CurrentExcerciseRestTime;
		tempExercise.Side = CurrentExerciseSide;
		tempExercise.NumAnimationFrames = CurrentExcerciseNumAnimationFrames;
	}

	public bool FindDuplicateExerciseName ( string myName)
	{
		for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length; i++)
		{
			if (myName.ToLower() == UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[i].Name.ToLower())
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
                PopUpOkDialog("Please fill in all the fields", this.gameObject.GetComponent<UI_NewExercise>(), "BadData");
            }
        }
		else
		{
            if (!RegLettersNumbers.IsMatch(TextName.GetComponent<InputField>().text))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Exercise name can only contain letters and numbers", this.gameObject.GetComponent<UI_NewExercise>(), "BadData");
                }
            }
            else
            {
                // check for duplicate name
                if (FindDuplicateExerciseName(TextName.GetComponent<InputField>().text) == true)
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog("Name is already used. Please enter a unique name.", this.gameObject.GetComponent<UI_NewExercise>(), "BadData");
                    }
                }
                else
                {
                    tempExercise.Name = TextName.GetComponent<InputField>().text;
                    tempExercise.Description = TextDescription.GetComponent<InputField>().text;

                    // add temp exercise
                    UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Add(tempExercise);

                    // sort list
                    UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise.OrderBy(x => x.Name).ToArray();

                    int CurrentExerciseIndex = UserBlobManager.GetComponent<UserBlobManager>().FindExerciseByName(tempExercise.Name);
                    //				int CurrentExerciseIndex = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Count - 1;
                    UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex = CurrentExerciseIndex;
                    UserBlobManager.GetComponent<UserBlobManager>().SaveExercise();
                    UIManager.GetComponent<UI_Manager>().SwitchStates("EditExerciseState");
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
