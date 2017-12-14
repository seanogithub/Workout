using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DownloadWorkoutData {

    public string Name = "Download Workout";
    public string Description = "Description";
    public string Type = "General";
    public string Time = "";
    public string DateCreated = "";
    public bool Featured = false;
    public string FileName = "";

    public DownloadWorkoutData DeepCopy(DownloadWorkoutData data)
    {
        DownloadWorkoutData newData = new DownloadWorkoutData();
        newData.Name = data.Name;
        newData.Description = data.Description;
        newData.Type = data.Type;
        newData.Time = data.Time;
        newData.DateCreated = data.DateCreated;
        newData.Featured = data.Featured;
        newData.FileName = data.FileName;

        return newData;
    }
}
