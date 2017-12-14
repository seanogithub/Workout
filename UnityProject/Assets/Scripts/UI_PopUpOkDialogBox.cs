using UnityEngine;
using System.Collections;

public class UI_PopUpOkDialogBox : MonoBehaviour {

    public GameObject UIManager;
    public GameObject UserBlobManager;
    public GameObject ButtonOk;
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
        Sender.SendMessage("OkDialog", "ok");
        Destroy(this.gameObject);
    }
}
