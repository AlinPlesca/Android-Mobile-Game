using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private AudioSource FinishEffect;
    public GameObject WinTrigger;
    public SpriteRenderer FL;
    public bool win;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FinishEffect.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); ;
    }

    //public void winGame()
    //{

    //    win = true;
    //    WinTrigger.SetActive(true);
    //    FL.forceRenderingOff = true;

    //}
}
