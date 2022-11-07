using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInstance : MonoBehaviour
{
    public static int LevelNumber;
    public static int Gold;
    public static int Revenue;
    public static bool IsGoldUpdateNeeded;

    public void Update()
    {
        if (IsGoldUpdateNeeded)
        {
            Gold += Revenue;
            IsGoldUpdateNeeded = false;
        }
    }
}
