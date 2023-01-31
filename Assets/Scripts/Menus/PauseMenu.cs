using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
