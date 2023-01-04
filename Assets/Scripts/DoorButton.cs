using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private DoorActivate door;
    private float timer=0;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorActivate>();
    }

    private void Update(){
        if(timer>0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                door.CloseDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Box")
        {
            //player enterd collider
            
            door.OpenDoor();
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Box")
        {
            //player still on top of collider
            timer =1f;
        }
    }

}
