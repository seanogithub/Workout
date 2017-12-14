using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DayWorkoutData  {

	public string WorkoutName = "Workout Name";
	public bool WorkoutCompleted = false;
	public System.DateTime CompletedDateTime = System.DateTime.Now;
	public int TotalWorkoutTime = 0;
	public int TotalWorkoutWeight = 0;
    public int WorkoutScore = 0;

	public DayWorkoutData DeepCopy( DayWorkoutData data)
	{
		DayWorkoutData newData = new DayWorkoutData ();
		newData.WorkoutName = data.WorkoutName;
		newData.WorkoutCompleted = data.WorkoutCompleted;
		newData.CompletedDateTime = data.CompletedDateTime;
		newData.TotalWorkoutTime = data.TotalWorkoutTime;
		newData.TotalWorkoutWeight = data.TotalWorkoutWeight;
        newData.WorkoutScore = data.WorkoutScore;
        return newData;
	}
}
