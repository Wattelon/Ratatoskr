using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Revenue : MonoBehaviour
{
    private int _playerGold;
    private int _revenue;

    private void OnDestroy()
    {
        _playerGold = PlayerPrefs.GetInt("gold", 0);
        _revenue = int.Parse(gameObject.GetComponent<TextMeshProUGUI>().text);
        PlayerPrefs.SetInt("gold", _playerGold + _revenue);
    }
}
