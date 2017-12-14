using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveDownloadExerciseData  {

    public DownloadExerciseData[] DownloadExercise = new DownloadExerciseData[0];

    public SaveDownloadExerciseData()
    {
        //		UserDownloadExerciseData = new List<DownloadExerciseData>(); 
        DownloadExercise = new DownloadExerciseData[0];
    }

    public void Add(DownloadExerciseData newItem)
    {
        DownloadExerciseData[] tempArray = new DownloadExerciseData[DownloadExercise.Length + 1];
        if (DownloadExercise.Length > 0)
        {
            for (int i = 0; i < DownloadExercise.Length; i++)
            {
                tempArray[i] = DownloadExercise[i];
            }
            tempArray[tempArray.Length - 1] = newItem;
            DownloadExercise = tempArray;
        }
        else
        {
            tempArray[0] = newItem;
            DownloadExercise = tempArray;
        }
    }

    public void RemoveAt(int Index)
    {
        if (DownloadExercise.Length > 0)
        {
            DownloadExerciseData[] tempArray = new DownloadExerciseData[DownloadExercise.Length - 1];
            for (int i = 0; i < Index; i++)
            {
                tempArray[i] = DownloadExercise[i];
            }
            for (int i = Index + 1; i < DownloadExercise.Length; i++)
            {
                tempArray[i - 1] = DownloadExercise[i];
            }
            DownloadExercise = tempArray;
        }
    }

    public void Clear()
    {
        DownloadExercise = new DownloadExerciseData[0];
    }
}

