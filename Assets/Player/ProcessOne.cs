using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessOne: MonoBehaviour
{
    public Buckle1 buckle1;
    public Buckle2 buckle2;
    public Buckle3 buckle3;
    public Buckle4 Buckle4;

    public GameObject buckleCheckBefore;
    public GameObject buckleCheckAfter;

    public void Update()
    {
        BuckleCheck();
    }

    public void BuckleCheck()
    {
        if(buckle1.unlock1 == true && buckle2.unlock2 == true && buckle3.unlock3 == true && Buckle4.unlock4 == true)
        {
            Destroy(buckleCheckBefore);
            buckleCheckAfter.gameObject.SetActive(true);
        }
    }
}
