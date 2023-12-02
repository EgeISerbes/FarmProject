using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIButton : ButtonCommand
{
    [SerializeField] private FarmObject _targetFarmObject;
    private ButtonClickEvent<FarmObject> _buttonClickEvent;
    private int _val;
    [SerializeField] private TextMeshProUGUI _moneyText;
    public int Money
    {
        get => _val;
    }

    private void Awake()
    {
        _val = _targetFarmObject.GetCost();
        _moneyText.SetText(_val.ToString());
    }
    public override void OnButtonPressed()
    {
        _buttonClickEvent.TriggerEvent(_targetFarmObject.GetComponent<FarmObject>());
    }
    public void AddEvent(ButtonClickEvent<FarmObject> buttonEvent)
    {
        _buttonClickEvent = buttonEvent;
    }

}
