using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Text = TMPro.TextMeshProUGUI;

public class DisplaySave : MonoBehaviour
{
    [SerializeField]
    private Text saveName;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Running DispalySave Script");
        
        saveName.text = "Save: " + SaveManager.Instance.getCurrentSaveName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
