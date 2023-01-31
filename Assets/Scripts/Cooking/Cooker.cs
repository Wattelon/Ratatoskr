using UnityEngine;
using UnityEngine.EventSystems;

public class Cooker : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Food>().HeatTreatable && transform.childCount < 3)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
