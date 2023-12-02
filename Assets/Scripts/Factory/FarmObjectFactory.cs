using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmObjectFactory : MonoBehaviour
{
    private FarmObject _objRef;

    public ButtonClickEventListener<FarmObject> _buttonListener;
    public ButtonClickEventListener<ZonePad> _onClickListener;


    public void GetFarmObject(FarmObject obj)
    {
        ClearReference();
        _objRef = obj;
    }

    private void ClearReference()
    {
        _objRef = null;

    }
    public void CreateFarmObject(ZonePad pad)
    {
        var parent_tr = pad.GetSpawnPos();
        var farmOBJ = Object.Instantiate(_objRef, parent_tr.position, parent_tr.rotation);
        pad.AddItem(farmOBJ);
        ClearReference();


    }
}
