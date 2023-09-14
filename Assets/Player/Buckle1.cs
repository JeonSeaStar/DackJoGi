using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckle1 : MonoBehaviour
{
    public bool unlock1 = false;
    public bool hand1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            hand1 = true;
        }
    }

    private void Update()
    {
        if(hand1)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 1f)
            {
                unlock1 = true;
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 1f)
            {
                unlock1 = true;
            }
        }
    }
}
