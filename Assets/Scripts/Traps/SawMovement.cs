using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float seconds;
    // private Animator anim;
    private bool startMovement=false;

    void Start()
    {
        // anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(WaitAndMoveSaw());
        if (startMovement == true)
            MoveSaw();
    }

    private void MoveSaw()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            // anim.SetBool("backwards", false);
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                // anim.SetBool("backwards", true);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    private IEnumerator WaitAndMoveSaw()
    {
        yield return new WaitForSeconds(seconds);
        startMovement = true;
    }
}