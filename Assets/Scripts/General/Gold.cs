using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private int _storedGold;
    public int EarnedGold { get; private set; }
    public int Expenses { get; private set; }
    public int Revenue { get; private set; }

    public void EarnGold(int revenue)
    {
        EarnedGold += revenue;
        GetComponent<TextMeshProUGUI>().text = EarnedGold.ToString();
        Revenue = EarnedGold - Expenses;
        if (Revenue < 0)
        {
            Revenue = 0;
        }
    }

    public void IncreaseExpenses(int cost)
    {
        Expenses += cost / 2;
        Revenue = EarnedGold - Expenses;
        if (Revenue < 0)
        {
            Revenue = 0;
        }
    }
    
    private void OnDestroy()
    {
        _storedGold = PlayerPrefs.GetInt("gold", 0);
        PlayerPrefs.SetInt("gold", _storedGold + Revenue);
    }
}
