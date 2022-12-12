using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCondition : MonoBehaviour
{
    public Transform playerTransform;
 
    public GameObject enemy;
    // Update is called once per frame
    void Update()
    {
       if(Vector2.Distance(playerTransform.position,this.transform.position)<=20)
       {
        if(!enemy.activeInHierarchy)
            enemy.SetActive(true);
       }
       else
       {
        if(enemy.activeInHierarchy)
            enemy.SetActive(false);
       }
    }
}
