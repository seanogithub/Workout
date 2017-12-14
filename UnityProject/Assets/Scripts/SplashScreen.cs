using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Text.RegularExpressions;


[RequireComponent(typeof(GUITexture))]
public class SplashScreen : MonoBehaviour {

	public bool Enabled = true;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject VersionNumberText;
	public float SplashScreenTime = 1.0f;
	public float myTimer = 0;
    public bool VersionMatches = false;
    public string CurrentVersion = "";

    public string PopUpYesNoDialogState = "";
    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake ()
    {
		myTimer = SplashScreenTime;	
//		print (Application.persistentDataPath);
    }
	
	void Start()
	{
        VersionMatches = false;
        UIManager = GameObject.Find("UI_Manager_Prefab");
        CurrentVersion = UserBlobManager.GetComponent<UserBlobManager>().VersionNumber;
        VersionNumberText.GetComponent<Text>().text = CurrentVersion;
        StartCoroutine(GetVersionNumber());
    }

    void Update ()
    {
		if(Enabled == true)
		{
			myTimer -= Time.deltaTime;
			if (myTimer < 0)
			{
                if (VersionMatches == true)
                {
                    UIManager.GetComponent<UI_Manager>().SwitchStates("HomeState");
                    myTimer = SplashScreenTime;
                }
            }
		}
	}


    IEnumerator GetVersionNumber()
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;

        WWWForm form = new WWWForm();
        form.AddField("action", "get_version_number");
        form.AddField("myform_hash", hash);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);
            VersionMatches = true;
        }
        else
        {
            formText = w.text.ToString();
            formText = formText.Replace("\n","");
            formText = formText.Replace("\r", "");
            if (!formText.Contains("Cant Find Version Number"))
            {
                if(CurrentVersion == formText)
                {
                    VersionMatches = true;
                    print("Versions are the same");
                }
                else
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog("There is a newer version of the app. Please update to the latest version in the App Store.", this.gameObject.GetComponent<SplashScreen>(), "WrongVersionNumber");
                    }
                    print("Versions are different");
                }
            }
        }
    }

    void PopUpOkDialog(string myMessage, Component mySender, string myState)
    {
        var temp = Resources.Load("UI/UI_PopUpOkDialogBox_Prefab") as GameObject;
        var myPopUpOK = GameObject.Instantiate(temp, (new Vector3(0.0f, 0.0f, 1.0f)), Quaternion.identity) as GameObject;
        myPopUpOK.GetComponent<UI_PopUpOkDialogBox>().Sender = mySender;
        myPopUpOK.GetComponent<UI_PopUpOkDialogBox>().TextMessage.GetComponent<Text>().text = myMessage;
        myPopUpOK.SetActive(true);
        PopUpOkDialogState = myState;
        PopUpActive = true;
    }

    public void OkDialog(string DialogState)
    {
        switch (PopUpOkDialogState)
        {
            case "WrongVersionNumber":
                if (DialogState == "ok")
                {
                    print("Wrong Version Number");
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }
}
