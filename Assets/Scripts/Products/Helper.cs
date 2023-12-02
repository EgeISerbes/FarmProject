using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : FarmObject
{
    [SerializeField] protected float _valueMultiplier;
    public override int GetCost()
    {
        return cost;
    }

    public override string GetName()
    {
        return obj_name;
    }
    public virtual float GetMultiplier()
    {
        return _valueMultiplier;
    }
}
