using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SettingsDataInit  {

	public string InitData = @"
<SaveSettingsData >
	<UserSettingsData>
		<UserLogin></UserLogin>
		<UserPassword></UserPassword>
        <UserEmail></UserEmail>
        <UserFirstName />
        <UserLastName />
        <UserStreetAddress />
        <UserCity />
        <UserState />
        <UserZip />
        <UserGender />
        <RememberLoginPassword>true</RememberLoginPassword>
		<AudioChimeAtEndOfExercise>true</AudioChimeAtEndOfExercise>
		<VoiceSayExerciseName>true</VoiceSayExerciseName>
		<VoiceSayExerciseWeight>true</VoiceSayExerciseWeight>
		<VoiceSayExerciseReps>true</VoiceSayExerciseReps>
		<VoiceSayExerciseTime>true</VoiceSayExerciseTime>
		<VoiceSayRepsCountDown>true</VoiceSayRepsCountDown>
		<VoiceRepsCountDown>false</VoiceRepsCountDown>
		<NoAds>false</NoAds>
		<ProVersion>false</ProVersion>
	</UserSettingsData>
</SaveSettingsData>
";
}
