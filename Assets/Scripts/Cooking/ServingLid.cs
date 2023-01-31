using UnityEngine;
using UnityEngine.EventSystems;

public class ServingLid : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;
    private Vector3 _startPosition;
    private bool _isServing;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
        _startPosition = _rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        if (_isServing)
        {
            transform.SetParent(transform.parent.parent);
            _rectTransform.position = _startPosition;
            _isServing = false;
        }
        else if (transform.parent.TryGetComponent(out ServingBoard _))
        {
            _rectTransform.position = transform.parent.position;
            _isServing = true;
        }
        else
        {
            _rectTransform.position = _startPosition;
        }
    }
}
