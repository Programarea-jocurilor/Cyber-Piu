using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
//    private bool levelCompleted = false;
    private GameObject enemy1;
    private GameObject enemy2;
    private SpriteRenderer SR;
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
    }

    private void Update()
    {
        enemy1 = GameObject.Find("Enemy1");
        enemy2 = GameObject.Find("Enemy2");
        if(!enemy1 && !enemy2)
        {
            SR.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !enemy1 && !enemy2)
        {
            Invoke("CompleteLevel", 0.5f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
