using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject foodType;
    private void Update()
    {
        if (transform.childCount == 0)
        {
            Instantiate(foodType, transform);
        }
    }
}
