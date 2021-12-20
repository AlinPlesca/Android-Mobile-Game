using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePosition;
    public GameObject orangeProjectile;
    // Start is called before the first frame update

    public float shootingCooldown;
    float lastShot;
    public AudioSource shotSound;

    public buttonCooldown BC;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            BC.castOrange();
            shotSound.Play();
        }
    }

    public void Shoot()
    {
        if (Time.time - lastShot < shootingCooldown)
        {
            return;
        }

        lastShot = Time.time;
        Instantiate(orangeProjectile, firePosition.position, firePosition.rotation);
    }
}
