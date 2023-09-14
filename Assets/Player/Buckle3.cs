using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckle3 : MonoBehaviour
{
    public bool unlock3 = false;
    public bool hand3 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            hand3 = true;
        }
    }

    private void Update()
    {
        if(hand3)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 1f)
            {
                unlock3 = true;
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 1f)
            {
                unlock3 = true;
            }
        }
    }
}
