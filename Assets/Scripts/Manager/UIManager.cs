using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyVal;
  
    [SerializeField] private List<UIHeaderButton> _availableButtons;
    [SerializeField] private GameEventListener<int> _onMoneyChangeListener;
    [SerializeField] private GameEventListenerWP _onGameRestartListener;
    [SerializeField] private ButtonClickEvent<FarmObject> _onButtonClick;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private GameObject _mainScreen;
    private void Start()
    {
        foreach (var header_buttons in _availableButtons)
        {
            foreach (var button in header_buttons.UIButton)
            {
                button.AddEvent(_onButtonClick);
            }
        }
    }
    public void UpdateTables(bool value)
    {
        foreach (var button in _availableButtons)
        {
            button.SetButtonsState(value);
        }
    }
    public void MoneyChanged(int value)
    {
        moneyVal.SetText(value.ToString());
        foreach (var buttonHeaders in _availableButtons)
        {
            buttonHeaders.ArrangeButtons(value);
        }
    }
    public void SetEndScreen()
    {
        _mainScreen.SetActive(false);
        _endScreen.gameObject.SetActive(true);
        _endScreen.SetValues();
    }
    public void SetMainScreen()
    {
        _mainScreen.SetActive(true);
        _endScreen.gameObject.SetActive(false);

    }

}
