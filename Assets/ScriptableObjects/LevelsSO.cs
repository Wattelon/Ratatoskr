using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Scriptable Objects/Level", order = 51)]
public class LevelsSO : ScriptableObject
{
    [SerializeField] private List<Level> levels;

    public List<Level> Levels => levels;
}

[Serializable]
public struct Level
{
    public int LevelID;
    public List<CustomerSO> CustomersSO;
}