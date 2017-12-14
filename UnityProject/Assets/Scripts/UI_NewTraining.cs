using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class UI_NewTraining : MonoBehaviour {
	
	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	
	public GameObject TextName;
	public GameObject TextDescription;
    public GameObject TrainingTypeScrollPanel;

    public TrainingData CurrentTraining = new TrainingData();

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
		CurrentTraining = new TrainingData();
		CurrentTraining.Name = "";
		CurrentTraining.Description = "";
		//CurrentTraining.DayArray = new List<DayData>();
        CurrentTraining.DayArray = new SaveDayData();
        DayData FirstDay = new DayData ();
		CurrentTraining.DayArray.Add (FirstDay);
		CurrentTraining.Type = "";
		
		TextName.GetComponent<InputField>().text = CurrentTraining.Name;
		TextDescription.GetComponent<InputField>().text = CurrentTraining.Description;
	}
	
	public bool FindDuplicateTrainingName ( string myName)
	{
//		List<TrainingData> tempTrainingData = new List<TrainingData> ();
		SaveTrainingData tempTrainingData = new SaveTrainingData();
		tempTrainingData = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData;
		for (int i = 0; i < tempTrainingData.Training.Length; i++)
		{
			if (myName.ToLower() == tempTrainingData.Training[i].Name.ToLower())
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
                PopUpOkDialog("Please fill in all the fields", this.gameObject.GetComponent<UI_NewTraining>(), "BadData");
            }
        }
		else
		{
            if (!RegLettersNumbers.IsMatch(TextName.GetComponent<InputField>().text))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Training name can only contain letters and numbers", this.gameObject.GetComponent<UI_NewTraining>(), "BadData");
                }
            }
            else
            {
                // check for duplicate name
                if (FindDuplicateTrainingName(TextName.GetComponent<InputField>().text) == true)
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog("Name is already used. Please enter a unique name.", this.gameObject.GetComponent<UI_NewTraining>(), "BadData");
                    }
                }
                else
                {
                    CurrentTraining.Name = TextName.GetComponent<InputField>().text;
                    CurrentTraining.Description = TextDescription.GetComponent<InputField>().text;
                    CurrentTraining.Type = GetScrollRectStringFromPosition(TrainingTypeScrollPanel.transform.localPosition.y, 100, UserBlobManager.GetComponent<UserBlobManager>().TrainingTypeList.Count, UserBlobManager.GetComponent<UserBlobManager>().TrainingTypeList);

                    UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Add(CurrentTraining);

                    // sort list
                    UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training.OrderBy(x => x.Name).ToArray();

                    int CurrentTrainingIndex = UserBlobManager.GetComponent<UserBlobManager>().FindTrainingByName(CurrentTraining.Name);

                    UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex = CurrentTrainingIndex;
                    UserBlobManager.GetComponent<UserBlobManager>().SaveTraining();
                    UIManager.GetComponent<UI_Manager>().SwitchStates("EditTrainingState");
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
