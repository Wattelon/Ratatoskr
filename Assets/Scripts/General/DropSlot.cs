using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && transform.childCount < 3)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
        }
    }
}
