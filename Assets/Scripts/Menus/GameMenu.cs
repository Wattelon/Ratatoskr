using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Animator fadeOut;
    [SerializeField] private Animator fadeIn;

    private void Start()
    {
        fadeIn.enabled = true;
    }

    public void OnPauseClick()
    {
        Time.timeScale = 0f;
    }

    public void OnResumeClick()
    {
        Time.timeScale = 1f;
    }

    public void OnMenuClick()
    {
        StartCoroutine(FadeOut("Menu"));
        Time.timeScale = 1f;
    }

    public void OnMapClick()
    {
        StartCoroutine(FadeOut("Map"));
        Time.timeScale = 1f;
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
    
    private IEnumerator FadeOut(string scene)
    {
        fadeOut.enabled = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
