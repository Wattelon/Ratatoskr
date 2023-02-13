using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTracker : MonoBehaviour
{
    [SerializeField] private List<Sprite> starsSprites;
    
    public static int LevelsPassed { get; private set; }
    public static int LevelID { get; private set; }

    private void Start()
    {
        LevelsPassed = PlayerPrefs.GetInt("levelsPassed", 0);

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i <= LevelsPassed)
            {
                var button = transform.GetChild(i);
                button.GetComponent<Image>().sprite = starsSprites[PlayerPrefs.GetInt(i.ToString(), 0)];
                button.GetComponent<Button>().enabled = true;
            }
        }
    }

    public void SetLevelID(int id)
    {
        LevelID = id;
    }
}
