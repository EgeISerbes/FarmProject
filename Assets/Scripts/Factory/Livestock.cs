using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livestock : FarmObject
{
    public int profit;
    public override  int GetCost()
    {
        return cost;
    }
    public override string GetName()
    {
        return obj_name;
    }
    public virtual int GetProfit()
    {
        return profit;
    }

    public void SetProfit(int value)
    {
        profit = value;
    }
    
}
