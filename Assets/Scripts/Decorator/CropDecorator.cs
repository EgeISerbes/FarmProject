using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropDecorator : Crop
{
    [SerializeField] protected Crop _crop;
    [SerializeField] protected int _profitMultiplier;
    [SerializeField] protected int _soilEffectMultiplier;
    public void Init(Crop crop)
    {
        _crop = crop;
    }

    public override int GetProfit()
    {
        return _profitMultiplier * _crop.profit;
    }
    public override string GetName()
    {
        return _crop.GetName();
    }
    public override float GetEffectOnSoil()
    {
        return _crop.GetEffectOnSoil() * _soilEffectMultiplier;
    }
}
