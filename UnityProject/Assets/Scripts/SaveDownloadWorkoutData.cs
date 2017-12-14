using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveDownloadWorkoutData  {

    public DownloadWorkoutData[] DownloadWorkout = new DownloadWorkoutData[0];

    public SaveDownloadWorkoutData()
    {
        //		UserDownloadWorkoutData = new List<DownloadWorkoutData>(); 
        DownloadWorkout = new DownloadWorkoutData[0];
    }

    public void Add(DownloadWorkoutData newItem)
    {
        DownloadWorkoutData[] tempArray = new DownloadWorkoutData[DownloadWorkout.Length + 1];
        if (DownloadWorkout.Length > 0)
        {
            for (int i = 0; i < DownloadWorkout.Length; i++)
            {
                tempArray[i] = DownloadWorkout[i];
            }
            tempArray[tempArray.Length - 1] = newItem;
            DownloadWorkout = tempArray;
        }
        else
        {
            tempArray[0] = newItem;
            DownloadWorkout = tempArray;
        }
    }

    public void RemoveAt(int Index)
    {
        if (DownloadWorkout.Length > 0)
        {
            DownloadWorkoutData[] tempArray = new DownloadWorkoutData[DownloadWorkout.Length - 1];
            for (int i = 0; i < Index; i++)
            {
                tempArray[i] = DownloadWorkout[i];
            }
            for (int i = Index + 1; i < DownloadWorkout.Length; i++)
            {
                tempArray[i - 1] = DownloadWorkout[i];
            }
            DownloadWorkout = tempArray;
        }
    }

    public void Clear()
    {
        DownloadWorkout = new DownloadWorkoutData[0];
    }
}

