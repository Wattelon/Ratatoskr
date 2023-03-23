using UnityEngine;
using UnityEngine.UI;

public class FoodInList : MonoBehaviour
{
    [HideInInspector] public FoodSO food;
    private FoodInfo _info;
    private void Start()
    {
        GetComponent<Image>().sprite = food.Icon;
        _info = FindObjectOfType<FoodInfo>();
    }

    public void OnClick()
    {
        _info.DisplayInfo(food);
    }
}
