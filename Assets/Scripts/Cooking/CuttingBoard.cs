using UnityEngine;
using UnityEngine.EventSystems;

public class CuttingBoard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.TryGetComponent(out Food food) && food.Cutable && transform.childCount < 1)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
