using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectAppearing : MonoBehaviour
{
    [SerializeField] private GameObject Order;
    [SerializeField] private float Delay;
    private float DelayOffset;
    private float TimePassed;
    void Start()
    {
        Order.SetActive(false);
        DelayOffset = Random.Range(0, 5);
    }

    void Update()
    {
        print("obj status:" + Order.activeSelf);
        TimePassed += Time.deltaTime;
        if ((TimePassed > Delay + DelayOffset) && Order.activeSelf == false)
        {
            Appear();
            DelayOffset = Random.Range(0, 3);
            TimePassed = 0;
        }
    }

    private void Appear()
    {
        print("Appear called");
        Order.SetActive(true);
    }
}
