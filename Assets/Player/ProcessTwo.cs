using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessTwo : MonoBehaviour
{
    public Rigidbody rig;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.8f)
            {
                rig.useGravity = true;
                rig.isKinematic = false;
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.8f)
            {
                rig.useGravity = true;
                rig.isKinematic = false;
            }
        }
    }
}
