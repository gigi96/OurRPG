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
        text.text = "Score: " + ((int)(gameController.GetScore())).ToString() +
                    "\nTotal time: " + ((int)(gameController.GetTimeElapsed())).ToString();
    }
}
