using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmObjectDecorator : FarmObject
{
    [SerializeField] private FarmObject _targetObj;
    public override int GetCost()
    {
        return _targetObj.GetCost();
    }

    public override string GetName()
    {
        return name;
    }
}
