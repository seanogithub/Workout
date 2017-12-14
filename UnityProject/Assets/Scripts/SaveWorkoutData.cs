using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveWorkoutData  {
	
//	public List<WorkoutData> UserWorkoutData = new List<WorkoutData>(); 
	public WorkoutData[] Workout = new WorkoutData[0];

	public SaveWorkoutData()
	{
//		UserWorkoutData = new List<WorkoutData>(); 
		Workout = new WorkoutData[0];
	}	

	public void Add (WorkoutData newItem)
	{
		WorkoutData[] tempArray = new WorkoutData[Workout.Length+1];
		if (Workout.Length > 0)
		{
			for(int i = 0; i < Workout.Length; i++)
			{
				tempArray[i] = Workout[i];
			}
			tempArray[tempArray.Length-1] = newItem;
			Workout = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			Workout = tempArray;
		}
	}
	
	public void RemoveAt (int Index)
	{
		if(Workout.Length > 0)
		{
			WorkoutData[] tempArray = new WorkoutData[Workout.Length-1];
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = Workout[i];
			}
			for(int i = Index + 1; i < Workout.Length; i++)
			{
				tempArray[i-1] = Workout[i];
			}
			Workout = tempArray;
		}
	}
	
	public void Clear ()
	{
		Workout = new WorkoutData[0];
	}
}