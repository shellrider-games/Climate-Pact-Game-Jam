using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public void UpdateMoney(int money)
    {
        moneyText.text = $"Money: {money}$";
    }
}
