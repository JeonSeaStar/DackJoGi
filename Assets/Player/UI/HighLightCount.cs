using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightCount : MonoBehaviour
{
    public bool Hand1
    {
        get { return hand1; }
        set
        {
            hand1 = value;
            if(Hand1)
            {
                //SelectUI.instance.
            }
        }
    }
    public bool hand1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            Hand1 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            Hand1 = false;
        }
    }
}
