using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator;
    
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
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
    
    private IEnumerator FadeOut(string scene)
    {
        fadeAnimator.SetBool("isExitingScene", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
