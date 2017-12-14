using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UI_CreateTraining : MonoBehaviour {
	
	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject TrainingButton;
	
	public SaveTrainingData UserTrainingData;

	public TrainingData item = new TrainingData();
	
	public List<GameObject> TrainingButtonArray = new List<GameObject>();
	
	public Transform TrainingContentPanel;
	public GameObject TrainingContentPanelScrollBar;
	public bool ScrollBarMove = false;
	
	public int SelectedTraining = -1;
	
	public Color SelectedColor = Color.red;

    public string PopUpYesNoDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
		UserTrainingData = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData;
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
		UserTrainingData = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData;

        if (UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex > UserTrainingData.Training.Length)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex = 0;
        }

        if (UserTrainingData.Training.Length == 0)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex = -1;
        }
        if(UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex < 0 && UserTrainingData.Training.Length > 0)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex = 0;
        }

        SelectedTraining = UserBlobManager.GetComponent<UserBlobManager>().CurrentTrainingIndex;
        int scrollIndex = SelectedTraining;

        if (scrollIndex > UserTrainingData.Training.Length - 6)
        {
            scrollIndex = UserTrainingData.Training.Length - 6;
        }

        ClearScrollList ();
		PopulateScrollList ();
		
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length, TrainingContentPanel);
		}
		else
		{
			TrainingContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}
	
	public void ClearScrollList()
	{
		for (int i = TrainingContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(TrainingContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateScrollList () 
	{
		TrainingButtonArray.Clear ();
		foreach (var item in UserTrainingData.Training)
		{

            //int TotalTrainingDays = item.DayArray.Count;
            int TotalTrainingDays = item.DayArray.Day.Length;

            GameObject newButton = Instantiate (TrainingButton) as GameObject;
			TrainingButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			//			string tempText = item.Name;
			//			if(item.Weight > 0) {tempText += ("-" + item.Weight + "lbs");}
			//			if(item.Reps > 0) {tempText += ("-" + item.Reps + "reps");}
			//			newButton.GetComponentInChildren<Text>().text = tempText;
			//			newButton.GetComponentInChildren<Text>().fontSize = 50;
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
            newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
            newButton.transform.Find("Text_Time").GetComponent<Text>().text = TotalTrainingDays.ToString() + " Days";// item.Type;
            string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => ExerciseButtonClicked(selectedButton));
			newButton.transform.SetParent (TrainingContentPanel);
		}
		if(TrainingButtonArray.Count > 0)
		{
			TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void ExerciseButtonClicked(string myText)
	{
		TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = Color.white;
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindTrainingByName (myText);
		SelectedTraining = myIndex;
		UserBlobManager.GetComponent<UserBlobManager> ().CurrentTrainingIndex = myIndex;
		TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void DeleteTraining()
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().CurrentTrainingIndex;
		if(myIndex < UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.RemoveAt(myIndex);
//			UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.TrimExcess();
			UserTrainingData = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData;
			UserBlobManager.GetComponent<UserBlobManager> ().SaveTraining();
			if(myIndex >= UserTrainingData.Training.Length)
			{
				myIndex = UserTrainingData.Training.Length - 1;
				UserBlobManager.GetComponent<UserBlobManager> ().CurrentTrainingIndex = myIndex;
			}
			SelectedTraining = myIndex;
			ClearScrollList ();
			PopulateScrollList ();	
		}
	}

    public void OnDeleteButtonPressed()
    {
        if (SelectedTraining >= 0)
        {
            if (PopUpActive == false)
            {
                PopUpYesNoDialog("Are you sure you want to delete this training?", this.gameObject.GetComponent<UI_CreateTraining>(), "DeleteTraining");
            }
        }
    }

    public void OnEditPressed()
    {
        if (SelectedTraining >= 0)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("EditTrainingState");
        }
    }

    public void AddTrainingToCalendarButtonPressed()
	{
        if(SelectedTraining >= 0)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("DayPickerState");
        }
        /*
        for (int DayIndex = 0; DayIndex < UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[SelectedTraining].DayArray.Day.Length; DayIndex++)
        {
            UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[SelectedTraining].DayArray.Day[DayIndex].Day = System.DateTime.Now.AddDays(DayIndex);
            if (UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[SelectedTraining].DayArray.Day[DayIndex].DayWorkoutArray.Length > 0)
            {
                int NumWorkoutsToAdd = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[SelectedTraining].DayArray.Day[DayIndex].DayWorkoutArray.Length;
                for (int addIndex = 0; addIndex < NumWorkoutsToAdd; addIndex++)
                {
                    string addWorkoutName = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[SelectedTraining].DayArray.Day[DayIndex].DayWorkoutArray[addIndex].WorkoutName;
                    System.DateTime addWorkoutDay = System.DateTime.Now.AddDays(DayIndex);
                    AddWorkoutToCalendar(addWorkoutName, addWorkoutDay);
                }
            }
        }

        UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.OrderBy(x => x.Day).ToArray();
        UserBlobManager.GetComponent<UserBlobManager>().SaveDay();
        UIManager.GetComponent<UI_Manager>().SwitchStates("CalendarState");
        */
    }

	public void AddWorkoutToCalendar(string CurrentWorkoutName, System.DateTime Today)
	{
		DayWorkoutData tempDayWorkoutData = new DayWorkoutData ();
		tempDayWorkoutData.WorkoutName = CurrentWorkoutName;
		tempDayWorkoutData.WorkoutCompleted = false;
		tempDayWorkoutData.CompletedDateTime = System.DateTime.Now;
		tempDayWorkoutData.TotalWorkoutTime = 0;
		tempDayWorkoutData.TotalWorkoutWeight = 0;

		int DayIndex = -1;
		int NameIndex = -1;
		for(int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++ )
		{
			if((Today.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
			   (Today.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month ) &&
			   (Today.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
			{
				DayIndex = index;
				for(int WorkoutNameIndex = 0; WorkoutNameIndex < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length; WorkoutNameIndex++)
				{
					if(CurrentWorkoutName == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutNameIndex].WorkoutName)
					{
						NameIndex = WorkoutNameIndex;
					}
				}
			}
		}
		
		if (DayIndex < 0)
		{
			// add new day
			DayData tempDayData = new DayData ();
			tempDayData.Day = Today;
//			tempDayData.DayWorkoutArray.Add (tempDayWorkoutData);
			tempDayData.Add (tempDayWorkoutData);
			UserBlobManager.GetComponent<UserBlobManager> ().UserDayData.Add (tempDayData);
			UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.OrderBy(x => x.Day).ToArray();
			UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
		}
		else
		{
			if(NameIndex < 0)
			{
				//new workout
//				UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].DayWorkoutArray.Add(tempDayWorkoutData);
				UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].Add(tempDayWorkoutData);
				UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
			}
			else
			{
				// workout already exists, change completed bool and time
				UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].DayWorkoutArray[NameIndex].CompletedDateTime = Today;
				UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[DayIndex].DayWorkoutArray[NameIndex].WorkoutCompleted = true;
				UserBlobManager.GetComponent<UserBlobManager> ().SaveDay ();
			}
		}
	}

	public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true && UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length > 5)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length;
			float ScrollPercentage =  TrainingContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			TrainingContentPanel.localPosition = tempPos;
		}
		ScrollBarMove = true;
	}
	
	public void OnPanelValueChanged()
	{		
		ScrollBarMove = false;
		int ButtonHeight = 200;
		//		double ButtonOffset = 2.8;
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length;
		float ScrollValue =  ((TrainingContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		TrainingContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		myScrollPanel.localPosition = tempPos;
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
            case "DeleteTraining":
                if (DialogState == "ok")
                {
                    print("DeleteTraining ok");
                    DeleteTraining();
                }
                if (DialogState == "cancel")
                {
                    print("DeleteTraining cancel");
                }
                break;
        }
        PopUpYesNoDialogState = "";
        PopUpActive = false;
    }
}
