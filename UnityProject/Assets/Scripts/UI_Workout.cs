using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.IO;

public class UI_Workout : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
	public GameObject VoiceSpeaker;

	public GameObject WorkoutNameText;
	public GameObject ExerciseNameText;
	public GameObject ExerciseTimeText;
	public GameObject WorkoutTimeText;
	public GameObject WeightText;
	public GameObject RepsText;
	public GameObject ExerciseTimerImage;
	public GameObject WorkoutTimerImage;
	public GameObject MissingAnimationImage;
	public GameObject ExerciseTimerModel;
	public GameObject WorkoutTimerModel;
	public GameObject MaleModel;
    public GameObject ModelRoot;
    public GameObject WorkoutCanvas;

	public Texture AnimationMissingTexture;
	public Texture BlankTexture;
	public bool ShowExerciseAnimation = true;
	private List<Texture> ExerciseAnimationImageList = new List<Texture> ();
	private int ExerciseAnimationIndex = 0;

	public GameObject PlayButtonWorkout;

	public Sprite PlayButtonImage;
	public Sprite PauseButtonImage;
	
	public AudioClip SoundExerciseTimer;
	public bool PlayExercieTimerSound = false;
	public bool PlayCountDownSound = false;
	public bool PlayNextExerciseSound = false;

	public int CurrentWorkoutIndex = 0;
	public int CurrentExerciseIndex = 0;
	public WorkoutData CurrentWorkout = new WorkoutData();

	public Timer CurrentExerciseTimer = new Timer();
	public Timer RepCountTimer = new Timer();
	public Timer ExerciseAnimationTimer = new Timer();

	public int CurrentRepCount = 0;
	public bool PlayRepCountSound = false;
	
	public int CurrentExerciseTime = 0;
	public int CurrentExerciseRestTime = 0;
	public int CurrentWorkoutTime = 0;
	public int CurrentCountDownAtStartTime = 0;
	public int TotalWorkoutTime = 0;

	private bool PauseFlag = false;

	private Sprite[] ExerciseTimerBitmaps;  
	private Sprite[] WorkoutTimerBitmaps; 
	private AnimationClip[] ExerciseAnimations;

	public bool InternetAvailable = false;

    public int WorkoutScore = 0;

    private bool BadWorkoutData = false;

    public string PopUpYesNoDialogState = "";
    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
//		ExerciseTimerBitmaps = Resources.LoadAll<Sprite>("UI/ExerciseTimer");  
//		WorkoutTimerBitmaps = Resources.LoadAll<Sprite>("UI/WorkoutTimer");  

//		ExerciseTimerImage.GetComponent<Image> ().sprite = ExerciseTimerBitmaps [25];
//		WorkoutTimerImage.GetComponent<Image> ().sprite = WorkoutTimerBitmaps [10];

		ExerciseAnimations = Resources.LoadAll<AnimationClip>("UI/ExerciseAnimations"); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Initialize) 
		{
			Init ();
		}

        if (BadWorkoutData == false)
        {
            // update timers
            if (CurrentExerciseTime <= 0)
            {
                if (CurrentExerciseRestTime <= 0)
                {
                    NextExercise();
                }
            }
            if (CurrentWorkoutTime <= 0)
            {
                WorkoutCompleted();
            }

            UpdateUI();

            // play sounds
            if (PlayCountDownSound && (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.VoiceSayExerciseName == true))
            {
                PlayCountDownSound = false;
                VoiceSpeaker.SendMessage("TTSSay", "Ready, Set, Go");
            }

            if (PlayExercieTimerSound && (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.AudioChimeAtEndOfExercise == true))
            {
                PlayExercieTimerSound = false;
                GetComponent<AudioSource>().PlayOneShot(SoundExerciseTimer);
            }

            if (PlayRepCountSound && (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.VoiceSayRepsCountDown == true))
            {
                PlayRepCountSound = false;
                if (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.VoiceRepsCountDown)
                {
                    VoiceSpeaker.SendMessage("TTSSay", CurrentRepCount.ToString());
                }
                else
                {
                    int TempRepCount = CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps - CurrentRepCount;
                    VoiceSpeaker.SendMessage("TTSSay", TempRepCount.ToString());
                }
            }

            if (PlayNextExerciseSound && (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.VoiceSayExerciseName == true))
            {
                PlayNextExerciseSound = false;
                if (CurrentExerciseIndex < CurrentWorkout.ExerciseArray.Exercise.Length)
                {
                    string tempVoiceSay = "Rest for ";
                    tempVoiceSay += GetTimeStringFromSeconds(CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].RestTime);
                    tempVoiceSay += ", the next exercise is ";
                    tempVoiceSay += GetExerciseInfoToString(CurrentExerciseIndex + 1);
                    VoiceSpeaker.SendMessage("TTSSay", tempVoiceSay);
                }
            }

