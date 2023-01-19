using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Text = TMPro.TextMeshProUGUI;

public class NewGameButton : MonoBehaviour
{
    [SerializeField]
    private Text manySavesText;

    private const float NO_SAVES_DURATION = 2.5f;
    private float whenToDissapear = -1;

    public void DoAction()
    {
        SaveManager sm = SaveManager.Instance;

        if (SaveManager.getAllSaves().Count >= SaveManager.MAX_SAVES) {
            manySavesText.enabled = true;
            whenToDissapear = Time.unscaledTime + NO_SAVES_DURATION;
            return ;
        }

        sm.setCurrentSave(sm.getNextNewSave());
        sm.updateCurrentSave(SaveManager.defaultStartSave());

        SceneManager.LoadScene("Factory_1");
        ScoreManager.Instance.setOffset(Time.unscaledTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Buton start");
        manySavesText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime >= whenToDissapear)
            manySavesText.enabled = false;
    }
}
