﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : MonoBehaviour
{
    public GameController controller;
    private AudioSource audioSource;

    private float deltaTimePowerDown = 3f; // ogni tre secondi decremento lo score del giocatore
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameController.FindObjectOfType<GameController>();
        audioSource = GameObject.Find("AudioSources").GetComponents<AudioSource>()[2]; // powerdownSource  
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < deltaTimePowerDown)
        {
            timer += Time.deltaTime;            
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider collider)    
    {
        audioSource.Play();         

        if (gameObject.tag == "Flame")
            controller.FlameMalus();
    }        
        
    
}
