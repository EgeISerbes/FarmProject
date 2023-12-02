using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeRangeAnimalDecorator : Animal
{
    protected Animal _animal;
    [SerializeField] protected int _profitMultiplier;
    public virtual void Init(Animal animal_Object)
    {
        this._animal = animal_Object;
    }
    public virtual void Init(Animal animal_Object, int profitMultiplier)
    {
        this._animal = animal_Object;
        this._profitMultiplier = profitMultiplier;
    }

    public override int GetCost()
    {
        return cost; // We get the cost of the decorator , not the object
    }

    public override string GetName()
    {
        return _animal.GetName();
    }
    public override int GetProfit()
    {
        return _profitMultiplier * _animal.GetProfit();
    }
}

