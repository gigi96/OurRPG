using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    private float upCounter;
    private float downCounter;    
    private float deltaDim;

    public float minDim;
    public float maxDim;

    // Start is called before the first frame update
    void Start()
    {        
        upCounter = minDim;
        downCounter = maxDim;        
        deltaDim = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (upCounter < maxDim)
        {
            upCounter += deltaDim;
            transform.localScale = new Vector3(upCounter, upCounter, upCounter);
        }
        else
        {
            if(downCounter > minDim)
            {
                downCounter -= deltaDim;
                transform.localScale = new Vector3(downCounter, downCounter, downCounter);
            }
            else
            {
                upCounter = minDim;
                downCounter = maxDim;
            }
        }            
    }
}
