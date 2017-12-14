using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ExerciseData  {
	
	public string Name = "New Exercise";
	public string Description = "Description";
	public string Type = "General";
	public string BodyPart = "Body";
	public int Weight = 0;
	public int Reps = 0;
	public int Time = 10;
	public int RestTime = 0;
	public string Side = "None";
	public bool CountDownAtStart = true;
	public int NumAnimationFrames = -1;

//	public System.DateTime WorkDayStartTime = new System.DateTime();
	public ExerciseData DeepCopy( ExerciseData data)
	{
		ExerciseData newData = new ExerciseData ();
		newData.Name = data.Name;
		newData.Description = data.Description;
		newData.Type = data.Type;
		newData.BodyPart = data.BodyPart;
		newData.Weight = data.Weight;
		newData.Reps = data.Reps;
		newData.Time = data.Time;
		newData.RestTime = data.RestTime;
		newData.Side = data.Side;
		newData.CountDownAtStart = data.CountDownAtStart;
		newData.NumAnimationFrames = data.NumAnimationFrames;
		return newData;
	}
}
