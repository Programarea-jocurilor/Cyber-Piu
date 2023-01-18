using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadHunterDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool move;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if(move)
        {
            rb.velocity = new Vector2(1, 0);
        }
    }

    private void StartMove()
    {
        move = true;
    }
    private void StopMove()
    {
        move = false;
    }

    private void FinishAnimation()
    {
        HighscoreManager.Instance.computeAndRegisterScore();
        Invoke("CompleteLevel", 3.0f);
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
