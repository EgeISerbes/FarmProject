using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivestockZonePad : ZonePad
{
    
    protected FarmObject _tempOBJ_slot;
    [SerializeField] protected Transform _decoratorPos;

    public void SetActivity(bool value,bool isDecorator=false)
    {
        if (IsSlotFull()&& !isDecorator)
        {
            return;
        }
        if (_tempOBJ_slot != null) return;
        _zoneCollider.enabled = value;
        _highlighterOBJ.SetActive(value);

    }
    public override void ClearSlot()
    {
        if(_tempOBJ_slot != null)
        {
            Destroy(_tempOBJ_slot.gameObject);
            _tempOBJ_slot = null;
        }
        base.ClearSlot();
    }
}
