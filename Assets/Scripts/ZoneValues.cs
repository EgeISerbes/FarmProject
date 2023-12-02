using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZoneValues : MonoBehaviour
{
    [SerializeField] Transform _buildingZoneHeader;
    [SerializeField] Transform _cropZoneHeader;
    [SerializeField] Transform _animalZoneHeader;
    [SerializeField] Transform _toolZoneHeader;
    [SerializeField] GameEventListenerWP _onGameRestart;
    public MoneySO moneySO;
    public Dictionary<Type, ZonePad[]> typeDict = new Dictionary<Type, ZonePad[]>();
    public Dictionary<Type, HashSet<int>> activePadsDict = new Dictionary<Type, HashSet<int>>();
    public ButtonClickEvent<ZonePad> _onClickbutton;
    private void Awake()
    {

        typeDict[typeof(Crop)] = AddIntoList(_cropZoneHeader);
        activePadsDict[typeof(Crop)] = new HashSet<int>();
        typeDict[typeof(Animal)] = AddIntoList(_animalZoneHeader);
        activePadsDict[typeof(Animal)] = new HashSet<int>();

        typeDict[typeof(Building)] = AddIntoList(_buildingZoneHeader);
        activePadsDict[typeof(Building)] = new HashSet<int>();
        typeDict[typeof(Tools)] = AddIntoList(_toolZoneHeader);
        activePadsDict[typeof(Tools)] = new HashSet<int>();

    }
    ZonePad[] AddIntoList(Transform header)
    {
        ZonePad[] list;
        list = header.GetComponentsInChildren<ZonePad>();
        foreach (var zone_pad in list)
        {
            zone_pad.Init(_onClickbutton);
        }
        return list;

    }

    public void GameRestarted()
    {
        foreach (var item in activePadsDict[typeof(Crop)])
        {
            typeDict[typeof(Crop)][item].ClearSlot();
        }
        activePadsDict[typeof(Crop)].Clear();
    }
}
