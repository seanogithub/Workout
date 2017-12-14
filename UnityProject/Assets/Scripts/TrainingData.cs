using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TrainingData {

	public string Name = "New Training Program";
	public string Description = "Description";
    //public List<DayData> DayArray = new List<DayData>();
    public SaveDayData DayArray = new SaveDayData();
    public string Type;

	public TrainingData DeepCopy( TrainingData data)
	{
		TrainingData newData = new TrainingData ();
		newData.Name = data.Name;
		newData.Description = data.Description;
		newData.DayArray = data.DayArray;
		newData.Type = data.Type;
		return newData;
	}
}
