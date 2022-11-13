using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static int _gold;
    private static int _revenue;
    private static int _levelCode;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            FindObjectOfType<TextMeshProUGUI>().text = "Золото: " + _gold;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map"))
        {

        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {

        }
    }
}
