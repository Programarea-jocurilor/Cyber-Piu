using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Button = UnityEngine.UI.Button;
using TMText = TMPro.TextMeshProUGUI;

public class ScrollScores : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    [SerializeField]
    private GameObject buttonPrefab;

    private static Color colTop    = Color.red;
    private static Color colPodium = Color.blue;
    private static Color colRest   = new Color(0.0f, 0.45f, 0.14f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("Content");

        int index = 0;

        var allScores = HighscoreManager.Instance.getHighscores();

        foreach((String saveName, float score) in allScores) {
            var t = container.transform;
            var t2 = Vector3.up * index * 10f + t.position;

            GameObject item_go = Instantiate(buttonPrefab, t2, Quaternion.identity);
            
            // do something with the instantiated item -- for instance
            
            TMText scoreText = item_go.GetComponentsInChildren<TMText>()[0];
            scoreText.text = "<b><i>" + score + " </i></b>";
            scoreText.color = index == 0 ? colTop : (index < 3 ? colPodium : colRest);

            item_go.GetComponentsInChildren<TMText>()[1].text = "  Name: " + saveName;

            item_go.transform.SetParent(container.transform);
            item_go.transform.localScale = Vector2.one;

            index += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
