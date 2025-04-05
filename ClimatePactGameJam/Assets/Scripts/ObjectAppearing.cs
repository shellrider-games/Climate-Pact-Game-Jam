using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectAppearing : MonoBehaviour
{
    [SerializeField] private GameObject[] objArr;
    [SerializeField] private float Delay;
    private float DelayOffset;
    private float TimePassed;

    void Start()
    {
        objArr[0].SetActive(false);
        objArr[1].SetActive(false);
        objArr[2].SetActive(false);
        DelayOffset = Random.Range(0, 7);
        
    }

    void Update()
    {
        // randomly generate first shape       
        TimePassed += Time.deltaTime;
        if ((TimePassed > Delay + DelayOffset))
        {
            Appear();
        }
    }

    private void Appear()
    {
        if (objArr.All(x => x.activeSelf))
        {
            return;
        }
        int objNum = Random.Range(0, objArr.Length - 1);
        while (objArr[objNum].activeSelf)
        {
            objNum++;
            objNum %= objArr.Length;
        }
        objArr[objNum].SetActive(true);
        Delay /= 2;
        TimePassed = 0;                                
    }

    public void Disappear(GameObject Order)
    {
        Order.SetActive(false);
        DelayOffset = Random.Range(0, 7);
        TimePassed = 0;
        print("Object: " + Order + "status: " + Order.activeSelf);
    }
}