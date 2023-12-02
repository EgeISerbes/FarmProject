using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeatherState : MonoBehaviour
{
    [SerializeField] protected float _soilEffectMultiplier;
    [SerializeField] protected float _profitMultiplier;
    [SerializeField] protected string _stateText;
    public abstract void doAction();
    public abstract float GetProfit();
    public abstract float GetSoilEffect();

    public abstract string GetText();

}
