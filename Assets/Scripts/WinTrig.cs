using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrig : MonoBehaviour
{
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private GameObject winCup;
    [SerializeField] private AudioSource WinSound;
    public PlayerMovement PM;
    public ParticleSystem PS;
    public float delay = 0.1f;
    [SerializeField] private GameObject healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            SR.forceRenderingOff = true;
            winCup.SetActive(true);
            StartCoroutine(WinDelay());
        }
        IEnumerator WinDelay()
        {
            PS.Play();
            WinSound.Play();
            yield return new WaitForSeconds(delay);
           
            PM.gameObject.SetActive(false);
            healthBar.SetActive(false);
        }
    }
}
