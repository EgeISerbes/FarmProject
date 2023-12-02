using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonCommand : MonoBehaviour
{
   
    public  abstract void OnButtonPressed();
    protected  Button _button;

    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(OnButtonPressed);
    }

}

