using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    public GameObject player;

    public float speed;

    public float rotationModifier;
    

    void FixedUpdate()
    {
        if(player!=null&&this.transform.position.y-player.transform.position.y<=1.2f)
        {
          Vector3 vectorToTarget=player.transform.position-transform.position;
        float angle=Mathf.Atan2(vectorToTarget.y,vectorToTarget.x)*Mathf.Rad2Deg-rotationModifier;
        Quaternion q=Quaternion.AngleAxis(angle,Vector3.up);
        transform.rotation=Quaternion.Slerp(transform.rotation,q,Time.deltaTime*speed);
        }
    }
}
