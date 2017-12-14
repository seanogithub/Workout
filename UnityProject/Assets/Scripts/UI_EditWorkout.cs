using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

public class UI_EditWorkout : MonoBehaviour {

	public bool Initialize = false;
	public bool UpdateUIFlag = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;

	public GameObject BackgroundImage;
	private Sprite[] EditWorkoutBackgroundBitmaps; 
	private Timer BackgroundTimer = new Timer();

	public GameObject UIText_WorkoutName;

	public GameObject WorkoutButton;
	public GameObject ExerciseButton;

//	public List<ExerciseData> UserExerciseData = new List<ExerciseData>();	
	public SaveExerciseData UserExerciseData;
//	public List<WorkoutData> UserWorkoutData = new List<WorkoutData>();
	public SaveWorkoutData UserWorkoutData;

	public WorkoutData CurrentWorkout = new WorkoutData();

	public Transform WorkoutContentPanel;
	public Transform ExerciseContentPanel;

	public GameObject ExerciseContentPanelScrollBar;
	public bool ExerciseScrollBarMove = false;
	public GameObject WorkoutContentPanelScrollBar;
	public bool WorkoutScrollBarMove = false;

	public List<GameObject> WorkoutButtonArray = new List<GameObject>();
	public List<GameObject> ExerciseButtonArray = new List<GameObject>();

	public int SelectedExercise = 0;
	public int SelectedWorkoutExcercise = 0;

	private int NumFilteredExercises;

	public Color SelectedColor = Color.red;

	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
//		EditWorkoutBackgroundBitmaps = Resources.LoadAll<Sprite>("UI/EditWorkoutBackground");  
		BackgroundTimer.Interval = 1000/30;
		BackgroundTimer.Elapsed += new ElapsedEventHandler (OnBackgroundTimeEvent);
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

		BackgroundTimer.Start();

		CurrentWorkout = new WorkoutData();
		CurrentWorkout.Name = "";
		CurrentWorkout.Description = "";
//		CurrentWorkout.ExerciseArray = new List<ExerciseData>();
		CurrentWorkout.ExerciseArray = new SaveExerciseData();

//		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
//		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;

		int CurrentWorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;
		CurrentWorkout.Name = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].Name;
		CurrentWorkout.Description = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].Description;
        CurrentWorkout.Type = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData.Workout[CurrentWorkoutIndex].Type;

