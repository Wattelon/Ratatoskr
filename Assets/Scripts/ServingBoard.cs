using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ServingBoard : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject dish;
    private int n = 0;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out FoodCooking _food) && transform.childCount < 3)
        {
            _food.GetComponent<RectTransform>().parent = transform;
            _food.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        }
        if (eventData.pointerDrag.TryGetComponent(out ServingLid _servingLid))
        {
            gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
            //gameObject.tag = "None";
            _servingLid.GetComponent<RectTransform>().parent = transform;
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            GameObject _dish = Instantiate(dish, transform);
            for (int i = 0; i < transform.childCount - n; i++)
            {
                if (transform.GetChild(i).TryGetComponent( out FoodCooking _foodCooking))
                {
                    _foodCooking.transform.parent = _dish.transform;
                    _foodCooking.transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
                    i--;
                    n++;
                    if (_dish.transform.childCount == 1)
                    {
                        _dish.tag = _dish.transform.GetChild(0).tag;
                    }
                    else if (_dish.CompareTag("Perfect") && !_foodCooking.CompareTag(_dish.tag))
                    {
                        _dish.tag = _foodCooking.tag;
                    }

                    else if (_foodCooking.CompareTag("Raw") || _foodCooking.CompareTag("Burned"))
                    {
                        _dish.tag = _foodCooking.tag;
                    }
                }
            }
            _servingLid.transform.SetSiblingIndex(transform.childCount - 1);
        }
    }
}
