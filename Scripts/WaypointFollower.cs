using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private Animator anim;

    [SerializeField] private float speed = 10f;

    private void Start(){
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                anim.SetBool("stop", true);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
