using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonAndStars : MonoBehaviour
{
    public GameObject Moon;
    public GameObject Stars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moon.transform.position = new Vector2(transform.position.x +8f, Moon.transform.position.y);
        Stars.transform.position = new Vector2(transform.position.x, Stars.transform.position.y);
    }
}