#if UNITY_IOS
    // update touch for rotating the model
    if(Input.touchCount == 1)
    {
        float h = 0f;
        float horozontalSpeed = 0.5f;
        Touch touch = Input.GetTouch(0);
        h = horozontalSpeed * touch.deltaPosition.x;
        ModelRoot.transform.Rotate(0, -h, 0, Space.World);
    }
#endif

            UpdateExerciseAnimation();
        }
	}

	public void Init()
	{
		Initialize = false;
        BadWorkoutData = false;
        WorkoutCanvas.SetActive(true);
        ExerciseTimerModel.SetActive(true);
        WorkoutTimerModel.SetActive(true);
        ModelRoot.SetActive(true);
        WorkoutScore = 0;
        MissingAnimationImage.SetActive(false);
        CurrentExerciseIndex = 0;
		CurrentWorkoutIndex = UserBlobManager.GetComponent<UserBlobManager>().CurrentWorkoutIndex;
        if (CurrentWorkoutIndex < 0) // workout missing
        {
            // clear workout screen
            BadWorkoutData = true;
            WorkoutCanvas.SetActive(false);
            ExerciseTimerModel.SetActive(false);
            WorkoutTimerModel.SetActive(false);
            ModelRoot.SetActive(false);
            print("error missing workout");
            if (PopUpActive == false)
            {
                PopUpOkDialog("Error: Workout is missing", this.gameObject.GetComponent<UI_Workout>(), "MissingWorkout");
            }
        }
        else
        { 
            CurrentWorkout = UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout [CurrentWorkoutIndex];
            WorkoutNameText.GetComponent<Text>().text = CurrentWorkout.Name;

            if (CurrentWorkout.ExerciseArray.Exercise.Length == 0) // exercise missing
            {
                // clear workout screen
                BadWorkoutData = true;
                CurrentExerciseTimer.Stop();
                RepCountTimer.Stop();
                ExerciseAnimationTimer.Stop();
                WorkoutCanvas.SetActive(false);
                ExerciseTimerModel.SetActive(false);
                WorkoutTimerModel.SetActive(false);
                ModelRoot.SetActive(false);
                print("error no exercises in the workout");
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Error: Workout has no exercises", this.gameObject.GetComponent<UI_Workout>(), "MissingExercise");
                }
            }
            else
            {

                string SideString = "";
                if (CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Side != "None")
                {
                    SideString = " " + CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Side;
                }
                ExerciseNameText.GetComponent<Text>().text = CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Name + SideString;
                PauseFlag = true;
                //		PlayButtonText.GetComponent<Text>().text = "Play";
                PlayButtonWorkout.GetComponent<Image>().sprite = PlayButtonImage;

                if (CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].CountDownAtStart)
                {
                    CurrentCountDownAtStartTime = UserBlobManager.GetComponent<UserBlobManager>().CountDownAtStartTimeLength;
                }
                else
                {
                    CurrentCountDownAtStartTime = 0;
                }

                CurrentExerciseTimer = new Timer();
                CurrentExerciseTimer.Interval = 1000;
                CurrentExerciseTimer.Elapsed += new ElapsedEventHandler(OnExerciseTimeEvent);
                CurrentExerciseTime = CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                CurrentExerciseRestTime = CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].RestTime;
                CurrentWorkoutTime = 0;
                for (int i = 0; i < CurrentWorkout.ExerciseArray.Exercise.Length; i++)
                {
                    CurrentWorkoutTime += CurrentWorkout.ExerciseArray.Exercise[i].Time;
                    CurrentWorkoutTime += CurrentWorkout.ExerciseArray.Exercise[i].RestTime;
                    if (CurrentWorkout.ExerciseArray.Exercise[i].CountDownAtStart)
                    {
                        CurrentWorkoutTime += 10;
                    }
                }
                TotalWorkoutTime = CurrentWorkoutTime;

                CurrentRepCount = CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps;
                RepCountTimer = new Timer();
                if (CurrentRepCount > 0)
                {
                    RepCountTimer.Interval = ((float)CurrentExerciseTime / (float)CurrentRepCount * 1000);
                }
                else
                {
                    RepCountTimer.Interval = 1000;
                }
                RepCountTimer.Elapsed += new ElapsedEventHandler(OnRepCountTimeEvent);

                WeightText.GetComponent<Text>().text = CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Weight.ToString();
                RepsText.GetComponent<Text>().text = CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps.ToString();

                GetComponent<AudioSource>().ignoreListenerPause = true;

                ExerciseAnimationTimer = new Timer();
                ExerciseAnimationTimer.Interval = 250;
                ExerciseAnimationTimer.Elapsed += new ElapsedEventHandler(OnExerciseAnimationTimeEvent);
                ExerciseAnimationTimer.Start();
                ExerciseAnimationImageList.Clear();
                StartCoroutine(CheckInternetConnection());
                //UpdateExerciseAnimationBitmaps();
                GetExerciseAnimation();
                PlayButtonPressed();

