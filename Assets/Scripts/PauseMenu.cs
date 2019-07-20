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

    UnityEvent gameOverEvent, pauseEvent;
    private bool temp1 = false;
    private bool temp2 = false;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("player");

        if (gameOverEvent == null)
            gameOverEvent = new UnityEvent();

        gameOverEvent.AddListener(ListenerGameOverEvent);

        if (pauseEvent == null)
            pauseEvent = new UnityEvent();

        pauseEvent.AddListener(ListenerPauseEvent);
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

                    if (!temp2)
                    {
                        ListenerPauseEvent();
                        temp2 = true;
                    }

                    Time.timeScale = 0f;
                    player.GetComponentInChildren<RotateCamera>().enabled = false;
                    player.GetComponent<RotateCharacter>().enabled = false;

                }
            }
        }   
        
        if(gameController.GetGameOver())
        {
            gameOverMenu.SetActive(true);

            if(!temp1)
            {
                ListenerGameOverEvent();
                temp1 = true;
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

        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(null);
        temp2 = false;
    }

    public void RestartGame()
    {                  
        if(pauseMenu.activeSelf)
            temp2 = false;

        SceneManager.LoadScene(restartScene);        
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        player.GetComponent<RotateCharacter>().enabled = true;
        gameController.ResetGameOver();
        notPressPause = false;

        temp1 = false;
        
    }

    public void RestartLevel()
    {
        if (pauseMenu.activeSelf)
            temp2 = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.GetComponentInChildren<RotateCamera>().enabled = true;
        player.GetComponent<RotateCharacter>().enabled = true;
        gameController.ResetGameOver();
        notPressPause = false;

        temp1 = false;
    }

    void ListenerGameOverEvent()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("RestartLevelButton"));
    }

    void ListenerPauseEvent()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ResumeButton"));
    }
}
