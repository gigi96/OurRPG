using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject player;
    public GameController gameController;

    private int restartScene = 0;
    private bool notPressPause = false;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Pause") > 0)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!notPressPause)
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
        
        if(gameController.GetGameOver())
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            player.GetComponentInChildren<RotateCamera>().enabled = false;
            notPressPause = true;            
        }

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponentInChildren<RotateCamera>().enabled = true;
    }

    public void RestartGame()
    {                        
        SceneManager.LoadScene(restartScene);        
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        gameController.ResetGameOver();
        notPressPause = false;        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        gameController.ResetGameOver();
        notPressPause = false;
    }
}
