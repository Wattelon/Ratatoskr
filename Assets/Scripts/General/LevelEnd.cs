using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject endingScreen;
    [SerializeField] private List<Sprite> performanceTriskelions;
    [SerializeField] private Image performanceVisualizer;
    [SerializeField] private List<string> performancePhrases;
    [SerializeField] private TextMeshProUGUI endingTitle;
    [SerializeField] private TextMeshProUGUI earned;
    [SerializeField] private TextMeshProUGUI expenses;
    [SerializeField] private TextMeshProUGUI revenue;
    [SerializeField] private Gold goldCounter;

    private int _maxGain;
    
    public void AddMaxGain(int price)
    {
        _maxGain += price * 2;
    }
    
    public void EndLevel()
    {
        endingScreen.SetActive(true);
        earned.text += goldCounter.EarnedGold;
        expenses.text += goldCounter.Expenses;
        revenue.text += goldCounter.Revenue;
        int actualGain = goldCounter.EarnedGold;
        float rating = (float)actualGain / _maxGain;
        AssessPerformance(rating);
    }

    private void AssessPerformance(float rating)
    {
        int stars;
        if (rating < 0.5)
        {
            stars = 0;
        }
        else if (rating < 0.7)
        {
            stars = 1;
        }
        else if (rating < 0.9)
        {
            stars = 2;
        }
        else
        {
            stars = 3;
        }

        if (stars > 0 && LevelTracker.LevelID == LevelTracker.LevelsPassed)
        {
            PlayerPrefs.SetInt("levelsPassed", LevelTracker.LevelID + 1);
        }

        string levelKey = LevelTracker.LevelID.ToString();
        
        if (PlayerPrefs.HasKey(levelKey) && stars > PlayerPrefs.GetInt(levelKey) || !PlayerPrefs.HasKey(levelKey))
        {
            PlayerPrefs.SetInt(LevelTracker.LevelID.ToString(), stars);
        }

        performanceVisualizer.sprite = performanceTriskelions[stars];
        endingTitle.text = performancePhrases[stars];
    }
}
