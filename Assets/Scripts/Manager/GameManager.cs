using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField] private MoneySO _money;

    [SerializeField] private UIManager _uiManager;

    [SerializeField] private ButtonClickEventListener<ZonePad> _onPlanted;


    [SerializeField] private EndGameCalculation _endGameCalculation;

    private void Awake()
    {
        ArrangeScene();
        _uiManager.moneyVal.SetText(_money.Value.ToString());
    }

    public void RoundEnded()
    {
        _endGameCalculation.CalculateValues();
        _uiManager.SetEndScreen();
        
    }

    public void ObjectErected(ZonePad pad)
    {
        StartCoroutine(DeductCosts(pad));
    }

    IEnumerator DeductCosts(ZonePad pad)
    {
        yield return new WaitForEndOfFrame();
        var cost = pad.GetCost();
        _money.Value -= cost;
    }
    public void ArrangeScene()
    {
        _uiManager.UpdateTables(false);
    }

}


