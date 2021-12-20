using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public GameObject Panel;
    public Animator transition;
    public float transitionTime = 1f;

    private bool isMuted;

    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    public void Settings()
    {
        Panel.GetComponent<Animator>().SetTrigger("Pop");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void MuteMusic()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait before loading
        yield return new WaitForSeconds(transitionTime);

        //Load new scene
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadLevel2()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void LoadLevel3()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void LoadLevel4()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void LoadLevel5()
    {
        StartCoroutine(LoadLevel(5));
    }

    public void ShareGame()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }
    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Jumper Land").SetText("Try Jumper Land! Is so fun!").SetUrl("https://play.google.com/store/apps/details?id=com.DefaultCompany.JumperLand").SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget)).Share();
    }
}