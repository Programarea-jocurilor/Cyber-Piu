using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTimeSet;
    private float waitTime;


    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        waitTime = waitTimeSet;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = waitTimeSet;
        }
        
        if(Input.GetKey("s"))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = waitTimeSet;
                Invoke("ResetRotation", 0.3f);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
        
        if(Input.GetButtonDown("Jump") && Input.GetAxisRaw("Vertical") > 0) 
        {
            effector.rotationalOffset = 0;
        }
    }

    void ResetRotation()
    {
        effector.rotationalOffset = 0;
    }
}
