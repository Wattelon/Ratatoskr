using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ServingBoard : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject dishTemplate;
    
    private bool _isLidOnBoard;

    private void FixedUpdate()
    {
        if (_isLidOnBoard && !GetComponentInChildren(typeof(ServingLid)))
        {
            _isLidOnBoard = false;
            gameObject.GetComponent<HorizontalLayoutGroup>().enabled = true;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out Food food) && transform.childCount < 3 && !_isLidOnBoard)
        {
            food.transform.SetParent(transform);
        }
        if (eventData.pointerDrag.TryGetComponent(out ServingLid servingLid))
        {
            gameObject.GetComponent<HorizontalLayoutGroup>().enabled = false;
            if (!_isLidOnBoard && transform.GetComponentsInChildren<Food>().Length > 1)
            {
                GameObject dish = Instantiate(dishTemplate, transform);
            }
            servingLid.transform.SetParent(transform);
            _isLidOnBoard = true;
        }
    }
}
