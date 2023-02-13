using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldCounter;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Animator fadeOut;
    [SerializeField] private Animator fadeIn;

    private void Start()
    {
        goldCounter.text = PlayerPrefs.GetInt("gold", 0).ToString();
        fadeIn.enabled = true;
    }

    public void OnPlayClick()
    {
        StartCoroutine(FadeOut("Map"));
    }

    public void OnSettingsClick()
    {
        gameObject.SetActive(false);
        settingsMenu.SetActive(true);
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
