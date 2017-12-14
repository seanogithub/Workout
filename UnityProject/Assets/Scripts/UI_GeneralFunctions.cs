using UnityEngine;
using System.Collections;

public class UI_GeneralFunctions : MonoBehaviour {

	public GameObject UIManager;

	// Use this for initialization
	void Start () 
	{
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	public void UIGoHome()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("HomeState");
	}
	public void UICalendar()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("CalendarState");
	}
	public void UIStartWorkout()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("WorkoutState");
	}
	public void UINewExercise()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("NewExerciseState");
	}
	public void UICreateExercise()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateExerciseState");
	}
	public void UICreateTraining()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateTrainingState");
	}
	public void UIEditTraining()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("EditTrainingState");
	}
	public void UINewTraining()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("NewTrainingState");
	}
	public void UIEditExercise()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("EditExerciseState");
	}
    public void UIExercisePreview()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("ExercisePreviewState");
    }
    public void UINewWorkout()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("NewWorkoutState");
	}
	public void UICreateWorkout()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
	}
	public void UIEditWorkout()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutState");
	}
	public void UIEditExerciseWorkout()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("EditWorkoutExerciseState");
	}
	public void UIDayPicker()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("DayPickerState");
	}
	public void UISettings()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("SettingsState");
	}
	public void UIShare()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
	}
	public void UILogin()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
	}
    public void UILoginAuto()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("LoginAutoState");
    }
    public void UINewUser()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("NewUserState");
	}
    public void UIDownloadTraining()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadTrainingState");
    }
    public void UIDownloadWorkout()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadWorkoutState");
    }
    public void UIDownloadExercise()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadExerciseState");
    }
    public void UIShareTraining()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("ShareTrainingState");
	}
	public void UIShareWorkout()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("ShareWorkoutState");
	}
	public void UIShareExercise()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("ShareExerciseState");
	}
	public void UIShareFriendList()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("ShareFriendListState");
	}
	public void UICreateFriendList()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateFriendListState");
	}
	public void UINewFriend()
	{
		UIManager.GetComponent<UI_Manager>().SwitchStates("NewFriendState");
	}
    public void UIDownload()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadState");
    }
    public void UIDownloading()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("DownloadingState");
    }
    public void UIUpload()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("UploadState");
    }
    public void UIUploading()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("UploadingState");
    }
    public void UIFriendRequestList()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("FriendRequestListState");
    }
    public void UILeaderboard()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("LeaderboardState");
    }
    public void UIStore()
    {
        UIManager.GetComponent<UI_Manager>().SwitchStates("StoreState");
    }
}
