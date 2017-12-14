using UnityEngine;
using System.Collections;

public class UI_PopUpYesNoDialogBox : MonoBehaviour
{
    public GameObject UIManager;
    public GameObject UserBlobManager;
    public GameObject ButtonOk;
    public GameObject ButtonCancel;
    public GameObject TextMessage;

    public Component Sender;

    // Use this for initialization
    void Start()
    {
        UIManager = GameObject.Find("UI_Manager_Prefab");
        UserBlobManager = GameObject.Find("UserBlob_Prefab");
    }

    public void OkButtonPressed()
    {
        Sender.SendMessage("YesNoDialog", "ok");
        Destroy(this.gameObject);
    }
    public void CancelButtonPressed()
    {
        Sender.SendMessage("YesNoDialog", "cancel");
        Destroy(this.gameObject);
    }
}
