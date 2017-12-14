using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveData  {
	
//	public UserData UserAccountData = new UserData();
//	public AppData UserAppData = new AppData();
	public List<WorkoutData> UserWorkoutData = new List<WorkoutData>(); 
	public List<ExerciseData> UserExerciseData = new List<ExerciseData>();
	
	public SaveData()
	{
//		UserAccountData = new UserData();
//		UserAppData = new AppData();
		UserWorkoutData = new List<WorkoutData>(); 
		UserExerciseData = new List<ExerciseData>();
	}
	
}
