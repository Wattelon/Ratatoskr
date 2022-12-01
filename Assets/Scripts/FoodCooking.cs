using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCooking : MonoBehaviour
{
    private FoodPrepStatus _curFoodPrepStatus = FoodPrepStatus.raw;
    private Color _color;
    private float _cookingTime;

    enum FoodPrepStatus
    {
        raw,
        ready,
        perfect,
        burned
    }

    private void Awake()
    {
        _color = GetComponent<Image>().color;
    }

    void Update()
    {
        if (transform.parent.CompareTag("Cooker") && GetComponent<CanvasGroup>().blocksRaycasts)
        {
            _cookingTime += Time.deltaTime;
            if (_cookingTime is >= 3f and <= 5f)
            {
                _curFoodPrepStatus = FoodPrepStatus.ready;
                gameObject.tag = "Ready";
            }
            else if (_cookingTime is >= 5f and <= 6f)
            {
                _curFoodPrepStatus = FoodPrepStatus.perfect;
                gameObject.tag = "Perfect";
            }
            else if(_cookingTime <= 10f && _curFoodPrepStatus == FoodPrepStatus.perfect)
            {
                _curFoodPrepStatus = FoodPrepStatus.ready;
                gameObject.tag = "Ready";
            }
            else if(_cookingTime > 10f)
            {
                _curFoodPrepStatus = FoodPrepStatus.burned;
                gameObject.tag = "Burned";
            }
            GetComponent<Image>().color = Color.Lerp(_color, Color.black, _cookingTime / 10f);
        }
    }
}
