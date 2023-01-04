using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivate : MonoBehaviour
{
    public bool isDoorOpen = false;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    [SerializeField] float doorStep = 500;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(this.transform.position.x, 
            transform.position.y + 6, transform.position.z);
    }

    public void OpenDoor()
    {
        
        if( transform.position != doorOpenPos)
        {
            anim.SetTrigger("LaserOff");
        }
    }

    public void CloseDoor()
    {
        if( transform.position != doorClosedPos)
        {
            anim.SetTrigger("LaserOn");
        }
    }
}
