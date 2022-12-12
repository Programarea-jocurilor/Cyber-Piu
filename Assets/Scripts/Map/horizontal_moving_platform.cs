using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontal_moving_platform : MonoBehaviour
{
    public float horizontal_distance;
    public float vertical_distance;
    public float speed;
    private Vector3 original_position;
    // Start is called before the first frame update
    void Start()
    {
        original_position = transform.position;
        Debug.Log(original_position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (original_position.x * Mathf.Sin(Time.fixedTime*speed) * horizontal_distance, original_position.y, original_position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
