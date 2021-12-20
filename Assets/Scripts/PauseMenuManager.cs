using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isMuted;

    [SerializeField] public GameObject HealthBar;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        HealthBar.SetActive(false);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        HealthBar.SetActive(true);
    }
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MuteMusic()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
