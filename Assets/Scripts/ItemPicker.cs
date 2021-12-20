using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPicker : MonoBehaviour
{
    private int Kiwi = 0;
    [SerializeField] private Text KiwiTxt;
    [SerializeField] private AudioSource CollectionSound;
    [SerializeField] private AudioSource PowerUp;

    [SerializeField] private GameObject DJtxt;
    [SerializeField] private GameObject WJtxt;
    [SerializeField] private GameObject Shootxt;
    [SerializeField] private GameObject shootBtn;
    [SerializeField] private Text gateunlockedtxt;

    public int globalInventory = 0;


    private float delay = 1.5f;
    public PlayerMovement PM;
    public WallJump WJ;

    public PlayerShoot PS;

    public void Start()
    {
        globalInventory = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("KiwiCollectible"))
        {
            CollectionSound.Play();

            Kiwi++;
            KiwiTxt.text = "KIWI: " + Kiwi;

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("PineApple"))
        {
            CollectionSound.Play();
            globalInventory++;
            Destroy(collision.gameObject);
            StartCoroutine(TextDelay2());
        }

        if (collision.gameObject.CompareTag("DoubleJump"))
        {
            PowerUp.Play();
            PM.extraJumps = PM.extraJumps + 1;
            Destroy(collision.gameObject);
            StartCoroutine(TextDelay());
        }

        if (collision.gameObject.CompareTag("Melon"))
        {
            PowerUp.Play();
            WJ.enabled = true;
            Destroy(collision.gameObject);
            StartCoroutine(WallJumpTxtDelay());
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            PowerUp.Play();
            PS.enabled = true;
            WJ.enabled = true;
            Destroy(collision.gameObject);
            StartCoroutine(ShootingTxtDelay());
        }
    }

    IEnumerator TextDelay()
    {
        DJtxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(DJtxt);
    }

    IEnumerator TextDelay2()
    {
        gateunlockedtxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(gateunlockedtxt);
    }

    IEnumerator WallJumpTxtDelay()
    {
        WJtxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(WJtxt);
    }

    IEnumerator ShootingTxtDelay()
    {
        Shootxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(Shootxt);
        shootBtn.SetActive(true);
    }
}