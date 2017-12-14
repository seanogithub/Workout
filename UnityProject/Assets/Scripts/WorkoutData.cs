using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WorkoutData  {
	
	public string Name = "New Workout";
	public string Description = "Description";
    public string Type;
	public SaveExerciseData ExerciseArray = new SaveExerciseData ();

	public WorkoutData DeepCopy( WorkoutData data)
	{
		WorkoutData newData = new WorkoutData ();
		newData.Name = data.Name;
		newData.Description = data.Description;
        newData.Type = data.Type;
        newData.ExerciseArray = data.ExerciseArray;
		return newData;
	}

}
