using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="New Money SO",menuName ="SO variables/Money")]
public class MoneySO : ScriptableObject
{
    [SerializeField] int _value;
    public GameEvent<int> gameEvent;
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            gameEvent.TriggerEvent(_value);

        }
    }
}
