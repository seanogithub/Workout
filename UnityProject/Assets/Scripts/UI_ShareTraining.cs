using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class UI_ShareTraining : MonoBehaviour {

	
	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIUploading;
    public GameObject TrainingButton;
	
//	public List<TrainingData> UserTrainingData = new List<TrainingData>();	
	public SaveTrainingData UserTrainingData;

	public List<TrainingData> ShareTrainingData = new List<TrainingData>();
	public TrainingData item = new TrainingData();
	
	public List<GameObject> TrainingButtonArray = new List<GameObject>();
	
	public Transform TrainingContentPanel;
	public GameObject TrainingContentPanelScrollBar;
	public bool ScrollBarMove = false;
	
	public int SelectedTraining = -1;
	public List<string> ShareTrainingList = new List<string> ();

	public Color SelectedColor = Color.red;
	
	void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
		UserTrainingData = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData;
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
		ShareTrainingList = new List<string> ();
		UserTrainingData = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData;
		SelectedTraining = -1;
//		UserBlobManager.GetComponent<UserBlobManager> ().CurrentTrainingIndex = SelectedTraining;
		ClearScrollList ();
		PopulateScrollList ();
		
		if(UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length > 6)
		{
			SetScrollRectPositionFromIntWithOffset (0, 2.5, 200, UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length, TrainingContentPanel);
		}
		else
		{
			TrainingContentPanel.localPosition = new Vector3 (0, 0, 0); 
		}
	}
	
	public void ClearScrollList()
	{
		for (int i = TrainingContentPanel.childCount-1; i >= 0; i--) 
		{
			GameObject.DestroyImmediate(TrainingContentPanel.GetChild(i).gameObject);
		}
	}
	
	public void PopulateScrollList () 
	{
		TrainingButtonArray.Clear ();
		foreach (var item in UserTrainingData.Training)
		{
			GameObject newButton = Instantiate (TrainingButton) as GameObject;
			TrainingButtonArray.Add(newButton);
			newButton.name = ("Button_" + item.Name);
			newButton.transform.Find("Text_Name").GetComponent<Text>().text = item.Name;
			newButton.transform.Find("Text_Type").GetComponent<Text>().text = item.Type;
			string selectedButton = item.Name;
			newButton.GetComponent<Button>().onClick.AddListener(() => ExerciseButtonClicked(selectedButton));
			newButton.transform.SetParent (TrainingContentPanel);
		}
//		TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = SelectedColor;
	}
	
	public void ExerciseButtonClicked(string myText)
	{
		int myIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindTrainingByName (myText);
		SelectedTraining = myIndex;
		
		bool sel = false;
		foreach (var item in ShareTrainingList) 
		{
			if (item == myText)
			{
				sel = true;
			}
		}
		if (sel) 
		{
			// remove from list
			ShareTrainingList.Remove(myText);
			TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = Color.white;
		}
		else
		{
			ShareTrainingList.Add(myText);
			TrainingButtonArray[SelectedTraining].GetComponent<Image> ().color = SelectedColor;
		}
	}
	
	
	public void OnScrollBarChanged()
	{
		if (ScrollBarMove == true && UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length > 5)
		{
			int ButtonHeight = 200;
			double ButtonOffset = 2.5;
			int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length;
			float ScrollPercentage =  TrainingContentPanelScrollBar.GetComponent<Scrollbar>().value * (UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length - 6);
			Vector3 tempPos = new Vector3 (0, 0, 0);
			tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
			TrainingContentPanel.localPosition = tempPos;
		}
		ScrollBarMove = true;
	}
	
	public void OnPanelValueChanged()
	{		
		ScrollBarMove = false;
		int ButtonHeight = 200;
		//		double ButtonOffset = 2.8;
		int NumButtons = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training.Length;
		float ScrollValue =  ((TrainingContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 6) / 2)) / (NumButtons - 6) / ButtonHeight);
		TrainingContentPanelScrollBar.GetComponent<Scrollbar> ().value = ScrollValue;
	}
	
	void SetScrollRectPositionFromIntWithOffset(int myInteger, double ButtonOffset, int ButtonHeight, int NumButtons, Transform myScrollPanel)
	{
		Vector3 tempPos = new Vector3 (0, 0, 0);
		tempPos.y = (myInteger * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight)); 
		myScrollPanel.localPosition = tempPos;
	}
	
	public void OnShareButtonPressed ()
	{
		if(ShareTrainingList.Count > 0)
		{
			//build shared exercise data
			for(int i = 0; i < ShareTrainingList.Count; i++)
			{
				TrainingData tempTraining = new TrainingData();
				int TrainingIndex = UserBlobManager.GetComponent<UserBlobManager> ().FindTrainingByName(ShareTrainingList[i]);
				tempTraining = UserBlobManager.GetComponent<UserBlobManager> ().UserTrainingData.Training[TrainingIndex];
				ShareTrainingData.Add(tempTraining);
			}
			UserBlobManager.GetComponent<UserBlobManager> ().ShareTrainingData = ShareTrainingData;
            UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData = new List<WorkoutData>();
            UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData = new List<ExerciseData>();

            UIManager.GetComponent<UI_Manager>().SwitchStates("ShareFriendListState");
		}
		else 
		{
		}
	}

    public void OnShareEveryoneButtonPressed()
    {
        if (ShareTrainingList.Count > 0)
        {
            //build shared Training data
            for (int i = 0; i < ShareTrainingList.Count; i++)
            {
                TrainingData tempTraining = new TrainingData();
                int TrainingIndex = UserBlobManager.GetComponent<UserBlobManager>().FindTrainingByName(ShareTrainingList[i]);
                tempTraining = UserBlobManager.GetComponent<UserBlobManager>().UserTrainingData.Training[TrainingIndex];
                ShareTrainingData.Add(tempTraining);
            }
            UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData = ShareTrainingData;
            UserBlobManager.GetComponent<UserBlobManager>().ShareWorkoutData = new List<WorkoutData>();
            UserBlobManager.GetComponent<UserBlobManager>().ShareExerciseData = new List<ExerciseData>();
            //UploadTraining();
            //UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
            UIUploading.GetComponent<UI_Uploading>().FriendList = new List<string>();
            UIManager.GetComponent<UI_Manager>().SwitchStates("UploadingState");
        }
        else
        {
        }
    }

    /*
    public void UploadTraining()
    {
        // serialize
        SaveTrainingData UserTrainingData = new SaveTrainingData();
        for (int i = 0; i < UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData.Count; i++)
        {
            UserTrainingData.Add(UserBlobManager.GetComponent<UserBlobManager>().ShareTrainingData[i]);
        }

        string Data = SerializeObject(UserTrainingData, "SaveTrainingData");
        string FileName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin + ".xml";

        StartCoroutine(UploadFile(FileName, Data, "share_training"));
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
                print("File failed to upload.");
            }
            else
            {
                print(w.text);
                print("success !");

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

