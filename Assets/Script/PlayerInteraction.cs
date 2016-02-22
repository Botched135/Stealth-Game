using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {
    GameObject ActivationBox;
    public bool PressingKey;
	void Awake () {
        PressingKey = false;
        ActivationBox = GameObject.FindGameObjectWithTag("Spot");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
            PressingKey = true;
        else
            PressingKey = false;
	}
    void OnGUI()
    {
        if (ActivationBox.GetComponent<ActivationAlarm>().playerWithin)
            GUI.Button(new Rect((Screen.width/2)-150, Screen.height-100, 300, 50), 
                "Press to active/deactive Alarm \n Alarm is currently "+ 
                ((ActivationBox.GetComponent<ActivationAlarm>().isActive == true) ? "active" : "deactive"));
    }
}
