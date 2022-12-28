using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody2D player;
    public Health playerHealth;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            playerHealth.TakeDamage(1);
        }
        else if(collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
