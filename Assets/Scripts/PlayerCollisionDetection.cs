using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.tag=="Spike")
    {
        //scazut viata
        Debug.Log("Au");
    }
   }
}
