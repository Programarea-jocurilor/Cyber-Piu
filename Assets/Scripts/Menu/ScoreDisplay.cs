using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject Score1;
    public GameObject Score2;
    public GameObject Score3;

    private scoreModel[] scores=null;
   
    void Start()
    {
       
        var filepath = Path.Combine(Application.persistentDataPath, @"score.json");
        var fileName = Path.GetFullPath(filepath);
        if (File.Exists(fileName))
        {
            string data = File.ReadAllText(fileName);
            scores = JsonConvert.DeserializeObject<scoreModel[]>(data);
        }

        //imi sorteaza descrescator lista
        Array.Sort<scoreModel>(scores, new Comparison<scoreModel>(
                                (i1, i2) => i2.score.CompareTo(i1.score)));
        //imi ia doar primele 3 elemente din lista
        checkScoresNumber();
    }
    private void checkScoresNumber() {
        var length = scores.Length;
        if(scores.Length>3)
            length= 3;
        switch (length) {
            case 1:
                populateScores(Score1, length - 3);
                Score1.SetActive(true);
                break;
            case 2:
                populateScores(Score1, length - 3);
                Score1.SetActive(true);
                populateScores(Score2, length - 2);
                Score2.SetActive(true);
                break;
            case 3:
                populateScores(Score1, length - 3);
                Score1.SetActive(true);
                populateScores(Score2, length - 2);
                Score2.SetActive(true);
                populateScores(Score3, length - 1);
                Score3.SetActive(true);
                break;
            default:
                Score1.SetActive(false);
                Score2.SetActive(false);
                Score3.SetActive(false);
                break;
        }
    }
    private void populateScores(GameObject score, int count) {
        score.transform.GetComponentsInChildren<TMP_Text>()[0].text = scores[count].name;
        score.transform.GetComponentsInChildren<TMP_Text>()[1].text = scores[count].score.ToString();
    }

 
}