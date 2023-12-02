using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Helper
{
    public override int GetCost()
    {
        return cost;
    }
    public override string GetName()
    {
        return obj_name;
    }
    
}
