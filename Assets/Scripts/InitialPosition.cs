using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPosition : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject bosssFightPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(startPosition.transform.position.x, startPosition.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            transform.position = new Vector2(bosssFightPosition.transform.position.x, bosssFightPosition.transform.position.y);
    }
}
