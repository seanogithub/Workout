using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DownloadTrainingData {

    public string Name = "Download Training";
    public string Description = "Description";
    public string Type = "General";
    public int NumberOfDays = 0;
    public string DateCreated = "";
    public bool Featured = false;
    public string FileName = "";

    public DownloadTrainingData DeepCopy(DownloadTrainingData data)
    {
        DownloadTrainingData newData = new DownloadTrainingData();
        newData.Name = data.Name;
        newData.Description = data.Description;
        newData.Type = data.Type;
        newData.NumberOfDays = data.NumberOfDays;
        newData.DateCreated = data.DateCreated;
        newData.Featured = data.Featured;
        newData.FileName = data.FileName;

        return newData;
    }
}
