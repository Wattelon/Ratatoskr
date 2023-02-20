using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    private RectTransform _rectTransform;
    private Vector3 _startingPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startingPosition = transform.position;
    }

    private void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransform.position = _startingPosition;
    }
}
