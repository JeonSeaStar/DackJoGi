using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckle1 : MonoBehaviour
{
    public bool unlock1 = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
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
