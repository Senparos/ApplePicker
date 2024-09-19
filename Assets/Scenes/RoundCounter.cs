using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RoundCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int round = 1;
    private TextMeshProUGUI uiText;
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        round = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(scoreCounter.score == 500)
            round = 2;
        else if(scoreCounter.score == 1000)
            round = 3;
        else if(scoreCounter.score == 2000)
            round = 4;
        uiText.text = "Round: " + round.ToString();
    }
}
