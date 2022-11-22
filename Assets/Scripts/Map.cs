using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
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
