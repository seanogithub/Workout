using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Text.RegularExpressions;
using System.Linq;

public class UI_NewUser : MonoBehaviour {

	public bool Initialize = false;
	public GameObject UserBlobManager;
	public GameObject UIManager;
    public GameObject UserScreenName;
    public GameObject UserPassword;
    public GameObject UserEmail;
    public GameObject UserFirstName;
    public GameObject UserLastName;
    public GameObject UserStreetAddress;
    public GameObject UserCity;
    public GameObject UserState;
    public GameObject UserZip;
    public GameObject ButtonMale;
    public GameObject ButtonFemale;

    private string UserGender = "";

    public Transform NewUserContentPanel;
    public GameObject NewUserContentPanelScrollBar;
    public bool ScrollBarMove = false;

    public Color SelectedColor = Color.red;

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
		
		UpdateUI ();
	}
	
	public void Init()
	{
        Initialize = false;
        UserScreenName.GetComponent<InputField>().text = "";
        UserPassword.GetComponent<InputField>().text = "";
        UserEmail.GetComponent<InputField>().text = "";
        UserFirstName.GetComponent<InputField>().text = "";
        UserLastName.GetComponent<InputField>().text = "";
        UserStreetAddress.GetComponent<InputField>().text = "";
        UserCity.GetComponent<InputField>().text = "";
        UserState.GetComponent<InputField>().text = "";
        UserZip.GetComponent<InputField>().text = "";
        UserGender = "";
    }
	
	void UpdateUI()
	{
	}

    public void OnMaleButtonPressed()
    {
        ButtonMale.GetComponent<Image>().color = SelectedColor;
        ButtonFemale.GetComponent<Image>().color = Color.white;
        UserGender = "Male";
    }

    public void OnFemaleButtonPressed()
    {
        ButtonMale.GetComponent<Image>().color = Color.white;
        ButtonFemale.GetComponent<Image>().color = SelectedColor;
        UserGender = "Female";
    }


    public void OnScrollBarChanged()
    {
        if (ScrollBarMove == true)
        {
            //int ButtonHeight = 150;
            //double ButtonOffset = 0; // 2.5;
            //int NumButtons = 20;
            float ScrollPercentage = NewUserContentPanelScrollBar.GetComponent<Scrollbar>().value * 1;
            Vector3 tempPos = new Vector3(0, 0, 0);
            //tempPos.y = (ScrollPercentage * ButtonHeight) - (NumButtons * ButtonHeight / 2) + (ButtonHeight / 2) + ((float)ButtonOffset * (ButtonHeight));
            tempPos.y = (ScrollPercentage * 2050) - 1000;
            NewUserContentPanel.localPosition = tempPos;
        }
        ScrollBarMove = true;
    }

    public void OnPanelValueChanged()
    {
        ScrollBarMove = false;
        int ButtonHeight = 150;
        int NumButtons = 20;
        float ScrollValue = ((NewUserContentPanel.localPosition.y + (ButtonHeight * (NumButtons - 8) / 2)) / (NumButtons - 8) / ButtonHeight);
        NewUserContentPanelScrollBar.GetComponent<Scrollbar>().value = ScrollValue;
    }

    public void OnOKButtonPressed()
    {
        //string validLetters = "^[a-zA-Z- ]*$";
        //string validNumbers = "^[0-9- ]*$";
        string validLettersNumbers = "^[a-zA-Z0-9- ]*$";
        //Regex RegLetters = new Regex(validLetters);
        //Regex RegNumbers = new Regex(validNumbers);
        Regex RegLettersNumbers = new Regex(validLettersNumbers);

        string errorMessage = "";
        bool allFieldsFilled = true;
        string formScreenName = UserScreenName.GetComponent<InputField>().text;
        string formPassword = UserPassword.GetComponent<InputField>().text;
        string formEmail = UserEmail.GetComponent<InputField>().text;
        string formFirstName = UserFirstName.GetComponent<InputField>().text;
        string formLastName = UserLastName.GetComponent<InputField>().text;
        string formStreetAddress = UserStreetAddress.GetComponent<InputField>().text;
        string formCity = UserCity.GetComponent<InputField>().text;
        string formState = UserState.GetComponent<InputField>().text;
        string formZip = UserZip.GetComponent<InputField>().text;
        string formGender = UserGender;

        if (formScreenName == "")
        {
            allFieldsFilled = false;
            errorMessage = ("No screen name entered.");
        }
        if (formPassword == "" && allFieldsFilled == true)
        {
            allFieldsFilled = false;
            errorMessage = ("No password entered.");
        }
        if (formEmail == "" && allFieldsFilled == true)
        {
            allFieldsFilled = false;
            errorMessage = ("No email entered.");
        }
        if (formFirstName == "" && allFieldsFilled == true)
        {
            allFieldsFilled = false;
            errorMessage = ("No first name entered.");
        }
        if (formLastName == "" && allFieldsFilled == true)
        {
            allFieldsFilled = false;
            errorMessage = ("No last name entered.");
        }
        if (formGender == "" && allFieldsFilled == true)
        {
            allFieldsFilled = false;
            errorMessage = ("No gender entered.");
        }
        //check for bad chars
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
        if (!formEmail.All(char.IsLetterOrDigit))
        {
            if (!formEmail.Contains("."))
            {
                allFieldsFilled = false;
                errorMessage = ("Please enter a valid email address that contains an . symbol");
            }
            if (!formEmail.Contains("@"))
            {
                allFieldsFilled = false;
                errorMessage = ("Please enter a valid email address that contains an @ symbol");
            }
            string temp = formEmail.Replace("@", "");
            temp = temp.Replace(".", "");
            if (!temp.All(char.IsLetterOrDigit))
            {
                allFieldsFilled = false;
                errorMessage = ("Please enter an email address without any extra symbols");
            }
        }
        else
        {
            allFieldsFilled = false;
            errorMessage = ("Please enter a valid email address.");
        }
        if (!RegLettersNumbers.IsMatch(formFirstName))
        {
            allFieldsFilled = false;
            errorMessage = ("First name can only contain letters.");
        }
        if (!RegLettersNumbers.IsMatch(formLastName))
        {
            allFieldsFilled = false;
            errorMessage = ("Last name can only contain letters.");
        }
        if (!RegLettersNumbers.IsMatch(formStreetAddress))
        {
            allFieldsFilled = false;
            errorMessage = ("Street address can only contain letters and numbers.");
        }
        if (!RegLettersNumbers.IsMatch(formCity))
        {
            allFieldsFilled = false;
            errorMessage = ("City can only contain letters.");
        }
        if (!RegLettersNumbers.IsMatch(formState))
        {
            allFieldsFilled = false;
            errorMessage = ("State can only contain letters.");
        }
        if (!RegLettersNumbers.IsMatch(formZip))
        {
            allFieldsFilled = false;
            errorMessage = ("Zip code can only contain numbers.");
        }

        if (allFieldsFilled)
        {
            StartCoroutine(Register(formScreenName, formPassword, formEmail, formFirstName, formLastName, formStreetAddress, formCity, formState, formZip, formGender));
        }
        else
        {
            if (PopUpActive == false)
            {
                PopUpOkDialog(errorMessage, this.gameObject.GetComponent<UI_NewUser>(), "BadData");
            }

            print(errorMessage);
        }
    }

    IEnumerator Register(string formScreenName, string formPassword, string formEmail, string formFirstName, string formLastName, string formStreetAddress, string formCity, string formState, string formZip, string formGender)
    {
        string formText = "";
        string URL = UserBlobManager.GetComponent<UserBlobManager>().ServerURL + "uw.php";
        string hash = UserBlobManager.GetComponent<UserBlobManager>().ServerHash;

        WWWForm form = new WWWForm();
        form.AddField("action", "register");
        form.AddField("myform_hash", hash);
        form.AddField("myform_ScreenName", formScreenName);
        form.AddField("myform_Password", formPassword);
        form.AddField("myform_Email", formEmail);
        form.AddField("myform_FirstName", formFirstName);
        form.AddField("myform_LastName", formLastName);
        form.AddField("myform_StreetAddress", formStreetAddress);
        form.AddField("myform_City", formCity);
        form.AddField("myform_State", formState);
        form.AddField("myform_Zip", formZip);
        form.AddField("myform_Gender", formGender);

        WWW w = new WWW(URL, form);
        yield return w;
        print(w.error);
        print(w.text);
        if (w.error != null)
        {
            if (w.error.Contains("Screen name already used"))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Screen name already used", this.gameObject.GetComponent<UI_NewUser>(), "BadData");
                }
                print(w.error);
            }
            if (w.error.Contains("Email already used"))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Email already used", this.gameObject.GetComponent<UI_NewUser>(), "BadData");
                }
                print(w.error);
            }

        }
        else
        {
            if (formText.Contains("HASH code is different from your app"))
            {
                if (PopUpActive == false)
                {
                    PopUpOkDialog("Failed to connect to server", this.gameObject.GetComponent<UI_NewUser>(), "BadData");
                }
            }
            else
            {
                formText = w.text;
                print(formText);
                if (formText.Contains("Registration OK"))
                {
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin = formScreenName;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserPassword = formPassword;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserEmail = formEmail;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserFirstName = formFirstName;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLastName = formLastName;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserStreetAddress = formStreetAddress;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserCity = formCity;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserState = formState;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserZip = formZip;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserGender = formGender;
                    UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.RememberLoginPassword = true;
                    UserBlobManager.GetComponent<UserBlobManager>().SaveSettings();

                    print("Registration successful !");
                    w.Dispose();
                    UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
                }
            }
        }
        w.Dispose();

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
            case "BadData":
                if (DialogState == "ok")
                {
                    print("BadData");
                }
                break;
        }
        PopUpOkDialogState = "";
        PopUpActive = false;
    }
}
