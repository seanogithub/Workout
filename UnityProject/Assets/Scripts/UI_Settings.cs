using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;

public class UI_Settings : MonoBehaviour {
	
	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;

	public GameObject AudioChimeAtEndOfExerciseButtonText;
	public GameObject VoiceSayExerciseNameButtonText;
	public GameObject VoiceSayExerciseWeightButtonText;
	public GameObject VoiceSayExerciseRepsButtonText;
	public GameObject VoiceSayExerciseTimeButtonText;
	public GameObject VoiceSayRepsCountDownButtonText;
	public GameObject VoiceRepsCountDownButtonText;
    public Transform SettingsContentPanel;

    public string PopUpYesNoDialogState = "";
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

        SettingsContentPanel.localPosition = new Vector3(0, -715, 0);

        if (UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.AudioChimeAtEndOfExercise == true)
		{
			AudioChimeAtEndOfExerciseButtonText.GetComponent<Text>().text = "On";
		}
		else
		{
			AudioChimeAtEndOfExerciseButtonText.GetComponent<Text>().text = "Off";
		}

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName == true)
		{
			VoiceSayExerciseNameButtonText.GetComponent<Text>().text = "On";
		}
		else
		{
			VoiceSayExerciseNameButtonText.GetComponent<Text>().text = "Off";
		}

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseWeight == true)
		{
			VoiceSayExerciseWeightButtonText.GetComponent<Text>().text = "On";
		}
		else
		{
			VoiceSayExerciseWeightButtonText.GetComponent<Text>().text = "Off";
		}

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseReps == true)
		{
			VoiceSayExerciseRepsButtonText.GetComponent<Text>().text = "On";
		}
		else
		{
			VoiceSayExerciseRepsButtonText.GetComponent<Text>().text = "Off";
		}

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseTime == true)
		{
			VoiceSayExerciseTimeButtonText.GetComponent<Text>().text = "On";
		}
		else
		{
			VoiceSayExerciseTimeButtonText.GetComponent<Text>().text = "Off";
		}

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayRepsCountDown == true)
		{
			VoiceSayRepsCountDownButtonText.GetComponent<Text>().text = "On";
		}
		else
		{
			VoiceSayRepsCountDownButtonText.GetComponent<Text>().text = "Off";
		}

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceRepsCountDown == true)
		{
			VoiceRepsCountDownButtonText.GetComponent<Text>().text = "Down";
		}
		else
		{
			VoiceRepsCountDownButtonText.GetComponent<Text>().text = "Up";
		}
	}
	public void HomeButtonPressed()
	{
		// save data
		UserBlobManager.GetComponent<UserBlobManager> ().SaveSettings();
		
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("HomeState");
	}		

	public void AudioChimeAtEndOfExerciseButtonPressed()
	{
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.AudioChimeAtEndOfExercise == true)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.AudioChimeAtEndOfExercise = false;
			AudioChimeAtEndOfExerciseButtonText.GetComponent<Text>().text = "Off";
		}
		else
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.AudioChimeAtEndOfExercise = true;
			AudioChimeAtEndOfExerciseButtonText.GetComponent<Text>().text = "On";
		}
	}

	public void VoiceSayExerciseNameButtonPressed()
	{
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName == true)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName = false;
			VoiceSayExerciseNameButtonText.GetComponent<Text>().text = "Off";
		}
		else
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName = true;
			VoiceSayExerciseNameButtonText.GetComponent<Text>().text = "On";
		}
	}

	public void VoiceSayExerciseWeightButtonPressed()
	{
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseWeight == true)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseWeight = false;
			VoiceSayExerciseWeightButtonText.GetComponent<Text>().text = "Off";
		}
		else
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseWeight = true;
			VoiceSayExerciseWeightButtonText.GetComponent<Text>().text = "On";
		}
	}

	public void VoiceSayExerciseRepsButtonPressed()
	{
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseReps == true)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseReps = false;
			VoiceSayExerciseRepsButtonText.GetComponent<Text>().text = "Off";
		}
		else
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseReps = true;
			VoiceSayExerciseRepsButtonText.GetComponent<Text>().text = "On";
		}
	}
	
	public void VoiceSayExerciseTimeButtonPressed()
	{
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseTime == true)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseTime = false;
			VoiceSayExerciseTimeButtonText.GetComponent<Text>().text = "Off";
		}
		else
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseTime = true;
			VoiceSayExerciseTimeButtonText.GetComponent<Text>().text = "On";
		}
	}
	
	public void VoiceSayRepsCountDownButtonPressed()
	{
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayRepsCountDown == true)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayRepsCountDown = false;
			VoiceSayRepsCountDownButtonText.GetComponent<Text>().text = "Off";
		}
		else
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayRepsCountDown = true;
			VoiceSayRepsCountDownButtonText.GetComponent<Text>().text = "On";
		}
	}

	public void VoiceRepsCountDownButtonPressed()
	{
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceRepsCountDown == true)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceRepsCountDown = false;
			VoiceRepsCountDownButtonText.GetComponent<Text>().text = "Up";
		}
		else
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceRepsCountDown = true;
			VoiceRepsCountDownButtonText.GetComponent<Text>().text = "Down";
		}
	}

    public void ResetAllSettingsButtonPressed()
    {
        if (PopUpActive == false)
        {
            PopUpYesNoDialog("Are you sure you want to reset all your settings?", this.gameObject.GetComponent<UI_Settings>(), "ResetAllSettings");
        }
    }

    public void ResetAllSettings()
    {
        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData = new SettingsData();
        UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
        UIManager.GetComponent<UI_Manager>().SwitchStates("HomeState");
    }

    public void RestoreAllDataButtonPressed()
    {
        RestoreExerciseData();
        RestoreWorkoutData();
        RestoreTrainingData();
    }

    public void RestoreExerciseData()
    {
        ExerciseDataInit ExerciseDataString = new ExerciseDataInit();
        SaveExerciseData tempExercise = (SaveExerciseData)DeserializeObject(ExerciseDataString.InitData, "SaveExerciseData");

        for (var k = 0; k < tempExercise.Exercise.Length; k++)
        {
            int foundIndex = -1;
            for (var i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise.Length; i++)
            {
                if (UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[i].Name == tempExercise.Exercise[k].Name)
                {
                    foundIndex = i;
                }
            }
            if (foundIndex < 0)
            {
                //add the Exercise
                UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Add(tempExercise.Exercise[k]);
                UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise.OrderBy(x => x.Name).ToArray();
                UserBlobManager.GetComponent<UserBlobManager>().SaveExercise();
            }
            else
            {
                // found duplicate dont add the Exercise
            }
        }

        if (PopUpActive == false)
        {
            PopUpOkDialog("Exercise Data Restored", this.gameObject.GetComponent<UI_Settings>(), "RestoredData");
        }
    }

    public void RestoreWorkoutData()
    {
        WorkoutDataInit WorkoutDataString = new WorkoutDataInit();
        SaveWorkoutData tempWorkout = (SaveWorkoutData)DeserializeObject(WorkoutDataString.InitData, "SaveWorkoutData");

        for (var k = 0; k < tempWorkout.Workout.Length; k++)
        {
            int foundIndex = -1;
            for (var i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.Length; i++)
            {
                if (UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout[i].Name == tempWorkout.Workout[k].Name)
                {
                    foundIndex = i;
                }
            }
            if (foundIndex < 0)
            {
                //add the Workout
                UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Add(tempWorkout.Workout[k]);
                UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout.OrderBy(x => x.Name).ToArray();
                UserBlobManager.GetComponent<UserBlobManager>().SaveWorkout();
            }
            else
            {
                // found duplicate dont add the Workout
            }
        }

        if (PopUpActive == false)
        {
            PopUpOkDialog("Workout Data Restored", this.gameObject.GetComponent<UI_Settings>(), "RestoredData");
        }
    }

    public void RestoreTrainingData()
    {
        TrainingDataInit TrainingDataString = new TrainingDataInit();
        SaveTrainingData tempTraining = (SaveTrainingData)DeserializeObject(TrainingDataString.InitData, "SaveTrainingData");

        for (var k = 0; k < tempTraining.Training.Length; k++)
        {
            int foundIndex = -1;
            for (var i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training.Length; i++)
            {
                if (UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[i].Name == tempTraining.Training[k].Name)
                {
                    foundIndex = i;
                }
            }
            if (foundIndex < 0)
            {
                //add the Training
                UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Add(tempTraining.Training[k]);
                UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training.OrderBy(x => x.Name).ToArray();
                UserBlobManager.GetComponent<UserBlobManager>().SaveTraining();
            }
            else
            {
                // found duplicate dont add the Training
            }
        }

        if (PopUpActive == false)
        {
            PopUpOkDialog("Training Data Restored", this.gameObject.GetComponent<UI_Settings>(), "RestoredData");
        }
    }


    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
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
            case "RestoredData":
                if (DialogState == "ok")
                {
                    print("RestoredData ok");
                    //RemoveData();
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
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
            case "ResetAllSettings":
                if (DialogState == "ok")
                {
                    print("Reset All Settings");
                    ResetAllSettings();
                }
                if (DialogState == "cancel")
                {
                    print("cancel");
                }
                break;
        }
        PopUpYesNoDialogState = "";
        PopUpActive = false;
    }
}
