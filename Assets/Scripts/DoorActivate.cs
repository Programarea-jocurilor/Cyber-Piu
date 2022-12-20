using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivate : MonoBehaviour
{
    public bool isDoorOpen = false;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    [SerializeField] float doorStep = 100;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x, 
            transform.position.y + 3, transform.position.z);
    }

    public void OpenDoor()
    {
        
        if( transform.position != doorOpenPos)
        {
            // Debug.Log("open");
            // anim.SetTrigger("openDoor");
            
            Debug.Log(transform.position);
            Debug.Log(doorOpenPos);

            transform.position =  Vector3.MoveTowards( transform.position,
                doorOpenPos, doorStep * Time.deltaTime);

            // enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            // enemy.position.y, enemy.position.z);

            // transform.position = new Vector3(transform.position.x, 
            //     transform.position.y + Time.deltaTime * doorStep, transform.position.z);

            Debug.Log(transform.position);
        
        }
    }

    public void CloseDoor()
    {
        if( transform.position != doorClosedPos)
        {
            // anim.SetTrigger("closeDoor");
            transform.position = Vector3.MoveTowards( transform.position,
                doorClosedPos, doorStep * Time.deltaTime);

            // transform.position = new Vector3(transform.position.x, 
            //     transform.position.y + Time.deltaTime * doorStep * (-3), transform.position.z);
        }
    }
}
