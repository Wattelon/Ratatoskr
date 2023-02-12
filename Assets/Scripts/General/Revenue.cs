using TMPro;
using UnityEngine;

public class Revenue : MonoBehaviour
{
    private int _storedGold;
    private int _earnedGold;

    public void EarnGold(int revenue)
    {
        _earnedGold += revenue;
        GetComponent<TextMeshProUGUI>().text = _earnedGold.ToString();
    }
    
    private void OnDestroy()
    {
        _storedGold = PlayerPrefs.GetInt("gold", 0);
        PlayerPrefs.SetInt("gold", _storedGold + _earnedGold);
    }
}
