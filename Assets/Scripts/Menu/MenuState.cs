using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuState : MonoBehaviour
{
    private static MenuState _instance;

    public static MenuState Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }


    private bool is_running = true;
    private float previousTimeScale;
    private GameObject ResumeBtn;
    private PlayerInput playerInput;

    public bool IsRunning()
    {
        return is_running;
    }

    public void PauseGame()
    {
        if (!is_running)
            return ;
        Debug.Log("Doing Pause...");

        is_running = false;

        disablePlayerActions();
        previousTimeScale = Time.timeScale;
        Debug.Log("Saved timescale: " + previousTimeScale);
        Time.timeScale = 0f;

        ResumeBtn.SetActive(true);
    }

    public void ResumeGame()
    {
        if (is_running)
            return ;
        Debug.Log("Doing Resume...");

        Time.timeScale = previousTimeScale;
        Debug.Log("New timescale: " + Time.timeScale);
        
        is_running = true;
        
        enablePlayerActions();

        ResumeBtn.SetActive(false);    
    }

    void disablePlayerActions()
    {
        playerInput.enabled = false;
    }

    void enablePlayerActions()
    {
        playerInput.enabled = true;
    }

    private void SaveGame()
    {
        // TODO: Get current time and save in playerpref
        Debug.Log("Do save game");
    }


    // -- Unity
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started MenuState");

        ResumeBtn = GameObject.Find("ResumeButton");
        ResumeBtn.SetActive(false);

        playerInput = GameObject.FindWithTag("Player")
                      .GetComponents(typeof(PlayerInput))[0] as PlayerInput;
        Debug.Log("Player input: " + playerInput.GetType().ToString());

        previousTimeScale = Time.timeScale;

        Debug.Log(ResumeBtn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape key pressed");

            // pause or unpause
            if (is_running) 
                PauseGame();
            else
                ResumeGame();
        }
    }
}
