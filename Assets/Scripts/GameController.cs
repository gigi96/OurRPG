using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score;
    private float timeElapsed;
    private int level;
    private int totalLevels = 3; // ci sono in totale 3 livelli

    public int bonusSilverCoin = 1;
    public int bonusGoldCoin = 2;    
    public int bonusDiamond = 5;    
    public int bonusHeart = 10;

    public float GetScore() { return score; }
    public float GetTimeElapsed() { return timeElapsed; }
    public float GetLevel() { return level; }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timeElapsed = 0;
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
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

    public void FinishLevel()
    {
        print(level);
        if(level < totalLevels - 1)
        {
            level++;
            SceneManager.LoadScene(level); 
        }  
        else
        {
            level = 0;
            SceneManager.LoadScene(level);
        }
    }
}
