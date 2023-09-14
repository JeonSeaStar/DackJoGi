using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckle2 : MonoBehaviour
{
    public bool unlock2 = false;
    public bool hand2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            hand2 = true;
        }
    }

    private void Update()
    {
        if(hand2)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 1f)
            {
                unlock2 = true;
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 1f)
            {
                unlock2 = true;
            }
        }
    }
}
