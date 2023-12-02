using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZoneManager : MonoBehaviour
{

    [SerializeField] private ZoneValues _zoneValues;
    private Type _activeType;


    public ButtonClickEventListener<FarmObject> _buttonListener;
    public ButtonClickEventListener<ZonePad> _zoneListener;
    


    private void Start()
    {
        foreach (var item in _zoneValues.typeDict.Keys)
        {
            SetActiveState(_zoneValues.typeDict[item], false);
        }
    }


    public List<ZonePad> ReturnList(Type type)
    {
        var list = new List<ZonePad>();
        foreach (var index in _zoneValues.activePadsDict[type])
        {
            list.Add(_zoneValues.typeDict[type][index]);
        }
        return list;
    }

    
    public void GetFarmObject(FarmObject obj)
    {
        try
        {
            if (_activeType != null)
            {
                SetActiveState(_zoneValues.typeDict[_activeType], false);
                _activeType = null;
            }
            _activeType = obj.GetType();
            SetActiveState(_zoneValues.typeDict[_activeType], true);
        }
        catch (KeyNotFoundException e)
        {
            if (obj is FreeRangeAnimalDecorator)
            {
                _activeType = typeof(Animal);
            }
            else if (obj is CropDecorator)
            {
                _activeType = typeof(Crop);
            }
            else if (obj is PestControlStrategy)
            {
                _zoneValues.moneySO.Value -= obj.GetCost();
                _activeType = null;
                return;
            }
            SetActiveState(_zoneValues.typeDict[_activeType], true, _zoneValues.activePadsDict[_activeType]);
        }
    }

    public void PadClicked(ZonePad pad)
    {
        if (_activeType == null) return;
        if (pad is LivestockZonePad)
        {
            var activeIndex = Array.IndexOf(_zoneValues.typeDict[_activeType], pad);
            _zoneValues.activePadsDict[_activeType].Add(activeIndex);
        }
        SetActiveState(_zoneValues.typeDict[_activeType], false);
        _activeType = null;
    }

    public void SetActiveState(ZonePad[] list, bool value, HashSet<int> activeIndexes = null)
    {
        if (activeIndexes == null)
        {
            foreach (var pad in list)
            {
                pad.SetActivity(value);
            }
        }
        else
        {
            foreach (var index in activeIndexes)
            {
                ((LivestockZonePad)list[index]).SetActivity(value, true);
            }
        }

    }

}

