using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessFour : MonoBehaviour
{
    public FilterUpperCheck upperCheck;

    public GameObject beforeUpperFilter;
    public GameObject afterUpperFilter;

    public void Update()
    {
        Check();
    }

    public void Check()
    {
        if(upperCheck.filterUpperCheck == true)
        {
            beforeUpperFilter.gameObject.SetActive(false);
            afterUpperFilter.gameObject.SetActive(true);
        }
    }

}
