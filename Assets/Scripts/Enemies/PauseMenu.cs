using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    [SerializeField] private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() //ca sa o pot folosi si pentru Resume Button
    {   
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
        gameIsPaused=false;
    }

    public void Pause()
    {   
     pauseMenu.SetActive(true);
     Time.timeScale=0f;
     gameIsPaused=true;
    }

    public void LoadMenu()
    {
        Time.timeScale=1;//ca sa nu fie jocu still paused
        //SceneManager.LoadScene("")
        Debug.Log("loading...");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}