using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreRender : MonoBehaviour
{
    [SerializeField]
    private bool isEndgame = false;

    [SerializeField]
    private TMPro.TextMeshProUGUI textUI;

    private String scoreToShow()
    {
        if (isEndgame)
            return ScoreManager.Instance.getStringScore(
                HighscoreManager.Instance.getLastSavedScore());
        
        return ScoreManager.Instance.getStringScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "Score: " + scoreToShow();
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = "Score: " + scoreToShow();
    }
}
