using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void DoAction()
    {
        SceneManager.LoadScene("Factory_1");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Buton start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
