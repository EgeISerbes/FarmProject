using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainState : WeatherState
{
    public override void doAction()
    {
        throw new System.NotImplementedException();
    }

    public override float GetProfit()
    {
        return _profitMultiplier;
    }

    public override float GetSoilEffect()
    {
        return _soilEffectMultiplier;
    }
    public override string GetText()
    {
        return _stateText;
    }
}
