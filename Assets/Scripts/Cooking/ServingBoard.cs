using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ServingBoard : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject dishTemplate;
    
    private bool _isLidOnBoard;
    private bool _isDishOnBoard;

    private void FixedUpdate()
    {
        if (_isLidOnBoard && !GetComponentInChildren(typeof(ServingLid)))
        {
            _isLidOnBoard = false;
            gameObject.GetComponent<HorizontalLayoutGroup>().enabled = true;
        }
        if (_isDishOnBoard && !GetComponentInChildren(typeof(DishMaking)))
        {
            _isDishOnBoard = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out Food food) && transform.childCount < 3 && !_isLidOnBoard && !_isDishOnBoard)
        {
            food.transform.SetParent(transform);
        }
        if (eventData.pointerDrag.TryGetComponent(out ServingLid servingLid))
        {
            gameObject.GetComponent<HorizontalLayoutGroup>().enabled = false;
            if (!_isLidOnBoard && !_isDishOnBoard && transform.GetComponentsInChildren<Food>().Length > 1)
            {
                GameObject dish = Instantiate(dishTemplate, transform);
                _isDishOnBoard = true;
            }
            servingLid.transform.SetParent(transform);
            _isLidOnBoard = true;
        }
    }
}