//		CurrentWorkout.ExerciseArray = new List<ExerciseData>(UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].ExerciseArray);
        CurrentWorkout.ExerciseArray = (UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].ExerciseArray);

		UIText_WorkoutName.GetComponent<Text> ().text = CurrentWorkout.Name;

		SelectedExercise = 0;
		SelectedWorkoutExcercise = 0;

		ClearExerciseScrollList ();
		PopulateExerciseScrollList ();
		ClearWorkoutScrollList ();
		PopulateWorkoutScrollList ();
		if(CurrentWorkout.ExerciseArray.Exercise.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.6, 100, CurrentWorkout.ExerciseArray.Exercise.Length, WorkoutContentPanel);
		}
		else
		{
			WorkoutContentPanel.localPosition = new Vector3 (0, 0, 0);
		}
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length > 8)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.6, 100, NumFilteredExercises, ExerciseContentPanel);
		}
		else
		{
			ExerciseContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}

	}

	public void UpdateUI()
	{
		UpdateUIFlag = false;
		ClearExerciseScrollList ();
		PopulateExerciseScrollList ();
		ClearWorkoutScrollList ();
		PopulateWorkoutScrollList ();
	}

	public void OnBackgroundTimeEvent(object source, ElapsedEventArgs e)
	{
	}

	public void ClearExerciseScrollList()
	{
		for (int i = ExerciseContentPanel.childCount - 1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(ExerciseContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateExerciseScrollList () 
	{
//		UserExerciseData.Clear ();
		UserExerciseData = new SaveExerciseData ();
		ExerciseButtonArray.Clear ();
		NumFilteredExercises = 0;
		string ExerciseFilterTypeString = UserBlobManager.GetComponent<UserBlobManager> ().ExerciseFilterType;
		string ExerciseFilterBodyPartString = UserBlobManager.GetComponent<UserBlobManager> ().ExerciseFilterBodyPart;
		foreach (var item in UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise)
		{
			if(((ExerciseFilterTypeString == "None") ||
			   (ExerciseFilterTypeString == item.Type)) &&
			   ((ExerciseFilterBodyPartString == "None") ||
			 (ExerciseFilterBodyPartString == item.BodyPart)))
			{
				UserExerciseData.Add(item);
				NumFilteredExercises++;
				GameObject newButton = Instantiate (ExerciseButton) as GameObject;
				ExerciseButtonArray.Add(newButton);
				newButton.name = ("Button_" + item.Name);
				string tempText = item.Name;
				newButton.GetComponentInChildren<Text>().text = tempText;
				newButton.GetComponentInChildren<Text>().fontSize = 50;
				string selectedButton = item.Name;
				newButton.GetComponent<Button>().onClick.AddListener(() => ExcerciseButtonClicked(selectedButton));
				newButton.transform.SetParent (ExerciseContentPanel);
			}
		}
		if(ExerciseButtonArray.Count > 0)
		{
			ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = SelectedColor;
		}
	}

	public void ClearWorkoutScrollList()
	{
		for (int i = WorkoutContentPanel.childCount - 1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(WorkoutContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateWorkoutScrollList () 
	{
		int count = 0;
		WorkoutButtonArray.Clear ();
		foreach (var item in CurrentWorkout.ExerciseArray.Exercise)
		{
			GameObject newButton = Instantiate (ExerciseButton) as GameObject;
			WorkoutButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			string tempText = item.Name;
			newButton.GetComponentInChildren<Text>().text = tempText;
			newButton.GetComponentInChildren<Text>().fontSize = 50;
//			string selectedButton = item.Name;
//			newButton.GetComponent<Button>().onClick.AddListener(() => WorkoutButtonClicked(selectedButton));
			int tempIndex = count;
			newButton.GetComponent<Button>().onClick.AddListener(() => WorkoutButtonClicked(tempIndex));
			newButton.transform.SetParent (WorkoutContentPanel);
			count++;
		}
		if (WorkoutButtonArray.Count > 0)
		{
			WorkoutButtonArray[SelectedWorkoutExcercise].GetComponent<Image> ().color = SelectedColor;
		}
	}

	public void ExcerciseButtonClicked(string myText)
	{
		ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = Color.white;
//		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindExerciseByName (myText);
		int myIndex = FindExerciseByName (myText);
		SelectedExercise = myIndex;
		ExerciseButtonArray[myIndex].GetComponent<Image> ().color = SelectedColor;
	}

	public void WorkoutButtonClicked(int myIndex)
	{
		WorkoutButtonArray[SelectedWorkoutExcercise].GetComponent<Image> ().color = Color.white;
		SelectedWorkoutExcercise = myIndex;
		WorkoutButtonArray[myIndex].GetComponent<Image> ().color = SelectedColor;
	}

	public void AddButtonPressed()
	{
		ExerciseData tempExercise = new ExerciseData ();
//		tempExercise = tempExercise.DeepCopy(UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData[SelectedExercise]);
		tempExercise = tempExercise.DeepCopy(UserExerciseData.Exercise[SelectedExercise]);
		CurrentWorkout.ExerciseArray.Add (tempExercise);
		ClearWorkoutScrollList ();
		PopulateWorkoutScrollList ();
	}

	public void DeleteButtonPressed()
	{
		CurrentWorkout.ExerciseArray.RemoveAt (SelectedWorkoutExcercise);
		SelectedWorkoutExcercise--;
		if(SelectedWorkoutExcercise < 0) { SelectedWorkoutExcercise = 0;}

		ClearWorkoutScrollList ();
		PopulateWorkoutScrollList ();
	}

	public void EditExerciseButtonPressed()
	{
		//BackgroundTimer.Stop();
		UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutExerciseState");
	}

	public void InsertButtonPressed()
	{
		ExerciseData tempExercise = new ExerciseData ();
//		tempExercise = tempExercise.DeepCopy(UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData[SelectedExercise]);
		tempExercise = tempExercise.DeepCopy(UserExerciseData.Exercise[SelectedExercise]);
		CurrentWorkout.ExerciseArray.Insert (SelectedWorkoutExcercise,tempExercise);
		ClearWorkoutScrollList ();
		PopulateWorkoutScrollList ();
	}

	public void MoveDownButtonPressed()
	{
		if(SelectedWorkoutExcercise < CurrentWorkout.ExerciseArray.Exercise.Length - 1)
		{
			ExerciseData tempExercise = new ExerciseData ();
			tempExercise = tempExercise.DeepCopy(CurrentWorkout.ExerciseArray.Exercise[SelectedWorkoutExcercise]);
			CurrentWorkout.ExerciseArray.RemoveAt (SelectedWorkoutExcercise);
//			CurrentWorkout.ExerciseArray.TrimExcess ();
			SelectedWorkoutExcercise++;
			CurrentWorkout.ExerciseArray.Insert (SelectedWorkoutExcercise, tempExercise);
			ClearWorkoutScrollList ();
			PopulateWorkoutScrollList ();
		}
	}

	public void MoveUpButtonPressed()
	{
		if(SelectedWorkoutExcercise > 0)
		{
			ExerciseData tempExercise = new ExerciseData ();
			tempExercise = tempExercise.DeepCopy(CurrentWorkout.ExerciseArray.Exercise[SelectedWorkoutExcercise]);
			CurrentWorkout.ExerciseArray.RemoveAt (SelectedWorkoutExcercise);
//			CurrentWorkout.ExerciseArray.TrimExcess ();
			SelectedWorkoutExcercise--;
			CurrentWorkout.ExerciseArray.Insert (SelectedWorkoutExcercise, tempExercise);
			ClearWorkoutScrollList ();
			PopulateWorkoutScrollList ();
		}
	}

	public void FilterButtonPressed()
	{
		BackgroundTimer.Stop();
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("FilterExerciseState");
	}

	public void OkButtonPressed()
	{
		BackgroundTimer.Stop();
		// copy data from UI to User Blob
		int CurrentWorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;
		UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].ExerciseArray = CurrentWorkout.ExerciseArray;
		
		// save data
		UserBlobManager.GetComponent<UserBlobManager> ().SaveWorkout ();
		
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
	}

	public void CancelButtonPressed()
	{
		BackgroundTimer.Stop();
		// switch states
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
	}

	public void OnWorkoutScrollBarChanged()
	{
		if (WorkoutScrollBarMove == true && CurrentWorkout.ExerciseArray.Exercise.Length > 6)
		{
			int ButtonHeight = 100;
			double ButtonOffset = 2.6;
			int NumButtons = CurrentWorkout.ExerciseArray.Exercise.Length;
			float ScrollPercentage =  WorkoutContentPanelScrollBar.GetComponent<Scrollbar>().value * (CurrentWorkout.ExerciseArray.Exercise.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			WorkoutContentPanel.localPosition = tempPos;
		}
		WorkoutScrollBarMove = true;
	}
	
	public void OnWorkoutPanelValueChanged()
	{		
		WorkoutScrollBarMove = false;
		if (CurrentWorkout.ExerciseArray.Exercise.Length > 6)
		{
			int ButtonHeight = 100;
			//			double ButtonOffset = 2.6;
			int NumButtons = CurrentWorkout.ExerciseArray.Exercise.Length;
			float ScrollValue =  ((WorkoutContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
			WorkoutContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
		}
	}

	public void OnExerciseScrollBarChanged()
	{
		if (ExerciseScrollBarMove == true && NumFilteredExercises > 6)
		{
			int ButtonHeight = 100;
			double ButtonOffset = 2.6;
			int NumButtons = NumFilteredExercises;
			float ScrollPercentage =  ExerciseContentPanelScrollBar.GetComponent<Scrollbar>().value * (NumFilteredExercises - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			ExerciseContentPanel.localPosition = tempPos;
		}
		ExerciseScrollBarMove = true;
	}
	
	public void OnExercisePanelValueChanged()
	{		
		ExerciseScrollBarMove = false;
		if (NumFilteredExercises > 6)
		{
			int ButtonHeight = 100;
//			double ButtonOffset = 2.6;
			int NumButtons = NumFilteredExercises;
			float ScrollValue =  ((ExerciseContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
			ExerciseContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
		}
	}

	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		//myScrollPanel.transform.localPosition = tempPos;
		myScrollPanel.localPosition = tempPos;
	}

	public int FindExerciseByName(string SearchText)
	{
		int foundIndex = -1;
		for (var i = 0; i < UserExerciseData.Exercise.Length; i++) 
		{
			if (UserExerciseData.Exercise[i].Name == SearchText)
			{
				foundIndex = i;
				return foundIndex;
			}
		}
		return foundIndex;
	}
}
