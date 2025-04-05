using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image LinearTimerImg;
    private float timeRemaining;
    [SerializeField] private float maxTime = 5.0f;
    [SerializeField] private UnityEvent TimeOver;
    
    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {
        // time deduction
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            LinearTimerImg.fillAmount = timeRemaining / maxTime;
        }
        else
        {
            // disappearing of timer and order
            TimeOver.Invoke();
            timeRemaining = maxTime;
        }
    }
}
