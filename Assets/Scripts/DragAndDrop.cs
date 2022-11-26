using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;
    private Color _color;
    private float _cookingTime;
    private bool _isCooking;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _color = GetComponent<Image>().color;
    }

    private void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _isCooking = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _rectTransform.position = transform.parent.position;
        if (transform.parent.CompareTag("Cooker"))
        {
            _isCooking = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    private void Update()
    {
        if (_isCooking)
        {
            _cookingTime += Time.deltaTime;
            GetComponent<Image>().color = Color.Lerp(_color, Color.black, _cookingTime / 10f);
        }
    }
}
