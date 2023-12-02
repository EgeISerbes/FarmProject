using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePad : MonoBehaviour
{
    [SerializeField] protected FarmObject _obj_slot;
    [SerializeField] protected Transform _spawnPos;
    [SerializeField] protected GameObject _highlighterOBJ;
    private ButtonClickEvent<ZonePad> _onButtonClick;
    protected Collider _zoneCollider;
    public virtual void ClearSlot()
    {   
        Destroy(_obj_slot.gameObject);
        _obj_slot = null;
    }
    public void Init(ButtonClickEvent<ZonePad> _event)
    {
        _onButtonClick = _event;
        _zoneCollider = gameObject.GetComponent<Collider>();
    }
    public virtual void AddItem(FarmObject obj)
    {   
        SetActivity(false);
        _obj_slot = obj;
    }
    public void OnMouseDown()
    {
        _onButtonClick.TriggerEvent(this);
    }

    public void SetActivity(bool value)
    {
        if (IsSlotFull())
        {
            _zoneCollider.enabled = false;
            _highlighterOBJ.SetActive(false);
            return;
        }
        _zoneCollider.enabled = value;
        _highlighterOBJ.SetActive(value);

    }

    public Transform GetSpawnPos()
    {
        return _spawnPos;
    }

    public void SetZoneCollider(bool value)
    {
        _zoneCollider.enabled = value;
    }

    public FarmObject GetObj()
    {
        return _obj_slot;
    }

    public bool IsSlotFull()
    {
        if (_obj_slot == null)
        {
            return false;
        }
        else return true;
    }

    
    public int GetCost()
    {
        return _obj_slot.GetCost();
    }
}
