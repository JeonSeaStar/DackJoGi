using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessFour : MonoBehaviour
{
    public FilterUpperCheck upperCheck;

    public GameObject beforeUpperFilter;
    public GameObject afterUpperFilter;

    public AfterBuckle1 afterBuckle1;
    public AfterBuckle2 afterBuckle2;
    public AfterBuckle3 afterBuckle3;
    public AfterBuckle4 afterBuckle4;

    public bool buckleChecker = false;

    public SelectUI selectUI;

    public void Awake()
    {
        selectUI.NextGuide();
    }

    public void Update()
    {
        Check();
        BuckleCheck();
    }

    public void Check()
    {
        if(upperCheck.filterUpperCheck == true)
        {
            beforeUpperFilter.gameObject.SetActive(false);
            afterUpperFilter.gameObject.SetActive(true);
        }
    }

    public void BuckleCheck()
    {
        if(afterBuckle1.lock1 && afterBuckle2.lock2 && afterBuckle3.lock3 && afterBuckle4.lock4)
        {
            SelectUI.instance.NextHighLight();
            buckleChecker = true;
        }
    }

}
