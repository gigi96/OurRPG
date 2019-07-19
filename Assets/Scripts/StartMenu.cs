using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenu : MonoBehaviour
{   
    private int level1Scene = 1; // livello 1
    private int level2Scene = 2; // livello 2
    private int level3Scene = 3; // livello 3    

    private int startScene;

    public GameObject s1, s2; // s1: StartMenuScreen
                              // s2: SelectLevelScreen

    // Start is called before the first frame update
    void Start()
    {
        startScene = level1Scene;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(startScene);        
    }

    public void SelectLevel()
    {
        s1.SetActive(false);
        s2.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("Level1button"));
    }

    public void Level1()
    {
        startScene = level1Scene;
        Back();
    }

    public void Level2()
    {
        startScene = level2Scene;
        Back();
    }

    public void Level3()
    {
        startScene = level3Scene;
        Back();
    }

    public void Back()
    {
        s2.SetActive(false);
        s1.SetActive(true);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("PlayButton"));
    }
}
