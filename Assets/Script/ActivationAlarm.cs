using UnityEngine;
using System.Collections;

public class ActivationAlarm : MonoBehaviour {
    public bool playerWithin = false;
    public bool isActive = false;
    private GameObject player;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void OnTriggerStay(Collider other) {
        
        if(other.gameObject == player)
        {
            playerWithin = true;
            if (player.GetComponent<PlayerInteraction>().PressingKey)
            {
                isActive = !isActive; 
            }
        }
	
	}
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerWithin = false;
        }
    }

}
