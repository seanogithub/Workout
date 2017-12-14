using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text.RegularExpressions;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class UI_Manager : MonoBehaviour {

	public InterstitialAd interstitial = null; //new InterstitialAd("ca-app-pub-8601678415603694/6106743363");
	public BannerView bannerAd = null;

	public string UIPreviousState = "SplashScreenState";
	public string UICurrentState = "SplashScreenState";
	public GameObject UserBlobManager;
	public GameObject UISplashScreen;
	public GameObject UICalendar;
	public GameObject UICalendarDay;
    public GameObject UIDownload;
    public GameObject UIDownloading;
    public GameObject UIUpload;
    public GameObject UIUploading;
    public GameObject UIHome;
	public GameObject UICreateExercise;
	public GameObject UINewExercise;
	public GameObject UIEditExercise;
    public GameObject UIExercisePreview;
    public GameObject UIFilterExercise;
	public GameObject UIWorkout;
	public GameObject UIWorkoutCompleted;
	public GameObject UINewWorkout;
	public GameObject UICreateWorkout;
	public GameObject UIEditWorkout;
	public GameObject UIEditWorkoutExercise;
	public GameObject UINewTraining;
	public GameObject UICreateTraining;
	public GameObject UIEditTraining;
	public GameObject UIDayPicker;
	public GameObject UIDayPickerWorkout;
	public GameObject UISettings;
	public GameObject UIShare;
	public GameObject UILogin;
    public GameObject UILoginAuto;
    public GameObject UINewUser;
    public GameObject UIDownloadTraining;
    public GameObject UIDownloadExercise;
    public GameObject UIDownloadWorkout;
    public GameObject UIShareTraining;
	public GameObject UIShareWorkout;
	public GameObject UIShareExercise;
	public GameObject UIShareFriendList;
	public GameObject UICreateFriendList;
	public GameObject UINewFriend;
    public GameObject UIFriendRequestList;
    public GameObject UILeaderboard;
    public GameObject UIStore;

    public bool SplashScreenState = false;
	public bool HomeState = false;
	public bool CalendarState = false;
	public bool CalendarDayState = false;
    public bool DownloadState = false;
    public bool DownloadingState = false;
    public bool UploadState = false;
    public bool UploadingState = false;
    public bool CreateExerciseState = false;
	public bool NewExerciseState = false;
	public bool FilterExerciseState = false;
	public bool EditExerciseState = false;
    public bool ExercisePreviewState = false;
    public bool WorkoutState = false;
	public bool WorkoutCompletedState = false;
	public bool NewWorkoutState = false;
	public bool CreateWorkoutState = false;
	public bool EditWorkoutState = false;
	public bool EditWorkoutExerciseState = false;
	public bool NewTrainingState = false;
	public bool CreateTrainingState = false;
	public bool EditTrainingState = false;
	public bool DayPickerState = false;
	public bool DayPickerWorkoutState = false;
	public bool SettingsState = false;
	public bool ShareState = false;
	public bool LoginState = false;
    public bool LoginAutoState = false;
    public bool NewUserState = false;
    public bool DownloadTrainingState = false;
    public bool DownloadWorkoutState = false;
    public bool DownloadExerciseState = false;
    public bool ShareTrainingState = false;
	public bool ShareWorkoutState = false;
	public bool ShareExerciseState = false;
	public bool ShareFriendListState = false;
	public bool CreateFriendListState = false;
	public bool NewFriendState = false;
    public bool FriendRequestListState = false;
    public bool LeaderboardState = false;
    public bool StoreState = false;

    public System.DateTime currentDate = new System.DateTime();
	
	public float PassCodeTimer = 120.0f;
	public System.DateTime LastTouch = new System.DateTime();
	

	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UISplashScreen = GameObject.Find("UI_SplashScreen_Prefab");
		UIHome = GameObject.Find("UI_Home_Prefab");
		UICalendar = GameObject.Find("UI_Calendar_Prefab");
		UICalendarDay = GameObject.Find("UI_CalendarDay_Prefab");
        UIDownload = GameObject.Find("UI_Download_Prefab");
        UIDownloading = GameObject.Find("UI_Downloading_Prefab");
        UIUpload = GameObject.Find("UI_Upload_Prefab");
        UIUploading = GameObject.Find("UI_Uploading_Prefab");
        UINewExercise = GameObject.Find("UI_NewExercise_Prefab");
		UICreateExercise = GameObject.Find("UI_CreateExercise_Prefab");
		UIEditExercise = GameObject.Find("UI_EditExercise_Prefab");
        UIExercisePreview = GameObject.Find("UI_ExercisePreview_Prefab");
        UIFilterExercise = GameObject.Find("UI_FilterExercise_Prefab");
		UIWorkout = GameObject.Find("UI_Workout_Prefab");
		UIWorkoutCompleted = GameObject.Find("UI_WorkoutCompleted_Prefab");
		UINewWorkout = GameObject.Find("UI_NewWorkout_Prefab");
		UICreateWorkout = GameObject.Find("UI_CreateWorkout_Prefab");
		UIEditWorkout = GameObject.Find("UI_EditWorkout_Prefab");
		UIEditWorkoutExercise = GameObject.Find("UI_EditWorkoutExercise_Prefab");
		UINewTraining = GameObject.Find("UI_NewTraining_Prefab");
		UICreateTraining = GameObject.Find("UI_CreateTraining_Prefab");
		UIEditTraining = GameObject.Find("UI_EditTraining_Prefab");
		UIDayPicker = GameObject.Find("UI_DayPicker_Prefab");
		UIDayPickerWorkout = GameObject.Find("UI_DayPickerWorkout_Prefab");
		UISettings = GameObject.Find("UI_Settings_Prefab");
		UIShare = GameObject.Find("UI_Share_Prefab");
		UILogin = GameObject.Find("UI_Login_Prefab");
        UILoginAuto = GameObject.Find("UI_LoginAuto_Prefab");
        UINewUser = GameObject.Find("UI_NewUser_Prefab");
        UIDownloadTraining = GameObject.Find("UI_DownloadTraining_Prefab");
        UIDownloadWorkout = GameObject.Find("UI_DownloadWorkout_Prefab");
        UIDownloadExercise = GameObject.Find("UI_DownloadExercise_Prefab");
        UIShareTraining = GameObject.Find("UI_ShareTraining_Prefab");
		UIShareWorkout = GameObject.Find("UI_ShareWorkout_Prefab");
		UIShareExercise = GameObject.Find("UI_ShareExercise_Prefab");
		UIShareFriendList = GameObject.Find("UI_ShareFriendList_Prefab");
		UICreateFriendList = GameObject.Find("UI_CreateFriendList_Prefab");
		UINewFriend = GameObject.Find("UI_NewFriend_Prefab");
        UIFriendRequestList = GameObject.Find("UI_FriendRequestList_Prefab");
        UILeaderboard = GameObject.Find("UI_Leaderboard_Prefab");
        UIStore = GameObject.Find("UI_Store_Prefab");
    }

    // Use this for initialization
    void Start () 
	{
		SetUIState();
		PassCodeTimer = 120;// UserBlobManager.GetComponent<UserBlobManager>().UserAppData.PassCodeTimer;
	}

	public void ShowBanner()
	{
		if(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds == false)
		{
			RequestBanner();
		}
	}

	public void ShowInterstitial()
	{
		if(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds == false)
		{
			int randomNumber = UnityEngine.Random.Range(0,9);
			if(randomNumber < 5)
			{
				RequestInterstitial();
			}
		}
	}

	public void HideBanner()
	{
		if(bannerAd != null)
		{
			bannerAd.Destroy();
		}
	}

	public void HideInterstitial()
	{
		if(interstitial != null)
		{
			interstitial.Destroy();
		}
	}

	private void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-8601678415603694/4490409362";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create a 320x50 banner at the bottom of the screen.
	 	bannerAd = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerAd.LoadAd(request);
		bannerAd.OnAdLoaded += HandleOnBannerAdLoaded;
		bannerAd.OnAdClosed += HandleOnBannerAdClosed;
	}

	private void RequestInterstitial()
	{
		#if UNITY_ANDROID
		string adUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-8601678415603694/6106743363";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		//AdRequest request = new AdRequest.Builder()
		//	.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
		//	.AddTestDevice("eb25e9b1fe3f3cf72a495961562327212b4dd8d9")  // My test device.
		//	.Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		interstitial.OnAdLoaded += HandleOnInterstitialAdLoaded;
		interstitial.OnAdClosed += HandleOnInterstitialAdClosed;
	}

	public void HandleOnBannerAdLoaded(object sender, EventArgs args)
	{
		print("OnAdLoaded event received.");
		// Handle the ad loaded event.
		// show ad
		if(bannerAd != null)
		{
			if (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds == false) 
			{
				bannerAd.Show();
			}
		}
	}

	public void HandleOnInterstitialAdLoaded(object sender, EventArgs args)
	{
		print("OnAdLoaded event received.");
		// Handle the ad loaded event.
		// show ad
		if(interstitial != null)
		{
			if (interstitial.IsLoaded() && UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds == false) 
			{
				interstitial.Show();
			}
		}
	}

	public void HandleOnBannerAdClosed(object sender, EventArgs args)
	{
		if(bannerAd != null)
		{
			bannerAd.Destroy();
		}
	}

	public void HandleOnInterstitialAdClosed(object sender, EventArgs args)
	{
		if(interstitial != null)
		{
			interstitial.Destroy();
		}
	}

	public void ResetManagerData()
	{
//		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
//		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
	}
	
	public void SetCurrentDate(System.DateTime newDate)
	{
		currentDate = new System.DateTime(newDate.Year, newDate.Month, newDate.Day, newDate.Hour, newDate.Minute, newDate.Second);
	}
	
	public void SwitchStates(string myNewState)
	{
		// check for valid states
		if(	myNewState == "SplashScreenState" ||
			myNewState == "HomeState" ||
		   myNewState == "CalendarState" ||
		   myNewState == "CalendarDayState" ||
           myNewState == "DownloadState" ||
           myNewState == "DownloadingState" ||
           myNewState == "UploadState" ||
           myNewState == "UploadingState" ||
           myNewState == "NewExerciseState" ||
		   myNewState == "CreateExerciseState" ||
		   myNewState == "EditExerciseState" ||
           myNewState == "ExercisePreviewState" ||
           myNewState == "FilterExerciseState" ||
		   myNewState == "WorkoutState" ||
		   myNewState == "WorkoutCompletedState" ||
		   myNewState == "NewWorkoutState" ||
		   myNewState == "CreateExerciseState" ||
		   myNewState == "CreateWorkoutState" ||
		   myNewState == "EditWorkoutState" ||
		   myNewState == "EditWorkoutExerciseState" ||
		   myNewState == "NewTrainingState" ||
		   myNewState == "CreateTrainingState" ||
		   myNewState == "EditTrainingState" ||
		   myNewState == "DayPickerState" ||
		   myNewState == "DayPickerWorkoutState" ||
		   myNewState == "SettingsState" ||
		   myNewState == "ShareState" ||
		   myNewState == "LoginState" ||
           myNewState == "LoginAutoState" ||
           myNewState == "NewUserState" ||
           myNewState == "DownloadTrainingState" ||
           myNewState == "DownloadWorkoutState" ||
           myNewState == "DownloadExerciseState" ||
           myNewState == "ShareTrainingState" ||
		   myNewState == "ShareWorkoutState" ||
		   myNewState == "ShareExerciseState" ||
		   myNewState == "ShareFriendListState" ||
		   myNewState == "CreateFriendListState" ||
		   myNewState == "NewFriendState" ||
           myNewState == "LeaderboardState" ||
           myNewState == "StoreState" ||
           myNewState == "FriendRequestListState"
		   )
		{
			UICurrentState = myNewState;
			SetUIState();
		}
		
	}

	void SetUIState () 
	{
		HideInterstitial();
		HideBanner();

		SplashScreenState = false;
		HomeState = false;
		CalendarState = false;
		CalendarDayState = false;
        DownloadState = false;
        DownloadingState = false;
        UploadState = false;
        UploadingState = false;
        NewExerciseState = false;
		CreateExerciseState = false;
		EditExerciseState = false;
        ExercisePreviewState = false;
        FilterExerciseState = false;
		WorkoutState = false;
		WorkoutCompletedState = false;
		NewWorkoutState = false;
		CreateWorkoutState = false;
		EditWorkoutState = false;
		EditWorkoutExerciseState = false;
		NewTrainingState = false;
		CreateTrainingState = false;
		EditTrainingState = false;
		DayPickerState = false;
		DayPickerWorkoutState = false;
		SettingsState = false;
		ShareState = false;
		LoginState = false;
        LoginAutoState = false;
        NewUserState = false;
        DownloadTrainingState = false;
        DownloadWorkoutState = false;
        DownloadExerciseState = false;
        ShareTrainingState = false;
		ShareWorkoutState = false;
		ShareExerciseState = false;
		ShareFriendListState = false;
		CreateFriendListState = false;
		NewFriendState = false;
        FriendRequestListState = false;
        LeaderboardState = false;
        StoreState = false;

        switch (UICurrentState)
		{
		case "SplashScreenState":
			SplashScreenState = true;
			break;	
		case "HomeState":
			HomeState = true;
			break;
		case "CalendarState":
			CalendarState = true;
			break;
		case "CalendarDayState":
			CalendarDayState = true;
			break;
        case "DownloadingState":
            DownloadingState = true;
            break;
        case "UploadState":
            UploadState = true;
            break;
        case "UploadingState":
            UploadingState = true;
            break;
        case "DownloadState":
            DownloadState = true;
            break;
        case "NewExerciseState":
    		NewExerciseState = true;
	    	break;
		case "CreateExerciseState":
			CreateExerciseState = true;
			break;
		case "EditExerciseState":
			EditExerciseState = true;
		break;
        case "ExercisePreviewState":
            ExercisePreviewState = true;
            break;
        case "FilterExerciseState":
			FilterExerciseState = true;
			break;
		case "WorkoutState":
			WorkoutState = true;
			break;
		case "WorkoutCompletedState":
			WorkoutCompletedState = true;
			break;
		case "NewWorkoutState":
			NewWorkoutState = true;
			break;
		case "CreateWorkoutState":
			CreateWorkoutState = true;
			break;
		case "EditWorkoutState":
			EditWorkoutState = true;
			break;
		case "EditWorkoutExerciseState":
			EditWorkoutExerciseState = true;
			break;
		case "NewTrainingState":
			NewTrainingState = true;
			break;
		case "CreateTrainingState":
			CreateTrainingState = true;
			break;
		case "EditTrainingState":
			EditTrainingState = true;
			break;
		case "DayPickerState":
			DayPickerState = true;
			break;
		case "DayPickerWorkoutState":
			DayPickerWorkoutState = true;
			break;
		case "SettingsState":
			SettingsState = true;
			break;
		case "ShareState":
			ShareState = true;
			break;
        case "LoginState":
            LoginState = true;
            break;
        case "LoginAutoState":
			LoginAutoState = true;
			break;
		case "NewUserState":
			NewUserState = true;
			break;
		case "ShareTrainingState":
			ShareTrainingState = true;
			break;
		case "ShareWorkoutState":
			ShareWorkoutState = true;
			break;
        case "DownloadTrainingState":
            DownloadTrainingState = true;
            break;
        case "DownloadWorkoutState":
            DownloadWorkoutState = true;
            break;
        case "DownloadExerciseState":
            DownloadExerciseState = true;
            break;
        case "ShareExerciseState":
			ShareExerciseState = true;
			break;
		case "ShareFriendListState":
			ShareFriendListState = true;
			break;
		case "CreateFriendListState":
			CreateFriendListState = true;
			break;
		case "NewFriendState":
			NewFriendState = true;
			break;
        case "FriendRequestListState":
            FriendRequestListState = true;
            break;
        case "LeaderboardState":
            LeaderboardState = true;
            break;
        case "StoreState":
            StoreState = true;
            break;
        }

		UISplashScreen.SetActive(SplashScreenState);
		UIHome.SetActive(HomeState);
		UICalendar.SetActive(CalendarState);
		UICalendarDay.SetActive(CalendarDayState);
        UIDownload.SetActive(DownloadState);
        UIDownloading.SetActive(DownloadingState);
        UIUpload.SetActive(UploadState);
        UIUploading.SetActive(UploadingState);
        UINewExercise.SetActive(NewExerciseState);
		UICreateExercise.SetActive(CreateExerciseState);
		UIEditExercise.SetActive(EditExerciseState);
        UIExercisePreview.SetActive(ExercisePreviewState);
        UIFilterExercise.SetActive(FilterExerciseState);
		UIWorkout.SetActive(WorkoutState);
		UIWorkoutCompleted.SetActive(WorkoutCompletedState);
		UINewWorkout.SetActive(NewWorkoutState);
		UICreateWorkout.SetActive(CreateWorkoutState);
		UIEditWorkout.SetActive(EditWorkoutState);
		UIEditWorkoutExercise.SetActive(EditWorkoutExerciseState);
		UINewTraining.SetActive(NewTrainingState);
		UICreateTraining.SetActive(CreateTrainingState);
		UIEditTraining.SetActive(EditTrainingState);
		UIDayPicker.SetActive(DayPickerState);
		UIDayPickerWorkout.SetActive(DayPickerWorkoutState);
		UISettings.SetActive(SettingsState);
		UIShare.SetActive(ShareState);
		UILogin.SetActive(LoginState);
        UILoginAuto.SetActive(LoginAutoState);
        UINewUser.SetActive(NewUserState);
        UIDownloadTraining.SetActive(DownloadTrainingState);
        UIDownloadWorkout.SetActive(DownloadWorkoutState);
        UIDownloadExercise.SetActive(DownloadExerciseState);
        UIShareTraining.SetActive(ShareTrainingState);
		UIShareWorkout.SetActive(ShareWorkoutState);
		UIShareExercise.SetActive(ShareExerciseState);
		UIShareFriendList.SetActive(ShareFriendListState);
		UICreateFriendList.SetActive(CreateFriendListState);
		UINewFriend.SetActive(NewFriendState);
        UIFriendRequestList.SetActive(FriendRequestListState);
        UILeaderboard.SetActive(LeaderboardState);
        UIStore.SetActive(StoreState);

        if (SplashScreenState)
		{
		}
		if (HomeState)
		{
			UIHome.GetComponent<UI_Home>().Initialize = true;
			ShowInterstitial();
		}
		if (WorkoutCompletedState)
		{
			UIWorkoutCompleted.GetComponent<UI_WorkoutCompleted>().Initialize = true;
		}
		if (WorkoutState)
		{
			UIWorkout.GetComponent<UI_Workout>().Initialize = true;
		}
		if (NewWorkoutState)
		{
			UINewWorkout.GetComponent<UI_NewWorkout>().Initialize = true;
		}
		if (CreateWorkoutState)
		{
			UICreateWorkout.GetComponent<UI_CreateWorkout>().Initialize = true;
			ShowBanner();
		}
		if (EditWorkoutState)
		{
			if(UIPreviousState == "EditWorkoutExerciseState")
			{
				UIEditWorkout.GetComponent<UI_EditWorkout>().UpdateUIFlag = true;
			}
			else
			{
				UIEditWorkout.GetComponent<UI_EditWorkout>().Initialize = true;
			}
		}
		if (EditWorkoutExerciseState)
		{
			UIEditWorkoutExercise.GetComponent<UI_EditWorkoutExercise>().Initialize = true;
		}
		if (NewExerciseState)
		{
			UINewExercise.GetComponent<UI_NewExercise>().Initialize = true;
		}
		if (CreateExerciseState)
		{
			UICreateExercise.GetComponent<UI_CreateExercise>().Initialize = true;
			ShowBanner();
		}
		if (EditExerciseState)
		{
			UIEditExercise.GetComponent<UI_EditExercise>().Initialize = true;
		}
        if (ExercisePreviewState)
        {
            UIExercisePreview.GetComponent<UI_ExercisePreview>().Initialize = true;
        }
        if (NewTrainingState)
		{
			UINewTraining.GetComponent<UI_NewTraining>().Initialize = true;
		}
		if (CreateTrainingState)
		{
			UICreateTraining.GetComponent<UI_CreateTraining>().Initialize = true;
			ShowBanner();
		}
		if (EditTrainingState)
		{
			UIEditTraining.GetComponent<UI_EditTraining>().Initialize = true;
		}
		if (FilterExerciseState)
		{
			UIFilterExercise.GetComponent<UI_FilterExercise>().Initialize = true;
		}
		if (DayPickerState)
		{
			UIDayPicker.GetComponent<UI_DayPicker>().Initialize = true;
		}
		if (DayPickerWorkoutState)
		{
			UIDayPickerWorkout.GetComponent<UI_DayPickerWorkout>().Initialize = true;
		}
		if (SettingsState)
		{
			UISettings.GetComponent<UI_Settings>().Initialize = true;
			ShowBanner();
		}
		if (CalendarState)
		{
			UICalendar.GetComponent<UI_Calendar>().Initialize = true;
		}
		if (CalendarDayState)
		{
			UICalendarDay.GetComponent<UI_CalendarDay>().Initialize = true;
		}
        if (DownloadState)
        {
            UIDownload.GetComponent<UI_Download>().Initialize = true;
        }
        if (DownloadingState)
        {
            UIDownloading.GetComponent<UI_Downloading>().Initialize = true;
        }
        if (UploadState)
        {
            UIUpload.GetComponent<UI_Upload>().Initialize = true;
        }
        if (UploadingState)
        {
            UIUploading.GetComponent<UI_Uploading>().Initialize = true;
        }
        if (ShareState)
		{
			UIShare.GetComponent<UI_Share>().Initialize = true;
		}
		if (LoginState)
		{
			UILogin.GetComponent<UI_Login>().Initialize = true;
		}
        if (LoginAutoState)
        {
            UILoginAuto.GetComponent<UI_LoginAuto>().Initialize = true;
        }
        if (NewUserState)
		{
			UINewUser.GetComponent<UI_NewUser>().Initialize = true;
		}
        if (DownloadTrainingState)
        {
            UIDownloadTraining.GetComponent<UI_DownloadTraining>().Initialize = true;
        }
        if (DownloadWorkoutState)
        {
            UIDownloadWorkout.GetComponent<UI_DownloadWorkout>().Initialize = true;
        }
        if (DownloadExerciseState)
        {
            UIDownloadExercise.GetComponent<UI_DownloadExercise>().Initialize = true;
        }
        if (ShareTrainingState)
		{
			UIShareTraining.GetComponent<UI_ShareTraining>().Initialize = true;
		}
		if (ShareWorkoutState)
		{
			UIShareWorkout.GetComponent<UI_ShareWorkout>().Initialize = true;
		}
		if (ShareExerciseState)
		{
			UIShareExercise.GetComponent<UI_ShareExercise>().Initialize = true;
		}
		if (ShareFriendListState)
		{
			UIShareFriendList.GetComponent<UI_ShareFriendList>().Initialize = true;
		}
		if (CreateFriendListState)
		{
			UICreateFriendList.GetComponent<UI_CreateFriendList>().Initialize = true;
		}
		if (NewFriendState)
		{
			UINewFriend.GetComponent<UI_NewFriend>().Initialize = true;
		}
        if (FriendRequestListState)
        {
            UIFriendRequestList.GetComponent<UI_FriendRequestList>().Initialize = true;
        }
        if (LeaderboardState)
        {
            UILeaderboard.GetComponent<UI_Leaderboard>().Initialize = true;
			ShowBanner();
        }
        if (StoreState)
        {
            UIStore.GetComponent<UI_Store>().Initialize = true;
			ShowBanner();
        }

        UIPreviousState = UICurrentState;
	}
	

	void Update()
	{
		if (UIPreviousState != UICurrentState)
		{
			SetUIState();
		}

		if (Input.touchCount != 0 ||
			Input.GetMouseButtonDown(0))
		{
			LastTouch = System.DateTime.Now;
		}
		
		if(LastTouch.AddMinutes((float)(PassCodeTimer/60)) <  System.DateTime.Now && PassCodeTimer > 0)
		{
//			print("test");
		}
	}
}
