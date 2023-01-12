using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

   }
   
  //  ***
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
    {    Debug.Log("Pauza");
     pauseMenu.SetActive(true);
     Time.timeScale=0f;
     gameIsPaused=true;
    }
 public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale=1;
        Debug.Log("Merge");
    }

// ****
   public void QuitGame()
   {
    Debug.Log("QUIT");
    Application.Quit();
   }
}
