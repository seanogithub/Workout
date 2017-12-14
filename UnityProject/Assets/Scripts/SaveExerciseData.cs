using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveExerciseData  {
	
//	public List<ExerciseData> UserExerciseData = new List<ExerciseData>();
	public ExerciseData[] Exercise = new ExerciseData[0];
	
	public SaveExerciseData()
	{
//		UserExerciseData = new List<ExerciseData>();
		Exercise = new ExerciseData[0];
	}

	public void Add (ExerciseData newItem)
	{
		ExerciseData[] tempArray = new ExerciseData[Exercise.Length+1];
		if (Exercise.Length > 0)
		{
			for(int i = 0; i < Exercise.Length; i++)
			{
				tempArray[i] = Exercise[i];
			}
			tempArray[tempArray.Length-1] = newItem;
			Exercise = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			Exercise = tempArray;
		}
	}

	public void Insert (int Index, ExerciseData newItem)
	{
		if (Index > Exercise.Length || Index < 0) 
		{
			Index = Exercise.Length-1;
		}

		ExerciseData[] tempArray = new ExerciseData[Exercise.Length+1];
		if (Exercise.Length > 0)
		{
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = Exercise[i];
			}

			tempArray[Index] = newItem;

			for(int i = Index+1; i < Exercise.Length+1; i++)
			{
				tempArray[i] = Exercise[i-1];
			}
			Exercise = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			Exercise = tempArray;
		}
	}

	public void RemoveAt (int Index)
	{
		if(Exercise.Length > 0)
		{
			ExerciseData[] tempArray = new ExerciseData[Exercise.Length-1];
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = Exercise[i];
			}
			for(int i = Index + 1; i < Exercise.Length; i++)
			{
				tempArray[i-1] = Exercise[i];
			}
			Exercise = tempArray;
		}
	}

	public void Clear ()
	{
		Exercise = new ExerciseData[0];
	}
}