using UnityEngine;
using UnityEngine.UI;

public class LevelTracker : MonoBehaviour
{
    [SerializeField] private Sprite activeButton;
    
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
                button.GetComponent<Image>().sprite = activeButton;
                button.GetComponent<Button>().enabled = true;
            }
        }
    }

    public void SetLevelID(int id)
    {
        LevelID = id;
    }
}
