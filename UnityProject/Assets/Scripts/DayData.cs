using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DayData  {
	public System.DateTime Day = System.DateTime.Now;
	public DayWorkoutData[] DayWorkoutArray = new DayWorkoutData[0]; 

	public void Add (DayWorkoutData newItem)
	{
		DayWorkoutData[] tempArray = new DayWorkoutData[DayWorkoutArray.Length+1];
		if (DayWorkoutArray.Length > 0)
		{
			for(int i = 0; i < DayWorkoutArray.Length; i++)
			{
				tempArray[i] = DayWorkoutArray[i];
			}
			tempArray[tempArray.Length-1] = newItem;
			DayWorkoutArray = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			DayWorkoutArray = tempArray;
		}
	}
	
	public void Insert (int Index, DayWorkoutData newItem)
	{
		if (Index > DayWorkoutArray.Length || Index < 0) 
		{
			Index = DayWorkoutArray.Length-1;
		}
		
		DayWorkoutData[] tempArray = new DayWorkoutData[DayWorkoutArray.Length+1];
		if (DayWorkoutArray.Length > 0)
		{
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = DayWorkoutArray[i];
			}
			
			tempArray[Index] = newItem;
			
			for(int i = Index+1; i < DayWorkoutArray.Length+1; i++)
			{
				tempArray[i] = DayWorkoutArray[i-1];
			}
			DayWorkoutArray = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			DayWorkoutArray = tempArray;
		}
	}
	
	public void RemoveAt (int Index)
	{
		if(DayWorkoutArray.Length > 0)
		{
			DayWorkoutData[] tempArray = new DayWorkoutData[DayWorkoutArray.Length-1];
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = DayWorkoutArray[i];
			}
			for(int i = Index + 1; i < DayWorkoutArray.Length; i++)
			{
				tempArray[i-1] = DayWorkoutArray[i];
			}
			DayWorkoutArray = tempArray;
		}
	}
	
	public void Clear ()
	{
		DayWorkoutArray = new DayWorkoutData[0];
	}
}
