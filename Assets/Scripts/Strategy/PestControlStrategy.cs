using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PestControlStrategy : FarmObject
{

    [SerializeField] protected float _profitMultiplier;
    [SerializeField] protected float _soilEffect_Multiplier;
    public void ApplyStrategy(ref int totalProfit, ref int totalSoilEffect)
    {
        totalProfit = Mathf.RoundToInt(totalProfit * _profitMultiplier);

    }
    public List<float> GetStrategyValues()
    {
        return new List<float>() { _profitMultiplier,_soilEffect_Multiplier};
    }
    
}
