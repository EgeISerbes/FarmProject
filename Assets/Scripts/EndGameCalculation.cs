using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EndGameCalculation : MonoBehaviour
{
    [SerializeField] private ZoneManager _zoneManager;
    [SerializeField] private MoneySO _soilValue;
    [SerializeField] private MoneySO _moneySO;
    [SerializeField] private ButtonClickEventListener<FarmObject> _onButtonClicked;
    [SerializeField] private GameEventListenerWP _onRestart;
    [SerializeField] private EndGameValues _endGameValues;
    [SerializeField] private List<WeatherState> _weatherStates;


    private WeatherState _currentState;
    private PestControlStrategy _strategy;

    private Dictionary<System.Type, List<ZonePad>> _farmObjectDict = new Dictionary<System.Type, List<ZonePad>>();

    private void Awake()
    {
        _farmObjectDict[typeof(Tools)] = new List<ZonePad>();
        _farmObjectDict[typeof(Building)] = new List<ZonePad>();
        _farmObjectDict[typeof(Animal)] = new List<ZonePad>();
        _farmObjectDict[typeof(Crop)] = new List<ZonePad>();
        _strategy = _endGameValues.defaultStrategy;
    }
    public void CalculateValues()
    {
        SetState();
        CalculateMultiplier();

        foreach (var keys in _farmObjectDict.Keys.ToList())
        {
            _farmObjectDict[keys] = _zoneManager.ReturnList(keys);
        }
        foreach (var zonePad in _farmObjectDict[typeof(Tools)])
        {
            var obj = (Tools)zonePad.GetObj();
            _endGameValues.totalCropMultiplier += obj.GetMultiplier();

        }
        foreach (var zonePad in _farmObjectDict[typeof(Building)])
        {
            var obj = (Building)zonePad.GetObj();
            _endGameValues.totalAnimalProfitMultiplier += obj.GetMultiplier();

        }
        foreach (var zonePad in _farmObjectDict[typeof(Crop)])
        {
            var obj = (Crop)zonePad.GetObj();
            var name = obj.GetName();

            _endGameValues.totalCropProfitDict[name] += Mathf.RoundToInt(obj.GetProfit() * _endGameValues.totalCropMultiplier);
            _endGameValues.totalCropProfit += Mathf.RoundToInt(obj.GetProfit() * _endGameValues.totalCropMultiplier);
            _endGameValues.totalSoilEffect += Mathf.RoundToInt(obj.GetEffectOnSoil());

        }
        foreach (var zonePad in _farmObjectDict[typeof(Animal)])
        {
            var obj = (Animal)zonePad.GetObj();
            var name = obj.GetName();

            _endGameValues.totalAnimalProfitDict[name] = Mathf.RoundToInt(obj.GetProfit() * _endGameValues.totalAnimalProfitMultiplier);
            _endGameValues.totalAnimalProfitDict[name] += Mathf.RoundToInt(obj.GetProfit() * _endGameValues.totalAnimalProfitMultiplier);
            _endGameValues.totalAnimalProfit += Mathf.RoundToInt(obj.GetProfit() * _endGameValues.totalAnimalProfitMultiplier);
        }
        _endGameValues.totalProfit = _endGameValues.totalAnimalProfit + _endGameValues.totalCropProfit;
        _soilValue.Value += (_endGameValues.soilIncreaseValueEveryRound - _endGameValues.totalSoilEffect);
        _soilValue.Value = (_soilValue.Value > 100) ? 100 : (_soilValue.Value < 0) ? 0 : _soilValue.Value;
        _moneySO.Value += _endGameValues.totalProfit;
    }
    public void Restarted()
    {
        _strategy = _endGameValues.defaultStrategy;
    }
    private void CalculateMultiplier()
    {
        var strategyValueList = _strategy.GetStrategyValues();
        _endGameValues.totalCropMultiplier += strategyValueList[0] + _currentState.GetProfit();
        _endGameValues.totalSoilEffectMultiplier += strategyValueList[1] + _currentState.GetSoilEffect();
    }
    private void SetState()
    {
        var index = Random.Range(0, _weatherStates.Count);
        _currentState = _weatherStates[index];
        _endGameValues.weatherStateText = _currentState.GetText();

    }

    public void AddStrategy(FarmObject obj)
    {
        if (obj is PestControlStrategy)
        {
            _strategy = (PestControlStrategy)obj;
        }
    }
}
