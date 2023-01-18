using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighscoreManager
{
    private static HighscoreManager _instance = null;

    public static HighscoreManager Instance { get { 
        if (_instance == null)
            _instance = new HighscoreManager();

        return _instance;
    } }

    private HighscoreManager()
    {
        if (!dataService.FileExists(fileName)) {
            dataService.SaveData<List<(String, float)>>(fileName, new List<(String, float)>());
        }
    }

    private const String fileName = "highscores";
    private static JsonDataService dataService = new JsonDataService();

    public void SaveHighscore(String saveName, float score)
    {
        var scores = dataService.LoadData<List<(String, float)>>(fileName);
        scores.Add((saveName, score));

        dataService.SaveData<List<(String, float)>>(fileName, scores);
    }

    private bool conditionToRegister()
    {
        return SceneManager.GetActiveScene().buildIndex == 5;
    }

    public void computeAndRegisterScore(String saveName)
    {
        if (conditionToRegister()) {
            Debug.Log("Saving highscore....");
            HighscoreManager.Instance.SaveHighscore(
                    saveName, 
                    ScoreManager.Instance.getScore());
        }
    }

    public void computeAndRegisterScore()
    {
        if (conditionToRegister()) {
            Debug.Log("Saving highscore....");
            HighscoreManager.Instance.SaveHighscore(
                    SaveManager.Instance.getCurrentSaveName(), 
                    ScoreManager.Instance.getScore());
        }
    }

    public List<(String, float)> getHighscores()
    {
        var scores = dataService.LoadData<List<(String, float)>>(fileName);
        scores.Sort((a, b) => a.Item2.CompareTo(b.Item2));
        return scores;
    }
}