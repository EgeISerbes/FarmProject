using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EndGameValues : MonoBehaviour
{
     public int soilIncreaseValueEveryRound = 10;
    [HideInInspector] public int totalProfit = 0;
    [HideInInspector] public int totalCropProfit = 0;
    [HideInInspector] public int totalSoilEffect = 0;
    [HideInInspector] public int totalAnimalProfit = 0;
    [HideInInspector] public float totalAnimalProfitMultiplier = 1;
    [HideInInspector] public float totalCropMultiplier = 1;
    [HideInInspector] public float totalSoilEffectMultiplier = 1;
    [HideInInspector] public string weatherStateText;
    public Dictionary<string, int> totalCropProfitDict = new Dictionary<string, int>();
    public Dictionary<string, int> totalAnimalProfitDict = new Dictionary<string, int>();
    public PestControlStrategy defaultStrategy;


    [SerializeField] private GameEventListenerWP _onGameRestart;
    void Awake()
    {
        totalAnimalProfitDict["Cow"] = 0;
        totalAnimalProfitDict["Chicken"] = 0;
        totalCropProfitDict["Corn"] = 0;
        totalCropProfitDict["Tomato"] = 0;
    }

    public void GameRestarted()
    {
        totalProfit = 0;
        totalCropProfit = 0;
        totalSoilEffect = 0;
        totalAnimalProfit = 0;
        totalAnimalProfitMultiplier = 1;
        totalCropMultiplier = 1;
        totalSoilEffectMultiplier = 1;

        foreach (var keys in totalCropProfitDict.Keys.ToList())
        {
            totalCropProfitDict[keys] = 0;
        }
        foreach (var keys in totalAnimalProfitDict.Keys.ToList())
        {
            totalAnimalProfitDict[keys] = 0;
        }
    }
}
