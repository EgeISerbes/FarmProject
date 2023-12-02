using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalZonePad : LivestockZonePad
{
    protected FreeRangeAnimalDecorator _freeRangeAnimalDecorator;
    public override void AddItem(FarmObject obj)
    {
        if (obj is FreeRangeAnimalDecorator)
        {
            obj.transform.position = _decoratorPos.transform.position;
            _freeRangeAnimalDecorator = (FreeRangeAnimalDecorator)obj;
            _freeRangeAnimalDecorator.Init((Animal)_obj_slot);
            _tempOBJ_slot = _obj_slot;
            SetActivity(false, true);
        }
        base.AddItem(obj);

    }
    public override void ClearSlot()
    {
        if(_freeRangeAnimalDecorator != null)
        {
            Destroy(_freeRangeAnimalDecorator.gameObject);
            _freeRangeAnimalDecorator = null;

        }
        base.ClearSlot();

    }
}
