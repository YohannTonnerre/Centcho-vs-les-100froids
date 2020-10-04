using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDeathCount : MonoBehaviour
{
    public static int ScoreValue = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreValue >= 20)
        {
            score.text = "bien ouej";
        }
        else
        {
            score.text = "" + ScoreValue;

        }


    }
}
