using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private int currentMoney;
    [SerializeField] private MoneyDisplay moneyDisplay;

    private void Awake()
    {
        currentMoney = 0;
        moneyDisplay.UpdateMoney(currentMoney);
    }

    public void GainMoney(int amount)
    {
        currentMoney += amount;
        moneyDisplay.UpdateMoney(currentMoney);
    }
}
