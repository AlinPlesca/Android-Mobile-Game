using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonCooldown : MonoBehaviour
{


    [SerializeField] private Image imgCooldown;
    private bool isCooldown = false;
    private float cooldownTime = 1f;
    private float cooldownTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        imgCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            imgCooldown.fillAmount = 0.0f;
        }
        else
        {
            imgCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public void castOrange()
    {
        if (isCooldown)
        {
            //soundeffect
        }

        else 
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }
}
