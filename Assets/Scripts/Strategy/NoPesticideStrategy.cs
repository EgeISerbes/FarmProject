using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPesticideStrategy : PestControlStrategy
{
   
    public override int GetCost()
    {
        return cost;
    }

    public override string GetName()
    {
        return name;
    }
}
