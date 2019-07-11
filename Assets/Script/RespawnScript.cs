using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RespawnScript : MonoBehaviour {

    public Transform respawnPoint1, respawnPoint2, respawnPoint3; //Place holder for the spawn points     
    List<Transform> respawnPoint = new List<Transform>();
    System.Random rand = new System.Random();

    // Triggers when the player enters the water
    void OnTriggerEnter(Collider other) {


        respawnPoint.Add(respawnPoint1);
        respawnPoint.Add(respawnPoint2);
        respawnPoint.Add(respawnPoint3);

        // Moves the player to the spawn point
        other.gameObject.GetComponent<CharacterController>().enabled = false;
		other.gameObject.transform.position = respawnPoint[(rand.Next())%3].position;
        other.gameObject.GetComponent<CharacterController>().enabled = true;

    }
}
