using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBeach : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * 3, transform.position.z);
    }
}
