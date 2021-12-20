using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int rhinoHealth = 100;
    public int currentHealth;

    public GameObject damge80;
    public GameObject damge60;
    public GameObject damge40;
    public GameObject damge20;

    public GameObject rhino;
    public ParticleSystem rhinoPR;
    float delay = 1.9f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            rhinoHealth -= 20;

            if(rhinoHealth == 80)
            {
                StartCoroutine(delayDamageEffect80());
            }
            else if (rhinoHealth == 60)
            {
                StartCoroutine(delayDamageEffect60());
            }

            else if (rhinoHealth == 40)
            {
                StartCoroutine(delayDamageEffect40());
            }
            else if (rhinoHealth == 20)
            {
                StartCoroutine(delayDamageEffect20());
            }

            else if (rhinoHealth == 0)
            {
                rhinoPR.Play();
                Destroy(this.gameObject);
                Destroy(damge20);
            }
        }
    }

    IEnumerator delayDamageEffect80()
    {
        damge80.SetActive(true);
        yield return new WaitForSeconds(delay);
        damge80.SetActive(false);
    }

    IEnumerator delayDamageEffect60()
    {
        damge60.SetActive(true);
        yield return new WaitForSeconds(delay);
        damge60.SetActive(false);
    }

    IEnumerator delayDamageEffect40()
    {
        damge40.SetActive(true);
        yield return new WaitForSeconds(delay);
        damge40.SetActive(false);
    }

    IEnumerator delayDamageEffect20()
    {
        damge20.SetActive(true);
        yield return new WaitForSeconds(delay);
        damge20.SetActive(false);
    }
}
