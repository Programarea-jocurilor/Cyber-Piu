using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

using Text = TMPro.TextMeshProUGUI;

public class MenuState : MonoBehaviour
{
    [SerializeField]
    private Text saveNameText;

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
    private GameObject ResumeBtn, MenuBtn;
    private PlayerInput playerInput;

    public bool IsRunning()
    {
        return is_running;
    }

    public void PauseGame()
    {
        if (!is_running)
            return ;

        is_running = false;

        disablePlayerActions();
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        ResumeBtn.SetActive(true);
        MenuBtn.SetActive(true);
        saveNameText.enabled = true;
    }

    public void ResumeGame()
    {
        if (is_running)
            return ;

        Time.timeScale = previousTimeScale;
        
        is_running = true;
        
        enablePlayerActions();

        ResumeBtn.SetActive(false);  
        MenuBtn.SetActive(false);  
        saveNameText.enabled = false;
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

        is_running = true;
        Time.timeScale = 1f;

        ResumeBtn = GameObject.Find("ResumeButton");
        ResumeBtn.SetActive(false);

        MenuBtn = GameObject.Find("BackMenuButton");
        MenuBtn.SetActive(false);

        playerInput = GameObject.FindWithTag("Player")
                      .GetComponents(typeof(PlayerInput))[0] as PlayerInput;

        previousTimeScale = Time.timeScale;

        SaveManager.Instance.updateCurrentSave((
            SceneManager.GetActiveScene().buildIndex, 
            ScoreManager.Instance.getScore()
        ));

        saveNameText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            // pause or unpause
            if (is_running) 
                PauseGame();
            else
                ResumeGame();
        }

        if (!is_running) {
            ScoreManager.Instance.increaseOffset(Time.unscaledDeltaTime);
        }
    }
}
