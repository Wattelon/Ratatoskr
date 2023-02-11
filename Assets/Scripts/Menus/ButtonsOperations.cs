using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOperations : MonoBehaviour
{
    public void OnLevelClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
