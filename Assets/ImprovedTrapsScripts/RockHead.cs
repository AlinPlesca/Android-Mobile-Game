using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : PlayerHealth
{
    private Vector3 destination;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private float checkTimer;

    private bool Isattacking;

    private Vector3[] direction = new Vector3[4];

    private void OnEnable()
    {
        Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isattacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else 
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirections();

        for (int i = 0; i < direction.Length; i++)
        {
            Debug.DrawRay(transform.position, direction[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction[i], range, playerLayer);

            if (hit.collider != null && !Isattacking)
            {
                Isattacking = true;
                destination = direction[i];
                checkTimer = 0;
            }
        }
    }

    private void Stop()
    {
        destination = transform.position;
        Isattacking = false;
    }

    private void CalculateDirections()
    {
        direction[0] = transform.right * range;
        direction[1] = -transform.right * range;

        direction[2] = transform.up * range;
        direction[3] = -transform.up * range;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stop();
    }
}
