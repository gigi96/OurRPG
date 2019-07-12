using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int score;
    private float timeElapsed;

    public int bonusSilverCoin = 1;
    public int bonusGoldCoin = 2;    
    public int bonusDiamond = 5;    
    public int bonusHeart = 10;

    public float GetScore() { return score; }
    public float GetTimeElapsed() { return timeElapsed; }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
    }    

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
}
