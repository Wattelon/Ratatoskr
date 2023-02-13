using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsOperations : MonoBehaviour
{
    [SerializeField] private Animator fadeOut;
    [SerializeField] private Animator fadeIn;

    private void Start()
    {
        fadeIn.enabled = true;
    }

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
        fadeOut.enabled = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
