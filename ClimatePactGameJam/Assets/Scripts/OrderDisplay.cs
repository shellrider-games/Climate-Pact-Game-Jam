using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderDisplay : MonoBehaviour
{   
    [SerializeField] private Image timerImage;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image orderImage;

    public void UpdateOrderText(string order)
    {
        timerText.text = order;
    }
    
    public void UpdateTimer(float timeLeft, float totalTime)
    {
        if (totalTime <= 0)
        {
            timerImage.fillAmount = 0;
            return;
        }
        Debug.Assert(timerImage != null, "timerImage can't be null");
        timerImage.fillAmount = timeLeft / totalTime;
    }

    public void UpdateOrderImage(Sprite sprite)
    {
        orderImage.sprite = sprite;
    }
}
