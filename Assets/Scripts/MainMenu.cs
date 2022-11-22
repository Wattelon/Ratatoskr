using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldCounter;

    private void Start()
    {
        goldCounter.text = PlayerPrefs.GetInt("gold", 0).ToString();
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Map");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

}
