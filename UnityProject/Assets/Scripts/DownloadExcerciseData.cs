using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DownloadExerciseData {

    public string Name = "Download Exercise";
    public string Description = "Description";
    public string Type = "General";
    public string BodyPart = "Body";
    public string DateCreated = "";
    public bool Featured = false;
    public string FileName = "";

    public DownloadExerciseData DeepCopy(DownloadExerciseData data)
    {
        DownloadExerciseData newData = new DownloadExerciseData();
        newData.Name = data.Name;
        newData.Description = data.Description;
        newData.Type = data.Type;
        newData.BodyPart = data.BodyPart;
        newData.DateCreated = data.DateCreated;
        newData.Featured = data.Featured;
        newData.FileName = data.FileName;

        return newData;
    }
}
