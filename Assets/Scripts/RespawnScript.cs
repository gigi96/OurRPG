using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RespawnScript : MonoBehaviour
{

    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    //void OnCollisionEnter(Collision other)
    {
        print("ciao");
        // Moves the player to the spawn point
        other.gameObject.GetComponent<CharacterController>().enabled = false;
		other.gameObject.transform.position = respawnPoint.position;
        other.gameObject.GetComponent<CharacterController>().enabled = true;

    }
}
