using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameController controller;

    private AudioSource audioSource;    

    // Start is called before the first frame update
    void Start()
    {
        controller = GameController.FindObjectOfType<GameController>();
        audioSource = GameObject.Find("AudioSources").GetComponents<AudioSource>()[1]; // powerupSource       
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        audioSource.Play();        

        if (gameObject.tag == "SilverCoin")
            controller.SilverCoinCollected();
        else if (gameObject.tag == "GoldCoin")
            controller.GoldCoinCollected();
        else if (gameObject.tag == "Diamond")
            controller.DiamondCollected();
        else if (gameObject.tag == "Heart")
            controller.HeartCollected();

        Destroy(gameObject);        
    }
}
