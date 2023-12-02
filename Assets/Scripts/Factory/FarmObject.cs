using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmObject : MonoBehaviour
{
    [SerializeField] protected string obj_name;
    [SerializeField] protected int cost;

    public abstract string GetName();
    public abstract int GetCost();


}