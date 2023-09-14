using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessThree : MonoBehaviour
{
    public FilterInnerChecker innerChecker;

    public GameObject beforeInnerFilter;
    public GameObject afterInnerFilter;

    public void Update()
    {
        Check();
    }

    public void Check()
    {
        if(innerChecker.filterInnerCheck == true)
        {
            beforeInnerFilter.gameObject.SetActive(false);
            afterInnerFilter.gameObject.SetActive(true);
        }
    }
}