#if UNITY_IOS
                ModelRoot.transform.rotation = new Quaternion(0, 0, 0, 0);
                ModelRoot.transform.Rotate(0, 0, 0, Space.World);
#endif
            }
        }        
    }

    public void OnExerciseTimeEvent(object source, ElapsedEventArgs e)
	{
		if (CurrentCountDownAtStartTime > 0)
		{
			CurrentCountDownAtStartTime--;
			if(CurrentCountDownAtStartTime == 2)
			{
				PlayCountDownSound = true;
			}
		}
		else
		{
			if (CurrentExerciseTime > 0)
			{
				CurrentExerciseTime--;
				if(CurrentExerciseTime == 3)
				{
					PlayExercieTimerSound = true;
				}
			}
			else
			{
				CurrentExerciseRestTime--;
				if(CurrentExerciseRestTime == CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].RestTime - 1)
				{
					PlayNextExerciseSound = true;
				}
			}
		}
		CurrentWorkoutTime--;
	}

	public void OnRepCountTimeEvent(object source, ElapsedEventArgs e)
	{
		if(CurrentRepCount > 0 && CurrentCountDownAtStartTime == 0)
		{
			CurrentRepCount--;
			if(CurrentRepCount > 0 )
			{
				PlayRepCountSound = true;
			}
		}
	}

	public void OnExerciseAnimationTimeEvent(object source, ElapsedEventArgs e)
	{
		ExerciseAnimationIndex++;
	}

	public void UpdateUI()
	{
		string SideString = "";
		if(CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Side != "None")
		{
			SideString = " " + CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Side;
		}
		if(CurrentCountDownAtStartTime > 0)
		{
            ExerciseNameText.GetComponent<Text>().text = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Name + SideString;
			ExerciseTimeText.GetComponent<Text> ().text = ConvertSecondsToTimeHoursString (CurrentCountDownAtStartTime) ;
		}
		else
		{
            if (CurrentExerciseTime > 0)
			{
				ExerciseNameText.GetComponent<Text>().text = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Name + SideString;
				ExerciseTimeText.GetComponent<Text> ().text = ConvertSecondsToTimeHoursString (CurrentExerciseTime) ;
			}
			else
			{
				ExerciseNameText.GetComponent<Text>().text = "Rest";
				ExerciseTimeText.GetComponent<Text> ().text = ConvertSecondsToTimeMinutesString (CurrentExerciseRestTime) ;
			}
		}

		WorkoutTimeText.GetComponent<Text> ().text = ConvertSecondsToTimeHoursString(CurrentWorkoutTime);
		WeightText.GetComponent<Text>().text = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight.ToString();
		RepsText.GetComponent<Text>().text = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps.ToString();

		float WorkoutTimePercent = 100 - (float)(((float)CurrentWorkoutTime / (float)TotalWorkoutTime) * 100);
//		int WorkoutTimePercent = 100 - (int)(((float)CurrentWorkoutTime / (float)TotalWorkoutTime) * 100);
//		WorkoutTimerImage.GetComponent<Image> ().sprite = WorkoutTimerBitmaps [WorkoutTimePercent]; 

		float ExerciseTimePercent = 100 - (float)(((float)CurrentExerciseTime / (float)CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Time) * 100);
//		int ExerciseTimePercent = 100 - (int)(((float)CurrentExerciseTime / (float)CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Time) * 100);
//		ExerciseTimerImage.GetComponent<Image> ().sprite = ExerciseTimerBitmaps [ExerciseTimePercent]; 

		Animation ExerciseTimerAnimation = ExerciseTimerModel.GetComponent<Animation> ();
		ExerciseTimerAnimation ["CountDown"].time = (float)ExerciseTimePercent/25;

		Animation WorkoutTimerAnimation = WorkoutTimerModel.GetComponent<Animation> ();
		WorkoutTimerAnimation ["WorkoutCountDown"].time = (float)WorkoutTimePercent/25;

		UpdateExerciseAnimation ();

	}

	public void UpdateExerciseAnimation()
	{
        MaleModel.GetComponent<Animation>().Play();
        if (PauseFlag == true)
        {
            MaleModel.GetComponent<Animation>().Stop();
        }
        if (CurrentCountDownAtStartTime > 0)
        {
            MaleModel.GetComponent<Animation>().Rewind();
        }
	}

    public AnimationClip GetClipByName(string clipName)
    {
        for(int i = 0; i < ExerciseAnimations.Length; i++)
        {
            if (ExerciseAnimations[i].name == clipName)
            {
                return ExerciseAnimations[i];
            }
        }
        return ExerciseAnimations[0];
    }

	public void GetExerciseAnimation()
	{
		if(ShowExerciseAnimation == true)
		{
			MaleModel.SetActive(true);

			// try to load the animation from resources
			AnimationClip ResourcesMotion = LoadExerciseAnimationsFromResources();
			if(ResourcesMotion != null)
			{
                MissingAnimationImage.SetActive(false);
                MaleModel.GetComponent<Animation>().AddClip(ResourcesMotion, ResourcesMotion.name);
				MaleModel.GetComponent<Animation>().clip = ResourcesMotion;
                if(CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps > 0)
                {
                    float AnimationSpeed = (float)MaleModel.GetComponent<Animation>().clip.length / ((float) CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time / (float) CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps);
                    Animation anim = MaleModel.GetComponent<Animation>();
                    foreach (AnimationState state in anim)
                    {
                        state.speed = AnimationSpeed;
                    }
                }
				MaleModel.GetComponent<Animation>().Play();
                MaleModel.SetActive(true);
            }
			else
			{
                MaleModel.SetActive(false);
                MissingAnimationImage.SetActive(true);
                AnimationClip restAnimation = GetClipByName("Rest_Time");
                MaleModel.GetComponent<Animation>().AddClip(restAnimation, restAnimation.name);
				MaleModel.GetComponent<Animation>().clip = restAnimation;
				MaleModel.GetComponent<Animation>().Play();
			}

		}
	}
    
	private AnimationClip LoadExerciseAnimationsFromResources()
	{
		// try to load animation from resources
		string ResourcesAnimationFileName = "UI/ExerciseAnimations/";
		ResourcesAnimationFileName += CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Name.ToCharArray(0,1)[0].ToString().ToUpper() + "/";
		ResourcesAnimationFileName += CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Name;
		ResourcesAnimationFileName = ResourcesAnimationFileName.Replace (" ", "_");
		AnimationClip ResoucesAnimation = Resources.Load<AnimationClip>(ResourcesAnimationFileName); 
		//return null;
		return ResoucesAnimation;
	}
    
	IEnumerator CheckInternetConnection()
	{
		const float timeout = 10f;
		float startTime = Time.timeSinceLevelLoad;
		var ping = new Ping("8.8.8.8");
		
		while (true)
		{
			if (ping.isDone)
			{
				InternetAvailable = true;
				yield break;
			}
			if (Time.timeSinceLevelLoad - startTime > timeout)
			{
				InternetAvailable = false;
				yield break;
			}
			yield return new WaitForEndOfFrame();
		}
	}
	

	public void NextExercise()
	{
        UpdateWorkoutScore();

        CurrentExerciseIndex++;
		if (CurrentExerciseIndex >= CurrentWorkout.ExerciseArray.Exercise.Length) 
		{
			CurrentExerciseIndex = CurrentWorkout.ExerciseArray.Exercise.Length - 1;
			WorkoutCompleted();
		}
		else
		{
			// update timer
			if(CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].CountDownAtStart)
			{
				CurrentCountDownAtStartTime = UserBlobManager.GetComponent<UserBlobManager> ().CountDownAtStartTimeLength;
			}
			else
			{
				CurrentCountDownAtStartTime = 0;
			}
			CurrentExerciseTime = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Time;
			CurrentExerciseRestTime = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].RestTime;
			CurrentRepCount = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps;
			if (CurrentRepCount > 0)
			{
				RepCountTimer.Interval = ((float)CurrentExerciseTime / (float)CurrentRepCount * 1000);
			}
			else
			{
				RepCountTimer.Interval = 1000;
			}

			UpdateUI();

			string tempVoiceSay = GetExerciseInfoToString(CurrentExerciseIndex);
			if(CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].CountDownAtStart == true)
			{
				tempVoiceSay = "Get ready for " + tempVoiceSay;
			}
			if (UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName == true)
			{
				VoiceSpeaker.SendMessage("TTSSay", tempVoiceSay);
			}

            GetExerciseAnimation();
		}
	}

    public void UpdateWorkoutScore()
    {
        float ExerciseCompletedPercent = ((float)CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time - (float)CurrentExerciseTime) / (float) CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
        //float ExerciseCompletedPercent = 1;
        float ExerciseScore = 0f;
        switch(CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Type)
        {
            case "General":
                ExerciseScore += 1f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Warm-Up":
                ExerciseScore += 0.5f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Stretch":
                ExerciseScore += 0.25f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Weights":
                ExerciseScore += 1f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Weight * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Reps;
                break;
            case "Cardio-Light":
                ExerciseScore += 4f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Cardio-Moderate":
                ExerciseScore += 8f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Cardio-Intense":
                ExerciseScore += 12f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Yoga":
                ExerciseScore += 2f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Body Weight":
                ExerciseScore += 12f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Cross-Fit":
                ExerciseScore += 12f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            case "Fighting":
                ExerciseScore += 8f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
            default:
                ExerciseScore += 1f * ExerciseCompletedPercent * CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].Time;
                break;
        }
        WorkoutScore += (int)ExerciseScore;
    }

	public void WorkoutCompleted ()
	{
        CurrentExerciseTimer.Stop();
		RepCountTimer.Stop ();
		ExerciseAnimationTimer.Stop ();

#if UNITY_IOS
		Screen.sleepTimeout = SleepTimeout.SystemSetting;
#endif

		VoiceSpeaker.SendMessage("TTSSay", ("Congradulations" + CurrentWorkout.Name + " Workout Completed"));
		UIManager.GetComponent<UI_Manager>().SwitchStates("WorkoutCompletedState");
	}

	public void ShowExerciseAnimationButtonPressed()
	{
		ShowExerciseAnimation = !ShowExerciseAnimation;
		//UpdateExerciseAnimationBitmaps ();
		GetExerciseAnimation ();
	}

	public void PlayButtonPressed()
	{
		if (PauseFlag) 
		{ 
			PauseFlag = false;
//			PlayButtonText.GetComponent<Text>().text = "Pause";
			PlayButtonWorkout.GetComponent<Image> ().sprite = PauseButtonImage;
			CurrentExerciseTimer.Start();
			RepCountTimer.Start();
			MaleModel.GetComponent<Animation>().Play();// = true;

#if UNITY_IOS
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif


			UpdateUI ();

			string tempVoiceSay = GetExerciseInfoToString(CurrentExerciseIndex);
			if(CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].CountDownAtStart == true)
			{
				tempVoiceSay = "Get ready for " + tempVoiceSay;
			}
			if (UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName == true)
			{
				VoiceSpeaker.SendMessage("TTSSay", tempVoiceSay);
			}
		}
		else 
		{
			PauseFlag = true;
//			PlayButtonText.GetComponent<Text>().text = "Play";
			PlayButtonWorkout.GetComponent<Image> ().sprite = PlayButtonImage;
			CurrentExerciseTimer.Stop();
			RepCountTimer.Stop ();
			MaleModel.GetComponent<Animation>().Stop(); // = false;

#if UNITY_IOS
			Screen.sleepTimeout = SleepTimeout.SystemSetting;
#endif

			UpdateUI();
		}
	}

	public void StopButtonPressed()
	{
		CurrentExerciseTimer.Stop();
		RepCountTimer.Stop ();
		ExerciseAnimationTimer.Stop ();

#if UNITY_IOS
		Screen.sleepTimeout = SleepTimeout.SystemSetting;
#endif

		UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
	}

	public void SkipForwardButtonPressed()
	{
        UpdateWorkoutScore();
        CurrentExerciseIndex++;
		if (CurrentExerciseIndex >= CurrentWorkout.ExerciseArray.Exercise.Length) 
		{
			CurrentExerciseIndex = CurrentWorkout.ExerciseArray.Exercise.Length - 1;
			WorkoutCompleted();
		}
		else
		{
			// update timer
			if(CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].CountDownAtStart)
			{
				CurrentCountDownAtStartTime = UserBlobManager.GetComponent<UserBlobManager> ().CountDownAtStartTimeLength;
			}
			else
			{
				CurrentCountDownAtStartTime = 0;
			}
			CurrentWorkoutTime = 0;
			for(int i = CurrentExerciseIndex; i < CurrentWorkout.ExerciseArray.Exercise.Length; i ++)
			{
				CurrentWorkoutTime += CurrentWorkout.ExerciseArray.Exercise [i].Time;
				CurrentWorkoutTime += CurrentWorkout.ExerciseArray.Exercise [i].RestTime;
				if(CurrentWorkout.ExerciseArray.Exercise [i].CountDownAtStart)
				{
					CurrentWorkoutTime += 10;
				}
			}

			CurrentExerciseTime = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Time;
			CurrentExerciseRestTime = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].RestTime;
			CurrentRepCount = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps;
			if (CurrentRepCount > 0)
			{
				RepCountTimer.Interval = ((float)CurrentExerciseTime / (float)CurrentRepCount * 1000);
			}
			else
			{
				RepCountTimer.Interval = 1000;
			}

			UpdateUI();

			string tempVoiceSay = GetExerciseInfoToString(CurrentExerciseIndex);
			if(CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].CountDownAtStart == true)
			{
				tempVoiceSay = "Get ready for " + tempVoiceSay;
			}
			if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName == true)
			{
				VoiceSpeaker.SendMessage("TTSSay", tempVoiceSay);
			}

			//UpdateExerciseAnimationBitmaps();
			GetExerciseAnimation();
		}
	}

	public void SkipBackwardButtonPressed()
	{
		CurrentExerciseIndex--;
		if (CurrentExerciseIndex < 0) 
		{
			CurrentExerciseIndex = 0;
		}
		CurrentWorkoutTime = 0;
		for(int i = CurrentExerciseIndex; i < CurrentWorkout.ExerciseArray.Exercise.Length; i ++)
		{
			CurrentWorkoutTime += CurrentWorkout.ExerciseArray.Exercise [i].Time;
			CurrentWorkoutTime += CurrentWorkout.ExerciseArray.Exercise [i].RestTime;
			if(CurrentWorkout.ExerciseArray.Exercise [i].CountDownAtStart)
			{
				CurrentWorkoutTime += 5;
			}
		}

		// update timers
		if(CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].CountDownAtStart)
		{
			CurrentCountDownAtStartTime = UserBlobManager.GetComponent<UserBlobManager> ().CountDownAtStartTimeLength;
		}
		else
		{
			CurrentCountDownAtStartTime = 0;
		}
		CurrentExerciseTime = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Time;
		CurrentExerciseRestTime = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].RestTime;
		CurrentRepCount = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps;
		if (CurrentRepCount > 0)
		{
			RepCountTimer.Interval = ((float)CurrentExerciseTime / (float)CurrentRepCount * 1000);
		}
		else
		{
			RepCountTimer.Interval = 1000;
		}
		UpdateUI ();

		string tempVoiceSay = GetExerciseInfoToString(CurrentExerciseIndex);
		if(CurrentWorkout.ExerciseArray.Exercise[CurrentExerciseIndex].CountDownAtStart == true)
		{
			tempVoiceSay = "Get ready for " + tempVoiceSay;
		}
		if (UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName == true)
		{
			VoiceSpeaker.SendMessage("TTSSay", tempVoiceSay);
		}

		//UpdateExerciseAnimationBitmaps ();
		GetExerciseAnimation ();
	}

	public void AddWeightButtonPressed()
	{
		CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight++;
		if (CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight > 999)
		{
			CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight = 999;
		}
		UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].ExerciseArray.Exercise [CurrentExerciseIndex].Weight = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight;
		UserBlobManager.GetComponent<UserBlobManager> ().SaveWorkout ();
	}

	public void SubWeightButtonPressed()
	{
		CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight--;
		if (CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight < 0)
		{
			CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight = 0;
		}
		UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].ExerciseArray.Exercise [CurrentExerciseIndex].Weight = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Weight;
		UserBlobManager.GetComponent<UserBlobManager> ().SaveWorkout ();
	}

	public void AddRepsButtonPressed()
	{
		CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps++;
		if (CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps > 99)
		{
			CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps = 99;
		}
		UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].ExerciseArray.Exercise [CurrentExerciseIndex].Reps = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps;
		UserBlobManager.GetComponent<UserBlobManager> ().SaveWorkout ();
	}
	
	public void SubRepsButtonPressed()
	{
		CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps--;
		if (CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps < 0)
		{
			CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps = 0;
		}
		UserBlobManager.GetComponent<UserBlobManager> ().UserWorkoutData.Workout[CurrentWorkoutIndex].ExerciseArray.Exercise [CurrentExerciseIndex].Reps = CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Reps;
		UserBlobManager.GetComponent<UserBlobManager> ().SaveWorkout ();
	}

	public string GetExerciseInfoToString (int myExerciseIndex)
	{
		string ExerciseInfo = "";
		string CurrentExerciseNameString = "";
		string CurrentWeightString = "";
		string CurrentRepCountString = "";
		string CurrentTimeString = "";

		// say name
		string SideString = "";
		if(CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Side != "None")
		{
			SideString = " " + CurrentWorkout.ExerciseArray.Exercise [CurrentExerciseIndex].Side + " Side";
		}
		CurrentExerciseNameString = CurrentWorkout.ExerciseArray.Exercise [myExerciseIndex].Name + SideString;

		// say weight
		CurrentWeightString = CurrentWorkout.ExerciseArray.Exercise [myExerciseIndex].Weight.ToString()+ " Pounds";
		if (CurrentWorkout.ExerciseArray.Exercise [myExerciseIndex].Weight <= 0){CurrentWeightString = "";}

		// say time
		CurrentRepCountString = CurrentWorkout.ExerciseArray.Exercise [myExerciseIndex].Reps.ToString () + " Times";
		if (CurrentWorkout.ExerciseArray.Exercise [myExerciseIndex].Reps <= 0){CurrentRepCountString = "";}

		if ( CurrentWeightString == "" && CurrentRepCountString == "")
		{
			CurrentTimeString = ", for " + GetTimeStringFromSeconds(CurrentWorkout.ExerciseArray.Exercise [myExerciseIndex].Time);
		}

		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseName == true)
		{
			ExerciseInfo += CurrentExerciseNameString + ", ";
		}
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseWeight == true)
		{
			ExerciseInfo += CurrentWeightString + " ";
		}
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseReps == true)
		{
			ExerciseInfo += CurrentRepCountString + " ";
		}
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserSettingsData.VoiceSayExerciseTime == true)
		{
			ExerciseInfo += CurrentTimeString + " ";
		}

		return ExerciseInfo;
	}

	public string GetTimeStringFromSeconds (int mySeconds)
	{
		string MinuteString = "";
		string SecondsString = ((int)(mySeconds % 60)).ToString();

		if(mySeconds >= 60)
		{
			MinuteString += ((int)(mySeconds / 60)).ToString();
			if (mySeconds >=120)
			{
				MinuteString += " Minutes";
			}
			else
			{
				MinuteString += " Minute";
			}
			if(SecondsString != "" && SecondsString != "0")
			{
				MinuteString += " and, ";
			}
		}

		if(SecondsString != "" && SecondsString != "0")
		{
			SecondsString += " Seconds";
		}
		if(SecondsString == "0")
		{
			SecondsString = "";
		}
		return (MinuteString + SecondsString);
	}

	public string ConvertSecondsToTimeMinutesString(int mySeconds)
	{
		string SecondsString = ((int)(mySeconds % 60)).ToString();
		if (SecondsString.Length < 2) {SecondsString = "0" + SecondsString;}
		string MinuteString = ((int)(mySeconds / 60)).ToString();
		if (MinuteString.Length < 2) {MinuteString = "0" + MinuteString;}
		string TimeString = MinuteString + ":" + SecondsString;
		return TimeString;
	}

	public string ConvertSecondsToTimeHoursString(int mySeconds)
	{
		string SecondsString = ((int)(mySeconds % 60)).ToString();
		if (SecondsString.Length < 2) {SecondsString = "0" + SecondsString;}
		string MinuteString = ((int)(mySeconds / 60)).ToString();
		if (MinuteString.Length < 2) {MinuteString = "0" + MinuteString;}
		string HourString = ((int)(mySeconds / 3600)).ToString();
//		if (HourString < 10) {HourString = "0" + MinuteString;}
		string TimeString = HourString + ":" + MinuteString + ":" + SecondsString;
		return TimeString;
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
            case "MissingWorkout":
                if (DialogState == "ok")
                {
                    UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
                }
                break;
            case "MissingExercise":
                if (DialogState == "ok")
                {
                    UIManager.GetComponent<UI_Manager>().SwitchStates("CreateWorkoutState");
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }

}
