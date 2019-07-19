using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject player;
    public GameController gameController;

    private int restartScene = 0;
    private bool notPressPause = false;

    private string pauseAxis = "Pause";

    UnityEvent gameOverEvent;
    private bool temp = false;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("player");

        if (gameOverEvent == null)
            gameOverEvent = new UnityEvent();

        gameOverEvent.AddListener(Ping);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(pauseAxis))        
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
                    player.GetComponent<RotateCharacter>().enabled = false;

                }
            }
        }   
        
        if(gameController.GetGameOver())
        {
            gameOverMenu.SetActive(true);
            if(!temp)
            {
                Ping();
                temp = true;
            }
            
            Time.timeScale = 0f;
            player.GetComponentInChildren<RotateCamera>().enabled = false;
            player.GetComponent<RotateCharacter>().enabled = false;
            notPressPause = true;            
        }

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        player.GetComponent<RotateCharacter>().enabled = true;        
    }

    public void RestartGame()
    {                        
        SceneManager.LoadScene(restartScene);        
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        player.GetComponent<RotateCharacter>().enabled = true;
        gameController.ResetGameOver();
        notPressPause = false;

        temp = false;
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        player.GetComponent<RotateCharacter>().enabled = true;
        gameController.ResetGameOver();
        notPressPause = false;

        temp = false;
    }

    void Ping()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("RestartLevelButton"));
    }
}
