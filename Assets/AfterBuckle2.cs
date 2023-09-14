using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBuckle2 : MonoBehaviour
{
    public bool lock2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
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
