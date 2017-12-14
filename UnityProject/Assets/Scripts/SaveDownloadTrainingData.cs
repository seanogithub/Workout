using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveDownloadTrainingData  {

    public DownloadTrainingData[] DownloadTraining = new DownloadTrainingData[0];

    public SaveDownloadTrainingData()
    {
        //		UserDownloadTrainingData = new List<DownloadTrainingData>(); 
        DownloadTraining = new DownloadTrainingData[0];
    }

    public void Add(DownloadTrainingData newItem)
    {
        DownloadTrainingData[] tempArray = new DownloadTrainingData[DownloadTraining.Length + 1];
        if (DownloadTraining.Length > 0)
        {
            for (int i = 0; i < DownloadTraining.Length; i++)
            {
                tempArray[i] = DownloadTraining[i];
            }
            tempArray[tempArray.Length - 1] = newItem;
            DownloadTraining = tempArray;
        }
        else
        {
            tempArray[0] = newItem;
            DownloadTraining = tempArray;
        }
    }

    public void RemoveAt(int Index)
    {
        if (DownloadTraining.Length > 0)
        {
            DownloadTrainingData[] tempArray = new DownloadTrainingData[DownloadTraining.Length - 1];
            for (int i = 0; i < Index; i++)
            {
                tempArray[i] = DownloadTraining[i];
            }
            for (int i = Index + 1; i < DownloadTraining.Length; i++)
            {
                tempArray[i - 1] = DownloadTraining[i];
            }
            DownloadTraining = tempArray;
        }
    }

    public void Clear()
    {
        DownloadTraining = new DownloadTrainingData[0];
    }
}

