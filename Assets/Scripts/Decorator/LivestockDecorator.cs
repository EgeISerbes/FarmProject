using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivestockDecorator : Livestock
{
    protected Livestock _livestock;
    [SerializeField] protected int _profitMultiplier;
    public virtual void Init(Livestock livestock_Object)
    {
        this._livestock = livestock_Object;
    }
    public virtual void Init(Livestock livestock_Object, int profitMultiplier)
    {
        this._livestock = livestock_Object;
        this._profitMultiplier = profitMultiplier;
    }
    public override int GetCost()
    {
        return cost; // We get the cost of the decorator , not the object
    }

    public override string GetName()
    {
        return _livestock.GetName();
    }
    public override int GetProfit()
    {
        return _profitMultiplier * _livestock.GetProfit();
    }
}
