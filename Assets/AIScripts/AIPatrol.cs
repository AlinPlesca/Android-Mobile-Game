using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    [SerializeField] private float speed = 2f;
    [SerializeField] private SpriteRenderer SR;

    private int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //followWayPoints();
    }

    public void followWayPoints()
    {
        if (Vector2.Distance(waypoints[wayPointIndex].transform.position, transform.position) < 0.1f)
        {
            wayPointIndex++;
            if (wayPointIndex >= waypoints.Length)
            {
                wayPointIndex = 0;
            }
            if (wayPointIndex == 1)
            {
                SR.flipX = true;
            }
            else
            {
                SR.flipX = false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[wayPointIndex].transform.position, Time.deltaTime * speed);
    }
}

