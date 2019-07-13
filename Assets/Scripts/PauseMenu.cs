﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;

    private int restartScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Pause") > 0)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                player.GetComponentInChildren<RotateCamera>().enabled = false;

            }
        }            

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponentInChildren<RotateCamera>().enabled = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        SceneManager.LoadScene(restartScene);
    }
}