using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    public void DoAction()
    {
        MenuState state = MenuState.Instance;
        GameObject btn = GameObject.FindWithTag("PauseResume");

        Debug.Log(state);

        Debug.Log("Resuming...");
        state.ResumeGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
