using TMPro;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldCounter;
    [SerializeField] private GameObject mainMenu;

    public void OnResetClick()
    {
        PlayerPrefs.DeleteAll();
        goldCounter.text = "0";
    }

    public void OnBackClick()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
