using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void DoAction()
    {
        SaveManager sm = SaveManager.Instance;
        sm.setCurrentSave(sm.getNextNewSave());
        sm.updateCurrentSave(SaveManager.defaultStartSave());

        Debug.Log("All saves: ");
        foreach ((String savename, int level, float score) in SaveManager.getAllSaves()) {
            Debug.Log(savename + " " + level + " - " + score);
        }

        SceneManager.LoadScene("Factory_1");
        ScoreManager.Instance.setOffset(Time.unscaledTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Buton start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
