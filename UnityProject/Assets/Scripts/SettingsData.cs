using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SettingsData {

    public string UserLogin = "";
    public string UserPassword = "";
    public string UserEmail = "";
    public string UserFirstName = "";
    public string UserLastName = "";
    public string UserStreetAddress = "";
    public string UserCity = "";
    public string UserState = "";
    public string UserZip = "";
    public string UserGender = "";
    public bool RememberLoginPassword = true;
    public bool AudioChimeAtEndOfExercise = true;
	public bool VoiceSayExerciseName = true;
	public bool VoiceSayExerciseWeight = true;
	public bool VoiceSayExerciseReps = true;
	public bool VoiceSayExerciseTime = true;
	public bool VoiceSayRepsCountDown = true;
	public bool VoiceRepsCountDown = true;
	public bool NoAds = false;
	public bool ProVersion = false;

	public SettingsData DeepCopy( SettingsData data)
	{
		SettingsData newData = new SettingsData ();

        newData.UserLogin = data.UserLogin;
        newData.UserPassword = data.UserPassword;
        newData.UserEmail = data.UserEmail;
        newData.UserFirstName = data.UserFirstName;
        newData.UserLastName = data.UserLastName;
        newData.UserStreetAddress = data.UserStreetAddress;
        newData.UserCity = data.UserCity;
        newData.UserState = data.UserState;
        newData.UserZip = data.UserZip;
        newData.UserGender = data.UserGender;
        newData.RememberLoginPassword = data.RememberLoginPassword;
        newData.AudioChimeAtEndOfExercise = data.AudioChimeAtEndOfExercise;
		newData.VoiceSayExerciseName = data.VoiceSayExerciseName;
		newData.VoiceSayExerciseWeight = data.VoiceSayExerciseWeight;
		newData.VoiceSayExerciseReps = data.VoiceSayExerciseReps;
		newData.VoiceSayExerciseTime = data.VoiceSayExerciseTime;
		newData.VoiceSayRepsCountDown = data.VoiceSayRepsCountDown;
		newData.VoiceRepsCountDown = data.VoiceRepsCountDown;
		newData.NoAds = data.NoAds;
		newData.ProVersion = data.ProVersion;

		return newData;
	}
}
