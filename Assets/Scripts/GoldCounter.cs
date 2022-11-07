using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    public int CurrentRevenue = 0;

    public void GainRevenue()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Revenue: " + CurrentRevenue;
    }
}
