using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : Livestock
{
    [SerializeField] private float _effect_on_Soil;
    public void Init(string name, int cost, int profit)
    {
        this.name = name;
        this.cost = cost;
        this.profit = profit;
        
    }


    public override string GetName()
    {
        return obj_name;
    }

    public override int GetCost()
    {
        return cost;
    }

    public override int GetProfit()
    {
        return profit;
    }
    public virtual float GetEffectOnSoil()
    {
        return _effect_on_Soil;
    }
    public void SetEffectOnSoil(int value)
    {
        _effect_on_Soil = value;
    }

}
