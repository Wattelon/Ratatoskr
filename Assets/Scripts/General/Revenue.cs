using TMPro;
using UnityEngine;

public class Revenue : MonoBehaviour
{
    private int _storedGold;
    private int _earnedGold;

    private void OnDestroy()
    {
        _storedGold = PlayerPrefs.GetInt("gold", 0);
        _earnedGold = int.Parse(gameObject.GetComponent<TextMeshProUGUI>().text);
        PlayerPrefs.SetInt("gold", _storedGold + _earnedGold);
    }
}
