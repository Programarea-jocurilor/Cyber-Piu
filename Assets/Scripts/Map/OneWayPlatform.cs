using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKey("s"))
        {

            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Invoke("ResetCollision", 0.3f);
        }
    }

    void ResetCollision()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
    }
}
