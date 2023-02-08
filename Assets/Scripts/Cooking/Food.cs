using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    [SerializeField] private FoodSO food;

    public FoodType FoodType { get; private set; }
    public int Price { get; private set; }
    public Processing FoodProcessing { get; private set; } = Processing.Raw;
    public bool HeatTreatable { get; private set; }

    private Image _image;
    private CanvasGroup _canvasGroup;
    private Color _initialColor;
    private float _maxCookingTime;
    private float _cookingTime;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (gameObject.TryGetComponent(out DishMaking dishMaking))
        {
            food = dishMaking.DishType;
            FoodProcessing = dishMaking.FoodProcessing;
            _image.color = Color.Lerp(_image.color, Color.black, (float)FoodProcessing / 4);
        }
        else if (transform.parent.TryGetComponent(out FoodSpawner foodSpawner))
        {
            food = foodSpawner.FoodTypeToSpawn;
            _initialColor = _image.color;
        }
        FoodType = food.FoodType;
        Price = food.Price;
        _maxCookingTime = food.MaxCookingTime;
        _image.sprite = food.Icon;
        HeatTreatable = food.HeatTreatable;
    }

    private void Update()
    {
        if (HeatTreatable && transform.parent.TryGetComponent(out Cooker _) && _canvasGroup.blocksRaycasts)
        {
            _cookingTime += Time.deltaTime;
            if (_cookingTime >= _maxCookingTime * 0.2f && _cookingTime < _maxCookingTime * 0.4f)
            {
                FoodProcessing = Processing.Cooked;
            }
            else if (_cookingTime >= _maxCookingTime * 0.4f && _cookingTime < _maxCookingTime * 0.6f)
            {
                FoodProcessing = Processing.Perfect;
            }
            else if(_cookingTime >= _maxCookingTime * 0.6f && _cookingTime <= _maxCookingTime)
            {
                FoodProcessing = Processing.Cooked;
            }
            else if(_cookingTime > _maxCookingTime)
            {
                FoodProcessing = Processing.Burned;
            }
            _image.color = Color.Lerp(_initialColor, Color.black, 0.5f * _cookingTime / _maxCookingTime);
        }
    }
}