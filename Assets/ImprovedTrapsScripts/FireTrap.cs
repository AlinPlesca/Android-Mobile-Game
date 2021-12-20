using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private float delay;
    private Animator anim;
    private SpriteRenderer SR;
    public PlayerHealth PH;

    private bool triggered;
    private bool active;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        SR = GetComponent<SpriteRenderer>();
        PH = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }

            if (active == true)
            {

            }
        }
    }

    private IEnumerator  ActivateFireTrap()
    {
        triggered = true;
      
        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        anim.SetBool("activated", false);
        yield return new WaitForSeconds(delay);
        triggered = false;
    }
}
