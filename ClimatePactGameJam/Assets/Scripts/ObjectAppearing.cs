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
        TimePassed += Time.deltaTime;
        if ((TimePassed > Delay + DelayOffset) && Order.activeSelf == false)
        {
            Appear();
            DelayOffset = Random.Range(0, 3);
        }
    }

    private void Appear()
    {
        Order.SetActive(true);
        print("Object: " + Order + "status: " + Order.activeSelf);
    }

    public void Disappear()
    {
        Order.SetActive(false);
        TimePassed = 0;
        print("Object: " + Order + "status: " + Order.activeSelf);
    }
}
