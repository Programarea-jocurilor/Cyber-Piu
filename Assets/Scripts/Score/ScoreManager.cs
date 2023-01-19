using UnityEngine;
using System;

public class ScoreManager
{
    private static ScoreManager _instance = null;

    private ScoreManager()
    {
        
    }

    public static ScoreManager Instance { get { 
        if (_instance == null)
            _instance = new ScoreManager();
        
        return _instance;
    } }


    private float scoreOffset = 0;

    public void setOffset(float newOffset)
    {
        scoreOffset = newOffset;
    }

    public float getScore()
    {
        return Time.unscaledTime - scoreOffset;
    }

    public String getStringScore(float actualScore)
    {
        return actualScore.ToString("0.0");
    }

    public String getStringScore()
    {
        return getStringScore(getScore());
    }

    public void increaseOffset(float delta)
    {
        scoreOffset += delta;
    }
}