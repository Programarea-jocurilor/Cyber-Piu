using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRender : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI textUI;

    // Start is called before the first frame update
    void Start()
    {
        textUI.text = "Score: " + ScoreManager.Instance.getStringScore();
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = "Score: " + ScoreManager.Instance.getStringScore();
    }
}
