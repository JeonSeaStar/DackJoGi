using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessOne : MonoBehaviour
{
    public Buckle1 buckle1;
    public Buckle2 buckle2;
    public Buckle3 buckle3;
    public Buckle4 Buckle4;

    public GameObject buckleCheckBefore;
    public GameObject buckleCheckAfter;

    public bool once = false;
    //public SelectUI selectUI;

    //public void Awake()
    //{
    //    selectUI.NextGuide();
    //}

    public void Update()
    {
        if (!once)
            BuckleCheck();
    }

    public void BuckleCheck()
    {
        if (buckle1.unlock1 == true && buckle2.unlock2 == true && buckle3.unlock3 == true && Buckle4.unlock4 == true)
        {
            buckleCheckBefore.gameObject.SetActive(false);
            buckleCheckAfter.gameObject.SetActive(true);
            SelectUI.instance.NextHighLight();
            once = true;
        }
    }
}
