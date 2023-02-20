using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    [SerializeField] private FoodSO food;

    public FoodType FoodType { get; private set; }
    public int Price { get; private set; }
    public HeatTreating FoodHeatTreating { get; private set; } = HeatTreating.Raw;
    public bool HeatTreatable { get; private set; }
    public CutTreating FoodCutTreating { get; private set; } = CutTreating.Intact;
    public bool Cutable { get; private set;  }

    private Image _image;
    private CanvasGroup _canvasGroup;
    private Color _initialColor;
    private float _maxCookingTime;
    private float _cookingTime;
    private float _neededCuts;
    private float _currentCuts;

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
            FoodHeatTreating = dishMaking.FoodHeatTreating;
            _image.color = Color.Lerp(_image.color, Color.black, (float)FoodHeatTreating / 4);
        }
        else if (transform.parent.TryGetComponent(out FoodSpawner foodSpawner))
        {
            food = foodSpawner.FoodTypeToSpawn;
            _initialColor = _image.color;
        }
        FoodType = food.FoodType;
        Price = food.Price;
        _maxCookingTime = food.MaxCookingTime;
        _neededCuts = food.NeededCuts;
        _image.sprite = food.Icon;
        HeatTreatable = food.HeatTreatable;
        Cutable = food.Cutable;
    }

    private void Update()
    {
        if (HeatTreatable && transform.parent.TryGetComponent(out Cooker _) && _canvasGroup.blocksRaycasts)
        {
            _cookingTime += Time.deltaTime;
            if (_cookingTime >= _maxCookingTime * 0.2f && _cookingTime < _maxCookingTime * 0.4f)
            {
                FoodHeatTreating = HeatTreating.Cooked;
            }
            else if (_cookingTime >= _maxCookingTime * 0.4f && _cookingTime < _maxCookingTime * 0.6f)
            {
                FoodHeatTreating = HeatTreating.Perfect;
            }
            else if(_cookingTime >= _maxCookingTime * 0.6f && _cookingTime <= _maxCookingTime)
            {
                FoodHeatTreating = HeatTreating.Cooked;
            }
            else if(_cookingTime > _maxCookingTime)
            {
                FoodHeatTreating = HeatTreating.Burned;
            }
            _image.color = Color.Lerp(_initialColor, Color.black, 0.5f * _cookingTime / _maxCookingTime);
        }
    }

    public void Cut(int cuts)
    {
        _currentCuts += cuts;
        if (_currentCuts > _neededCuts)
        {
            FoodCutTreating = CutTreating.Cut;
            _image.sprite = food.IconCut;
        }
    }
}