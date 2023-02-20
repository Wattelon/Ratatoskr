using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private int cutPower;
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        if (col.TryGetComponent(out Food food) && col.transform.parent.TryGetComponent(out CuttingBoard _))
        {
            food.Cut(cutPower);
        }
    }
}
