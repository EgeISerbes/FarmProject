using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPestControlStrategy 
{
    void ApplyStrategy(List<FarmObject> crops, List<FarmObject> animals);
    
}
