using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ScrollSaves : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    [SerializeField]
    private GameObject buttonPrefab;

    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("Content");

        int index = 0;
        foreach((String saveName, int level, float score) in SaveManager.getAllSaves()) {
            Debug.Log("Working on save: " + saveName + " | " + level + " | " + score);

            var t = container.transform;
            var t2 = Vector3.up * index * 10f + t.position;

            GameObject item_go = Instantiate(buttonPrefab, t2, Quaternion.identity);

            foreach (TMPro.TextMeshProUGUI comp in item_go.GetComponentsInChildren<TMPro.TextMeshProUGUI>()) {
                Debug.Log("Child name: " + comp.GetType().ToString() + " | " + comp.name);
            }

            // do something with the instantiated item -- for instance
            item_go.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0].text = "Save: " + saveName;
            item_go.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[1].text = "Level: " + level + "  Score: " + score;
            item_go.transform.SetParent(container.transform);
            item_go.transform.localScale = Vector2.one;

            index += 1;

            // (scrollView as ScrollView).Add(item_go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
