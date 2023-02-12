using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOperations : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator;
    
    public void OnLevelClick()
    {
        StartCoroutine(FadeOut("Game"));
    }

    public void OnMenuClick()
    {
        StartCoroutine(FadeOut("Menu"));
    }
    
    private IEnumerator FadeOut(string scene)
    {
        fadeAnimator.SetBool("isExitingScene", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
