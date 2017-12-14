using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveTrainingData {
	
//	public List<TrainingData> UserTrainingData = new List<TrainingData>(); 
	public TrainingData[] Training = new TrainingData[0];

	public SaveTrainingData()
	{
//		UserTrainingData = new List<TrainingData>(); 
		Training = new TrainingData[0];
	}	

	public void Add (TrainingData newItem)
	{
		TrainingData[] tempArray = new TrainingData[Training.Length+1];
		if (Training.Length > 0)
		{
			for(int i = 0; i < Training.Length; i++)
			{
				tempArray[i] = Training[i];
			}
			tempArray[tempArray.Length-1] = newItem;
			Training = tempArray;
		}
		else
		{
			tempArray[0] = newItem;
			Training = tempArray;
		}
	}
	
	
	public void RemoveAt (int Index)
	{
		if(Training.Length > 0)
		{
			TrainingData[] tempArray = new TrainingData[Training.Length-1];
			for(int i = 0; i < Index; i++)
			{
				tempArray[i] = Training[i];
			}
			for(int i = Index + 1; i < Training.Length; i++)
			{
				tempArray[i-1] = Training[i];
			}
			Training = tempArray;
		}
	}
	
	public void Clear ()
	{
		Training = new TrainingData[0];
	}
}
