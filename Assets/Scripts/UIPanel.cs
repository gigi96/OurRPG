using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public GameController gameController;
    private Text text;     

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "LEVEL " + ((int)(gameController.GetLevel())).ToString() +
                        "\n\nScore: " + ((int)(gameController.GetScore())).ToString() +
                        "\nTime remaining: " + ((int)(Mathf.Floor(gameController.GetTimeRemaining() / 60))).ToString("0") +
                         ":" + ((int)(Mathf.RoundToInt(gameController.GetTimeRemaining() % 60))).ToString("00");          
    }
}
