using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public class UI_LoginAuto : MonoBehaviour {

    public bool Initialize = false;
    public GameObject UserBlobManager;
    public GameObject UIManager;
    public GameObject UIShare;
    public GameObject MessageText;
    public GameObject WaitAnimationImage;

    private Texture2D[] WaitAnimationImageArray;
    private Timer WaitAnimationTimer = new Timer();
    private int WaitAnimationImageIndex = 0;

    //public string PopUpYesNoDialogState = "";
    //public string PopUpOkDialogState = "";
    //private bool PopUpActive = false;

    void Awake()
    {
        UserBlobManager = GameObject.Find("UserBlob_Prefab");
        UIManager = GameObject.Find("UI_Manager_Prefab");
        WaitAnimationImageArray = Resources.LoadAll<Texture2D>("UI/WaitAnimation");
    }

    // Use this for initialization
    void Start ()
    {
    }

    public void Init()
    {
        Initialize = false;

        WaitAnimationImageIndex = 0;
        WaitAnimationTimer = new Timer();
        WaitAnimationTimer.Interval = 30;
        WaitAnimationTimer.Elapsed += new ElapsedEventHandler(OnWaitAnimationTimerEvent);
        WaitAnimationTimer.Start();

        WaitAnimationImage.GetComponent<RawImage>().texture = WaitAnimationImageArray[0];

        string formScreenName = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserLogin;
        string formPassword = UserBlobManager.GetComponent<UserBlobManager>().UserSettingsData.UserPassword;

        MessageText.GetComponent<Text>().text = "Logging In";

        if (formScreenName == "" || formPassword == "")
        {
            UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
        }
        
        StartCoroutine(Login(formScreenName, formPassword));
    }

    // Update is called once per frame
    void Update()
    {
        if (Initialize)
        {
            Init();
        }

        // update wait animation
        WaitAnimationImage.GetComponent<RawImage>().texture = WaitAnimationImageArray[WaitAnimationImageIndex];

    }

    public void OnWaitAnimationTimerEvent(object source, ElapsedEventArgs e)
    {
        WaitAnimationImageIndex++;
        if(WaitAnimationImageIndex >= WaitAnimationImageArray.Length - 1)
        {
            WaitAnimationImageIndex = 0;
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
        
        WWWForm form = new WWWForm();
        form.AddField("action", "login");
        form.AddField("myform_hash", hash);
        form.AddField("myform_ScreenName", formScreenName);
        form.AddField("myform_Password", result); // formPassword);
        form.AddField("myform_Date", date);
        WWW w = new WWW(URL, form);
        yield return w;

        if (w.error != null)
        {
            // connection error
            print(w.error);

            UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
        }
        else
        {
            formText = w.text;

            if (formText.Contains("HASH code is different from your app"))
            {
                print("Can't connect");
                w.Dispose();
                UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
            }
            else
            {
                if (formText.Contains("ScreenName or password is wrong."))
                {
                    UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
                }

                if (formText.Contains("Data invalid - cant find name"))
                {
                    UIManager.GetComponent<UI_Manager>().SwitchStates("LoginState");
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
                    WaitAnimationTimer.Stop();
                    UIShare.GetComponent<UI_Share>().UpdateFriendList = true;
                    UIManager.GetComponent<UI_Manager>().SwitchStates("ShareState");
                }
            }
        }
        w.Dispose();
    }
}
