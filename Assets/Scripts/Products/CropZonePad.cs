using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropZonePad : LivestockZonePad
{
    protected CropDecorator _cropDecorator;
    public override void AddItem(FarmObject obj)
    {
        if (obj is CropDecorator)
        {
            obj.transform.position = _decoratorPos.transform.position;
            _cropDecorator = (CropDecorator)obj;
            _cropDecorator.Init((Crop)_obj_slot);
            _tempOBJ_slot = _obj_slot;
            SetActivity(false, true);
        }
        base.AddItem(obj);

    }
    public override void ClearSlot()
    {   
        if(_cropDecorator !=null)
        {
            Destroy(_cropDecorator.gameObject);
            _cropDecorator = null;
        }
        
        base.ClearSlot();

    }

}
