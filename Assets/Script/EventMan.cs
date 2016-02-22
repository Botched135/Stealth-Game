using UnityEngine;
using System.Collections;

public class EventMan : MonoBehaviour {


    public delegate void PlayerSpotted();
    public static event PlayerSpotted isPlayerSpotted;
    public GameObject Enemy, VisibleSpot;
    public bool ActiveAlarm = false;
	// Use this for initialization
	void Awake () {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        VisibleSpot = GameObject.FindGameObjectWithTag("Spot");
	}
	
	// Update is called once per frame
	void Update () {
        if(Enemy.GetComponent<EnemySight>().playerInSight || VisibleSpot.GetComponent<ActivationAlarm>().isActive)
        {
            isPlayerSpotted();
            ActiveAlarm = true; 
        }
        else
        {
            ActiveAlarm = false;
        }
	
	}
}
