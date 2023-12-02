using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _totalMoneyLeftText;
    [SerializeField] private TextMeshProUGUI _weatherStateText;
    [SerializeField] private TextMeshProUGUI _soilValueText;
    [SerializeField] private TextMeshProUGUI _totalMoneyEarnedText;
    [SerializeField] private TextMeshProUGUI _totalMoneyEarnedOnChickenText;
    [SerializeField] private TextMeshProUGUI _totalMoneyEarnedOnCowText;
    [SerializeField] private TextMeshProUGUI _totalMoneyEarnedOnTomatoText;
    [SerializeField] private TextMeshProUGUI _totalMoneyEarnedOnCornText;
    [SerializeField] private SoilHealthBar _soilHealthBar;

    [Header("Values")]
    [SerializeField] private MoneySO _moneySO;
    [SerializeField] private MoneySO _soilSO;
    [SerializeField] private EndGameValues _endGameValues;

    [Header("Event")]
    [SerializeField] private GameEventWP _gameEvent;
    
    public void SetValues()
    {
        _totalMoneyLeftText.SetText(_moneySO.Value.ToString());
        _weatherStateText.SetText(_endGameValues.weatherStateText);
        _soilValueText.SetText(_soilSO.Value.ToString());
        _totalMoneyEarnedText.SetText(_endGameValues.totalProfit.ToString());
        _totalMoneyEarnedOnCornText.SetText(_endGameValues.totalCropProfitDict["Corn"].ToString());
        _totalMoneyEarnedOnTomatoText.SetText(_endGameValues.totalCropProfitDict["Tomato"].ToString());
        _totalMoneyEarnedOnChickenText.SetText(_endGameValues.totalAnimalProfitDict["Chicken"].ToString());
        _totalMoneyEarnedOnCowText.SetText(_endGameValues.totalAnimalProfitDict["Cow"].ToString());
        _soilHealthBar.SetBarScale(_soilSO.Value);
    }

    public void RestartPressed()
    {
        _gameEvent.TriggerEvent();
    }
}
