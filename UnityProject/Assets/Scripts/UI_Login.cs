using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public class UI_Login : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UIShare;
    public GameObject UserScreenName;
	public GameObject UserPassword;
    public GameObject UserRememberLoginPasswordCheckbox;
    public GameObject RegisterButton;

    public string PopUpYesNoDialogState = "";
    public string PopUpOkDialogState = "";
    private bool PopUpActive = false;

    void Awake()
	{
		UserBlobManager = GameObject.Find("UserBlob_Prefab");
		UIManager = GameObject.Find("UI_Manager_Prefab");
	}
	
	// Use this for initialization
	void Start () 
	{
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
        // don't register more than once
        if(UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin != "")
        {
            RegisterButton.SetActive(false);
        }
        UserScreenName.GetComponent<InputField>().text = "";
        UserPassword.GetComponent<InputField>().text = "";

        UserRememberLoginPasswordCheckbox.GetComponent<Toggle>().isOn = true; // UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.RememberLoginPassword;
        if (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.RememberLoginPassword == true)
        {
            if (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin != "" && UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserPassword != "")
            {
                string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
                string formPassword = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserPassword;
                UserScreenName.GetComponent<InputField>().text = formScreenName;
                UserPassword.GetComponent<InputField>().text = formPassword;
                StartCoroutine(Login(formScreenName, formPassword));
            }
        }
    }

    public void OnRememberLoginPasswordPressed()
    {
        //UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.RememberLoginPassword = UserRememberLoginPasswordCheckbox.GetComponent<Toggle>().isOn;
        //UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
    }

    public void OnHomeButtonPressed()
    {
        if (PopUpActive == false)
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("HomeState");
        }
    }

	public void OnLoginButtonPressed()
	{
        if (PopUpActive == false)
        {
            //string validLetters = "^[a-zA-Z- ]*$";
            //string validNumbers = "^[0-9- ]*$";
            string validLettersNumbers = "^[a-zA-Z0-9- ]*$";
            //Regex RegLetters = new Regex(validLetters);
            //Regex RegNumbers = new Regex(validNumbers);
            Regex RegLettersNumbers = new Regex(validLettersNumbers);

            string formScreenName = UserScreenName.GetComponent<InputField>().text;
            string formPassword = UserPassword.GetComponent<InputField>().text;
            bool allFieldsFilled = true;
            string errorMessage = "";
            if (formScreenName != "" && formPassword != "")
            {
                if (!RegLettersNumbers.IsMatch(formScreenName))
                {
                    allFieldsFilled = false;
                    errorMessage = ("Screen name can only contain letters and numbers.");
                }
                if (!RegLettersNumbers.IsMatch(formPassword))
                {
                    allFieldsFilled = false;
                    errorMessage = ("Password can only contain letters and numbers.");
                }

                if (allFieldsFilled == true)
                {
                    StartCoroutine(Login(formScreenName, formPassword));
                }
                else
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog(errorMessage, this.gameObject.GetComponent<UI_Login>(), "BadData");
                    }

                    print(errorMessage);
                }

            }
            else
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Please enter the Screen Name and the Password", this.gameObject.GetComponent<UI_Login>(), "WrongScreenNamePassword");
                }
            }
        }
	}

    private static string ByteArrayToHexString(byte[] byteArray)
    {
        string result = string.Empty;

        foreach (byte outputByte in byteArray)
        {
            result += outputByte.ToString("x2");
        }
        return result;
    }

    IEnumerator Login(string formScreenName, string formPassword)
	{
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;
        string date = System.DateTime.Now.Year.ToString("D4");
        date += System.DateTime.Now.Month.ToString("D2");
        date += System.DateTime.Now.Day.ToString("D2");

        // encrypt the password
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(hash + formPassword);
        System.Security.Cryptography.SHA512 sha = System.Security.Cryptography.SHA512.Create();
        byte[] shaHash = sha.ComputeHash(bytes);
        string result = ByteArrayToHexString(shaHash);

        WWWForm form = new WWWForm ();
        form.AddField("action", "login");
        form.AddField ("myform_hash", hash);
		form.AddField ("myform_ScreenName", formScreenName);
		form.AddField ("myform_Password", result);
        form.AddField("myform_Date", date);
        WWW w = new WWW (URL, form);
		yield return w;

		if (w.error != null)
		{
            // connection error
			print (w.error);

            if (w.error.Contains("Could not resolve host"))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Can NOT connect to server.\nPlease check your internet connection.", this.gameObject.GetComponent<UI_Login>(), "WrongScreenNamePassword");
                }
            }
        }
		else
		{
			formText = w.text;

            if (formText.Contains("HASH code is different from your app"))
            {
                print("Can't connect");
                w.Dispose();
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Cant connect to server.", this.gameObject.GetComponent<UI_Login>(), "WrongScreenNamePassword");
                }
            }
            else
            {
                if (formText.Contains("ScreenName or password is wrong."))
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog("Screen name or password is wrong.", this.gameObject.GetComponent<UI_Login>(), "WrongScreenNamePassword");
                    }
                }

                if (formText.Contains("Data invalid - cant find name"))
                {
                    if (PopUpActive == false)
                    {
                        PopUpOkDialog("Screen name is wrong.", this.gameObject.GetComponent<UI_Login>(), "WrongScreenNamePassword");
                    }
                }

                if (formText.Contains("PASSWORD CORRECT"))
                {
                    print("Login OK");
                    string[] tempArray = formText.Split('#');

                    string name = tempArray[1];
                    string firstName = tempArray[2];
                    string lastName = tempArray[3];
                    string email = tempArray[4];
                    string streetAddress = tempArray[5];
                    string city = tempArray[6];
                    string state = tempArray[7];
                    string zip = tempArray[8];
                    string gender = tempArray[9];

                    if (UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.RememberLoginPassword == true)
                    {
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin = name;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserPassword = formPassword;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserFirstName = firstName;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLastName = lastName;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserEmail = email;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserStreetAddress = streetAddress;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserCity = city;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserState = state;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserZip = zip;
                        UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserGender = gender;
                        UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();
                    }
                    UserBlobManager.GetComponent<UserBlobManager>().UserDownloadTrainingDataString = "";
                    UserBlobManager.GetComponent<UserBlobManager>().UserDownloadWorkoutDataString = "";
                    UserBlobManager.GetComponent<UserBlobManager>().UserDownloadExerciseDataString = "";
                    UIShare.GetComponent<UI_Share>().UpdateFriendList = true;
                    UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
                }
            }
        }
        w.Dispose();
    }

    void PopUpYesNoDialog(string myMessage, Component mySender, string myState)
    {
        var temp = Resources.Load("UI/UI_PopUpYesNoDialogBox_Prefab") as GameObject;
        var myPopUpYesNo = GameObject.Instantiate(temp, (new Vector3(0.0f, 0.0f, 1.0f)), Quaternion.identity) as GameObject;
        myPopUpYesNo.GetComponent<UI_PopUpYesNoDialogBox>().Sender = mySender;
        myPopUpYesNo.GetComponent<UI_PopUpYesNoDialogBox>().TextMessage.GetComponent<Text>().text = myMessage;
        myPopUpYesNo.SetActive(true);
        PopUpYesNoDialogState = myState;
        PopUpActive = true;
    }

    public void YesNoDialog(string DialogState)
    {
        switch (PopUpYesNoDialogState)
        {
            case "WrongScreenNamePassword":
                if (DialogState == "ok")
                {
                    print("DeleteDailyData ok");
                    //RemoveData();
                }
                if (DialogState == "cancel")
                {
                    print("DeleteDailyData cancel");
                }
                break;
        }
        PopUpYesNoDialogState = "";
        PopUpActive = false;
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
            case "WrongScreenNamePassword":
                if (DialogState == "ok")
                {
                    print("DeleteDailyData ok");
                    //RemoveData();
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }
}
