using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RespawnScript : MonoBehaviour
{

    public Transform respawnPoint;    

    // Triggers when the player enters the water
    void OnTriggerEnter(Collider other)
    {     

        // Moves the player to the spawn point
        other.gameObject.GetComponent<CharacterController>().enabled = false;
		other.gameObject.transform.position = respawnPoint.position;
        other.gameObject.GetComponent<CharacterController>().enabled = true;

    }
}
