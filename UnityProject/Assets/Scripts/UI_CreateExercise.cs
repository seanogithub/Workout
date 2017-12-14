using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UI_CreateExercise : MonoBehaviour {
	
	public bool Initialize = false;
	public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject exerciseButton;
	
//	public List<ExerciseData> UserExerciseData = new List<ExerciseData>();	
	public SaveExerciseData UserExerciseData;
//	public List<WorkoutData> UserWorkoutData = new List<WorkoutData>();
	public SaveWorkoutData UserWorkoutData;
	public ExerciseData item = new ExerciseData();

	public List<GameObject> ExerciseButtonArray = new List<GameObject>();

	public Transform ExerciseContentPanel;
	public GameObject ExerciseContentPanelScrollBar;
	public bool ScrollBarMove = false;

	public int SelectedExercise = -1;

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
		UserExerciseData = new SaveExerciseData ();
		UserWorkoutData = new SaveWorkoutData ();
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
		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;

        if(UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex > UserExerciseData.Exercise.Length)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex = 0;
        }

        if(UserExerciseData.Exercise.Length == 0)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex = -1;
        }
        if(UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex < 0 && UserExerciseData.Exercise.Length > 0)
        {
            UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex = 0;
        }

        SelectedExercise = UserBlobManager.GetComponent<UserBlobManager>().CurrentExerciseIndex;
        int scrollIndex = SelectedExercise;
        if (scrollIndex > UserExerciseData.Exercise.Length - 6)
        {
            scrollIndex = UserExerciseData.Exercise.Length - 6;
        }

        ClearScrollList ();
		PopulateScrollList ();

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (scrollIndex, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length, ExerciseContentPanel);
		}
		else
		{
			ExerciseContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}

	public void ClearScrollList()
	{
		for (int i = ExerciseContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(ExerciseContentPanel.GetChild(i).gameObject);
		}
	}

	public void PopulateScrollList () 
	{
		ExerciseButtonArray.Clear ();
		foreach (var item in UserExerciseData.Exercise)
		{
			GameObject newButton = Instantiate (exerciseButton) as GameObject;
			ExerciseButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
//			string tempText = item.Name;
//			if(item.Weight > 0) {tempText += ("-" + item.Weight + "lbs");}
//			if(item.Reps > 0) {tempText += ("-" + item.Reps + "reps");}
//			newButton.GetComponentInChildren<Text>().text = tempText;
//			newButton.GetComponentInChildren<Text>().fontSize = 50;
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
            newButton.transform.Find("Text_Time").GetComponent<Text>().text = item.BodyPart;

            string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => ExerciseButtonClicked(selectedButton));
			newButton.transform.SetParent (ExerciseContentPanel);
		}
		if(ExerciseButtonArray.Count > 0)
		{
			ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = SelectedColor;
		}
	}

	public void ExerciseButtonClicked(string myText)
	{
		ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = Color.white;
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindExerciseByName (myText);
		SelectedExercise = myIndex;
		UserBlobManager.GetComponent<UserBlobManager> ().CurrentExerciseIndex = myIndex;
		ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = SelectedColor;
	}

	public void DeleteExercise()
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().CurrentExerciseIndex;
		if(myIndex < UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length)
		{
			UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.RemoveAt(myIndex);
//			UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.TrimExcess();
			UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
			UserBlobManager.GetComponent<UserBlobManager> ().SaveExercise();
			if(myIndex >= UserExerciseData.Exercise.Length)
			{
				myIndex = UserExerciseData.Exercise.Length - 1;
				UserBlobManager.GetComponent<UserBlobManager> ().CurrentExerciseIndex = myIndex;
			}
			SelectedExercise = myIndex;
			ClearScrollList ();
			PopulateScrollList ();
		}
	}

    public void OnDeleteButtonPressed()
    {
        if(SelectedExercise >= 0)
        {
            if (PopUpActive == false)
            {
                PopUpYesNoDialog("Are you sure you want to delete this exercise?", this.gameObject.GetComponent<UI_CreateExercise>(), "DeleteExercise");
            }
        }
    }

    public void OnEditButtonPressed()
    {
        if (SelectedExercise >= 0)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("EditExerciseState");
        }
    }

    public void OnPreviewButtonPressed()
    {
        if (SelectedExercise >= 0)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("ExercisePreviewState");
        }
    }

    public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length;
			float ScrollPercentage =  ExerciseContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			ExerciseContentPanel.localPosition = tempPos;
		}
		ScrollBarMove = true;
	}

	public void OnPanelValueChanged()
	{		
		ScrollBarMove = false;
		int ButtonHeight = 200;
//		double ButtonOffset = 2.8;
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length;
		float ScrollValue =  ((ExerciseContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		ExerciseContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
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
            case "DeleteExercise":
                if (DialogState == "ok")
                {
                    print("DeleteExercise ok");
                    DeleteExercise();
                }
                if (DialogState == "cancel")
                {
                    print("DeleteExercise cancel");
                }
                break;
        }
        PopUpYesNoDialogState = "";
        PopUpActive = false;
    }
}
