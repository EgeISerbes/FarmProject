using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestControlManager
{
    private PestControlStrategy _strategy;
    [SerializeField] private ButtonClickEventListener<FarmObject> _onButtonClicked;

    public PestControlStrategy Strategy
    {
        get => _strategy;
    }
    public void AddStrategy(FarmObject obj)
    {
        if (obj is PestControlStrategy)
        {
            _strategy = (PestControlStrategy)obj;
        }
    }

    public void ModifyValues(ref int totalProfit, ref int totalSoilEffect)
    {
        _strategy.ApplyStrategy(ref totalProfit, ref totalSoilEffect);
    }
}
