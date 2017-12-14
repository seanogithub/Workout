using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;

public class UI_ShareExercise : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIUploading;
    public GameObject exerciseButton;
	
//	public List<ExerciseData> UserExerciseData = new List<ExerciseData>();	
	public SaveExerciseData UserExerciseData;
//	public List<WorkoutData> UserWorkoutData = new List<WorkoutData>();
	public SaveWorkoutData UserWorkoutData;

	public ExerciseData item = new ExerciseData();
	
	public List<GameObject> ExerciseButtonArray = new List<GameObject>();
	
	public Transform ExerciseContentPanel;
	public GameObject ExerciseContentPanelScrollBar;
	public bool ScrollBarMove = false;
	
	public int SelectedExercise = -1;
	public List<string> ShareExerciseList = new List<string> ();
	public List<ExerciseData> ShareExerciseData = new List<ExerciseData>();	

	public Color SelectedColor = Color.red;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
//		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserExerciseData = new SaveExerciseData();
		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Initialize) 
		{
			Init ();
		}
	}
	
	public void Init()
	{
		Initialize = false;
		ShareExerciseList = new List<string> ();
		ShareExerciseData = new List<ExerciseData>();	
		UserExerciseData = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData;
		UserWorkoutData = UserBlobManager.GetComponent<UserBlobManager>().UserWorkoutData;
		SelectedExercise = -1;
//		UserBlobManager.GetComponent<UserBlobManager> ().CurrentExersiceIndex = SelectedExercise;
		ClearScrollList ();
		PopulateScrollList ();
		
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length, ExerciseContentPanel);
		}
		else
		{
			ExerciseContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}
	
	public void ClearScrollList()
	{
		for (int i = ExerciseContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(ExerciseContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateScrollList () 
	{
		ExerciseButtonArray.Clear ();
		foreach (var item in UserExerciseData.Exercise)
		{
			GameObject newButton = Instantiate (exerciseButton) as GameObject;
			ExerciseButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			//			string tempText = item.Name;
			//			if(item.Weight > 0) {tempText += ("-" + item.Weight + "lbs");}
			//			if(item.Reps > 0) {tempText += ("-" + item.Reps + "reps");}
			//			newButton.GetComponentInChildren<Text>().text = tempText;
			//			newButton.GetComponentInChildren<Text>().fontSize = 50;
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
			string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => ExerciseButtonClicked(selectedButton));
			newButton.transform.SetParent (ExerciseContentPanel);
		}
//		ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void ExerciseButtonClicked(string myText)
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindExerciseByName (myText);
		SelectedExercise = myIndex;

		bool sel = false;
		foreach (var item in ShareExerciseList) 
		{
			if (item == myText)
			{
				sel = true;
			}
		}
		if (sel) 
		{
			// remove from list
			ShareExerciseList.Remove(myText);
			ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = Color.white;
		}
		else
		{
			ShareExerciseList.Add(myText);
			ExerciseButtonArray[SelectedExercise].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length;
			float ScrollPercentage =  ExerciseContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			ExerciseContentPanel.localPosition = tempPos;
		}
		ScrollBarMove = true;
	}
	
	public void OnPanelValueChanged()
	{		
		ScrollBarMove = false;
		int ButtonHeight = 200;
		//		double ButtonOffset = 2.8;
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise.Length;
		float ScrollValue =  ((ExerciseContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		ExerciseContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		myScrollPanel.localPosition = tempPos;
	}

	public void OnShareButtonPressed ()
	{
		if(ShareExerciseList.Count > 0)
		{
			//build shared exercise data
			for(int i = 0; i < ShareExerciseList.Count; i++)
			{
				ExerciseData tempExercise = new ExerciseData();
				int ExerciseIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindExerciseByName(ShareExerciseList[i]);
				tempExercise = UserBlobManager.GetComponent<UserBlobManager> ().UserExerciseData.Exercise[ExerciseIndex];
				ShareExerciseData.Add(tempExercise);
			}
            UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData = new List<TrainingData>();
            UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData = new List<WorkoutData>();
            UserBlobManager.GetComponent<UserBlobManager> ().ShareExerciseData = ShareExerciseData;
			UIManager.GetComponent<UI_Manager>().SwitchStates("ShareFriendListState");
		}
		else 
		{
		}
	}

    public void OnShareEveryoneButtonPressed()
    {
        if (ShareExerciseList.Count > 0)
        {
            //build shared exercise data
            for (int i = 0; i < ShareExerciseList.Count; i++)
            {
                ExerciseData tempExercise = new ExerciseData();
                int ExerciseIndex = UserBlobManager.GetComponent<UserBlobManager>().FindExerciseByName(ShareExerciseList[i]);
                tempExercise = UserBlobManager.GetComponent<UserBlobManager>().UserExerciseData.Exercise[ExerciseIndex];
                ShareExerciseData.Add(tempExercise);
            }
            UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData = new List<TrainingData>();
            UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData = new List<WorkoutData>();
            UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData = ShareExerciseData;
            //UploadExercise();
            //UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState"); UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
            UIUploading.GetComponent<UI_Uploading>().FriendList = new List<string>();
            UIManager.GetComponent<UI_Manager>().SwitchStates("UploadingState");
        }
        else
        {
        }
    }
    /*
    public void UploadExercise()
    {
        // serialize
        SaveExerciseData UserExerciseData = new SaveExerciseData();
        for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData.Count; i++)
        {
            UserExerciseData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData[i]);
        }

        string Data = SerializeObject(UserExerciseData, "SaveExerciseData");
        string FileName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + ".xml";

        StartCoroutine(UploadFile(FileName, Data, "share_exercise"));
    }

    IEnumerator UploadFile(string FileName, string Data, string FileType)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        byte[] bytes = Encoding.UTF8.GetBytes(Data);
        print(Data);

        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hash);
        form.AddField("action", FileType);
        form.AddBinaryData("fileUpload", bytes, FileName, "text/xml");

        WWW w = new WWW(URL, form);
        yield return w;
        print(w.error);
        print(w.text);

        if (w.error != null)
        {
            print(w.error);
        }
        else
        {
            if (formText.Contains("HASH code is different from your app"))
            {
                print("file failed to upload.");
                //UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
            }
            else
            {
                print("Exercises uploaded successfully !");
                print(w.text);
            }
        }
        w.Dispose();

    }

    // The following metods came from the referenced URL 
    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }

    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }

    string SerializeObject(object pObject, string myType)
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();
        // type of need to be the type of data we are saving
        XmlSerializer xs = new XmlSerializer(typeof(SaveWorkoutData));
        switch (myType)
        {
            case "SaveDownloadTrainingData":
                xs = new XmlSerializer(typeof(SaveDownloadTrainingData));
                break;
            case "SaveDownloadWorkoutData":
                xs = new XmlSerializer(typeof(SaveDownloadWorkoutData));
                break;
            case "SaveDownloadExerciseData":
                xs = new XmlSerializer(typeof(SaveDownloadExerciseData));
                break;
            case "SaveTrainingData":
                xs = new XmlSerializer(typeof(SaveTrainingData));
                break;
            case "SaveWorkoutData":
                xs = new XmlSerializer(typeof(SaveWorkoutData));
                break;
            case "SaveExerciseData":
                xs = new XmlSerializer(typeof(SaveExerciseData));
                break;
            case "SaveDayData":
                xs = new XmlSerializer(typeof(SaveDayData));
                break;
            case "SaveSettingsData":
                xs = new XmlSerializer(typeof(SaveSettingsData));
                break;
            case "SaveFriendData":
                xs = new XmlSerializer(typeof(SaveFriendData));
                break;
        }

        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        xmlTextWriter.Settings.Indent = true;
        xmlTextWriter.Formatting = Formatting.Indented;
        xs.Serialize(xmlTextWriter, pObject);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
        return XmlizedString;
    }
    */
}
