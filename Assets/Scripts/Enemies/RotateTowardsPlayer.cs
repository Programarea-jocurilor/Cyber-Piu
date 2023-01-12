using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    public GameObject player;

    // public float speed;

    // public float rotationModifier;

    private bool rotate = true;

    void FixedUpdate()
    {
        // if(player!=null&&this.transform.position.y-player.transform.position.y<=1.2f)
        // {
        //   Vector3 vectorToTarget=player.transform.position-transform.position;
        // float angle=Mathf.Atan2(vectorToTarget.y,vectorToTarget.x)*Mathf.Rad2Deg-rotationModifier;
        // Quaternion q=Quaternion.AngleAxis(angle,Vector3.up);
        // transform.rotation=Quaternion.Slerp(transform.rotation,q,Time.deltaTime*speed);
        // }

        //enemies care trag sunt pozitionati catre dreapta, daca playerul e in stanga/spatele lor, ii rotesc
        //rotate imi asigura ca obiectul se roteste o singura data
        if(player!= null && player.transform.position.x <= transform.position.x && rotate == true) 
        {
          transform.Rotate(new Vector3(0,180,0));
          rotate = false;
        }

        // cand enemies sunt rotiti catre stanga, iar playerul merge in drapta lor, acestia revin la pozitia initiala
        if(player!= null && player.transform.position.x > transform.position.x && rotate == false)
        {
          transform.Rotate(new Vector3(0,180,0));
          rotate = true;
        }

    }

}
