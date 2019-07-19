using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score;    
    private float timeRemaining;
    private int level;
    private int totalLevels = 3; // ci sono in totale 3 livelli
    private bool gameOver;

    public int bonusSilverCoin = 1;
    public int bonusGoldCoin = 2;    
    public int bonusDiamond = 5;    
    public int bonusHeart = 10;
    public int malusFlame = -5;

    public float[] maxTime = { -1f, 5f, 300f, 600f }; // -1 (non ha significato, dato che il tempo non serve per il menu iniziale
                                                        // 180 secondi per il primo livello
                                                        // 300 secondi per il secondo livello
                                                        // 600 secondi per il terzo livello  

    private AudioSource audioSource;


    public float GetScore() { return score; }
    public float GetTimeRemaining() { return timeRemaining; }
    public float GetLevel() { return level; }
    public bool GetGameOver() { return gameOver; }
    public void ResetGameOver() { gameOver = false; }


    // Start is called before the first frame update
    void Start()
    {        
        score = 0;
        level = SceneManager.GetActiveScene().buildIndex;
        timeRemaining = maxTime[level] - 1;
        gameOver = false;
        Time.timeScale = 1f;

        audioSource = GameObject.Find("AudioSources").GetComponents<AudioSource>()[0]; // backgrounSdource     


    }

    // Update is called once per frame
    void Update()
    {                
        if (!gameOver)
        {
            if (timeRemaining < 0.1f)
            {
                
                gameOver = true;                
                Time.timeScale = 0f;                
            }
        }        

        timeRemaining -= Time.deltaTime;
    }

    #region PowerUp collected methods
    public void SilverCoinCollected()
    {
        score += bonusSilverCoin;        
        print(score);
    }

    public void GoldCoinCollected()
    {
        score += bonusGoldCoin;
        print(score);
    }

    public void DiamondCollected()
    {
        score += bonusDiamond;
        print(score);
    }

    public void HeartCollected()
    {
        score += bonusHeart;
        print(score);
    }
    #endregion

    #region PowerDown methods
    public void FlameMalus()
    {
        score += malusFlame;
        print(score);
    }
    #endregion

    public void FinishLevel()
    {        
        if(level < totalLevels)
        {
            level++;
            SceneManager.LoadScene(level); 
        }  
        else
        {
            level = 1;
            SceneManager.LoadScene(level);
        }
    }
    
}
