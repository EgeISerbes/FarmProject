using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHeaderButton : ButtonCommand
{
    [SerializeField] private List<UIButton> _uiButtons;

    [SerializeField] private GameObject _uiButtonHeader;
    private bool _isHeaderEnabled = false;

    public List<UIButton> UIButton
    {
        get => _uiButtons;
    }

    public override void OnButtonPressed()
    {
        _isHeaderEnabled = !_isHeaderEnabled;
        SetButtonsState(_isHeaderEnabled);
    }

    public void ArrangeButtons(int value)
    {
        foreach (var button in _uiButtons)
        {
            var val = button.Money;
            if (value < val)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);

            }
        }
    }

    public void SetButtonsState(bool value)
    {
        _uiButtonHeader.SetActive(value);
    }

}
