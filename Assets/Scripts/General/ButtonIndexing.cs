using TMPro;
using UnityEngine;

public class ButtonIndexing : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }
}
