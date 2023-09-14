using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBuckle2 : MonoBehaviour
{
    public bool lock2 = false;
    public bool hand = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            hand = true;
        }
    }

    private void Update()
    {
        if (hand == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 1f)
            {
                lock2 = true;
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 1f)
            {
                lock2 = true;
            }
        }
    }
}
