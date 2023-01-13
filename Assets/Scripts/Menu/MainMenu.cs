using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Application;

public class MainMenu : MonoBehaviour
{

    public TMP_Text score;

    public TMP_InputField portalField;
    public TMP_InputField deathField;

    public GameObject deathCanvas;
    public GameObject finishCanvas;



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
    
    private void SaveJson(string name)
    {

        var filepath = Path.Combine(Application.dataPath, @"Scripts/Menu/Score/score.json");
        var fileName = Path.GetFullPath(filepath);
        List<scoreModel> scoreList = null;
        if (File.Exists(fileName))
        {
            scoreList = JsonConvert.DeserializeObject<scoreModel[]>(File.ReadAllText(fileName)).ToList();
        }
        var currentScore = new scoreModel();
        currentScore.name = name;
        currentScore.score = float.Parse(score.text.Split(':')[1].Trim());
        if (scoreList != null)
        {
            scoreList.Add(currentScore);
        }
        else
        {
            scoreList = new List<scoreModel>();
            scoreList.Add(currentScore);
        }

        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.TypeNameHandling = TypeNameHandling.Auto;
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        File.WriteAllText(fileName, JsonConvert.SerializeObject(scoreList, Formatting.Indented, settings));
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
        if (finishCanvas.activeSelf)
        {
            if (portalField.text.Length > 8)
            {
                SaveJson(portalField.text.Substring(0, 8));
            }
            else
            {
                SaveJson(portalField.text);
            }
        }
        else if (deathCanvas.activeSelf)
        {
            if (deathField.text.Length > 8)
            {
                SaveJson(deathField.text.Substring(0, 8));
            }
            else
            {
                SaveJson(deathField.text);
            }
        }
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

public class scoreModel
{
    public string name { get; set; }
    public float score { get; set; }
}
