using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private CharacterController controller;
    private AudioSource footstepAudioSource, jumpAudioSource;   
    Vector3 velocity;

    private bool temp;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        footstepAudioSource = GameObject.Find("AudioSources").GetComponents<AudioSource>()[3]; // footstepSource
        jumpAudioSource = GameObject.Find("AudioSources").GetComponents<AudioSource>()[4]; // audioSource
        footstepAudioSource.loop = false;
        jumpAudioSource.loop = false;
        controller = GetComponent<CharacterController>();        

        temp = false;
    }

    // Update is called once per frame
    void Update()
    {       
        velocity = controller.velocity;
        isJumping = GetComponent<SetAxisScript>().JumpInput;

        if (controller.isGrounded)
        {            
            temp = false;
            if (!footstepAudioSource.isPlaying)
                if ((Mathf.Abs(velocity.x) > 0.1f || Mathf.Abs(velocity.z) > 0.1f))
                    footstepAudioSource.Play();
        }
        else
        {
            if(isJumping)
                if (!jumpAudioSource.isPlaying && !temp)
                {
                    jumpAudioSource.Play();
                    temp = true;
                }
        }
                
    }
}
