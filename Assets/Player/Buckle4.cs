using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckle4 : MonoBehaviour
{
    public bool unlock4 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 1f)
            {
                unlock4 = true;
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 1f)
            {
                unlock4 = true;
            }
        }
    }
}
