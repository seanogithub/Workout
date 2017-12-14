using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class UI_Home : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject UICalendar;

	public GameObject BackgroundImage;
	private Sprite[] HomeBackgroundBitmaps; 
	private Timer BackgroundTimer = new Timer();

	//public InterstitialAd interstitial = null; //new InterstitialAd("ca-app-pub-8601678415603694/6106743363");

	public string PopUpYesNoDialogState = "";
	public string PopUpOkDialogState = "";
	public bool PopUpActive = false;

	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
		UICalendar = GameObject.Find("UI_Calendar_Prefab");
	}

	// Use this for initialization
	void Start () 
	{
		EasyTTSUtil.Initialize (EasyTTSUtil.UnitedStates);
//		HomeBackgroundBitmaps = Resources.LoadAll<Sprite>("UI/HomeBackground");  
		BackgroundTimer.Interval = 1000/15;
		BackgroundTimer.Elapsed += new ElapsedEventHandler (OnBackgroundTimeEvent);
	}

	void OnApplicationQuit() 
	{
		EasyTTSUtil.Stop ();
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

		if(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.NoAds == false)
		{
			//RequestInterstitial();
		}
	}
/*
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

	public void HandleOnInterstitialAdClosed(object sender, EventArgs args)
	{
		if(interstitial != null)
		{
			interstitial.Destroy();
		}
	}
*/
	public void OnBackgroundTimeEvent(object source, ElapsedEventArgs e)
	{
	}

	public void OnButtonPressed()
	{
/*
		if(interstitial != null)
		{
			interstitial.Destroy();
		}
*/
		BackgroundTimer.Stop();
	}

    public void OnShareButtonPressed()
    {
		if(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.ProVersion == true)
		{
	        if (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin != "" && UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserPassword != "")
	        {
	            UIManager.GetComponent<UI_Manager>().SwitchStates("LoginAutoState");
	        }
	        else
	        {
	            UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
	        }
		}
		else
		{
			if (PopUpActive == false)
			{
				PopUpOkDialog(("Purchase the Pro Version from the store to Unlock this feature.\nUse Restore Purchases in the store if you already purchased the Pro version."), this.gameObject.GetComponent<UI_Home>(), "ProVersionNotPurchased");
			}
			Debug.Log("Please purchase Pro version to unlock this feature");
		}
    }

	public void OnStartWorkoutButtonPressed()
	{
		System.DateTime CalendarDayToday = new System.DateTime();
		CalendarDayToday = System.DateTime.Now;
		UICalendar.GetComponent<UI_Calendar> ().SelectedDay = CalendarDayToday;
		string DayWorkoutStatus = GetDayData(CalendarDayToday);

		switch(DayWorkoutStatus)
		{
		case "NoWorkout":
			UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
			break;
		case "Workout":
			string WorkoutName = GetFirstWorkoutNameForDay(CalendarDayToday);
			int WorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().FindWorkoutByName(WorkoutName);
			UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = WorkoutIndex;
			UIManager.GetComponent<UI_Manager>().SwitchStates("WorkoutState");
			break;
		case "WorkoutSomeCompleted":
			string WorkoutNameSome = GetFirstWorkoutNameForDay(CalendarDayToday);
			int WorkoutIndexSome = UserBlobManager.GetComponent<UserBlobManager>().FindWorkoutByName(WorkoutNameSome);
			UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex = WorkoutIndexSome;
			UIManager.GetComponent<UI_Manager>().SwitchStates("WorkoutState");
			break;
		case "WorkoutCompleted":
			UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
			break;
		default:
			break;
		}
	}

	public string GetDayData(System.DateTime myDate)
	{
		string CurrentWorkoutStatus = "NoWorkout";
		for(int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++ )
		{
			if((myDate.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
			   (myDate.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month ) &&
			   (myDate.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
			{
				CurrentWorkoutStatus = "Workout";
				int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length;
				int NumCompletedWorkouts = 0;
				for(int WorkoutIndex = 0; WorkoutIndex < NumWorkouts; WorkoutIndex++)
				{
					if(UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutCompleted == true)
					{
						NumCompletedWorkouts++;
					}
				}
				if(NumCompletedWorkouts > 0 && NumCompletedWorkouts < NumWorkouts)
				{
					CurrentWorkoutStatus = "WorkoutSomeCompleted";
				}
				if(NumWorkouts == NumCompletedWorkouts )
				{
					CurrentWorkoutStatus = "WorkoutCompleted";
				}
			}
		}
		return CurrentWorkoutStatus;
	}

	public string GetFirstWorkoutNameForDay(System.DateTime myDate)
	{
		string WorkoutName = "";
		for(int index = 0; index < UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day.Length; index++ )
		{
			if((myDate.Year == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Year) &&
			   (myDate.Month == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Month ) &&
			   (myDate.Day == UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].Day.Day))
			{
				WorkoutName = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[0].WorkoutName;
				int NumWorkouts = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray.Length;
				for(int WorkoutIndex = NumWorkouts - 1; WorkoutIndex >= 0; WorkoutIndex--)
				{
					if(UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutCompleted == false)
					{
						WorkoutName = UserBlobManager.GetComponent<UserBlobManager>().UserDayData.Day[index].DayWorkoutArray[WorkoutIndex].WorkoutName;
					}
				}
			}
		}
		return WorkoutName;
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
		case "ProVersionNotPurchased":
			if (DialogState == "ok")
			{
				Debug.Log("Pro Version Not Purchased");
			}
			break;
			
		}
		PopUpOkDialogState = "";
		PopUpActive = false;
	}
}
