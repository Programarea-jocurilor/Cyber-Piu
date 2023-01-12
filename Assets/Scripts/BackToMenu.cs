using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("numesscena");
        Time.timeScale=1;
        Debug.Log("fasodao");
    }
}
