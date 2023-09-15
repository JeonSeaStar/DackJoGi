using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowGun : MonoBehaviour
{
    public ParticleSystem airForce;

    public bool triggerShot = false;
    public bool holdHand = false;
    public bool hand = false;
    public GameObject air;


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Hand"))
    //    {
    //        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.8f)
    //        {
    //            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.8f)
    //            {
    //                airForce.Play();
    //            }
    //            else
    //            {
    //                airForce.Pause();
    //            }
    //        }

    //        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.8f)
    //        {
    //            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.8f)
    //            {
    //                airForce.Play();
    //            }
    //            else
    //            {
    //                airForce.Pause();
    //            }
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            hand = true;
        }
    }

    private void Update()
    {
        if(hand == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.8f || (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.8f))
            {
                holdHand = true;
            }

            if(holdHand == true)
            {
                if ((OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.8f) || (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.8f))
                {
                    airForce.Play();
                    air.gameObject.SetActive(true);
                }
                else
                {
                    airForce.Pause();
                    air.gameObject.SetActive(false);
                }
            }
        }
    }
}
