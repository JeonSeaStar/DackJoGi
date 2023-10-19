using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowGun : MonoBehaviour
{
    public OVRPlayerController controller;
    public ParticleSystem airForce;
    public GameObject air;

    private void Start()
    {
        controller = GetComponent<OVRPlayerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            if(controller.handGrapL || controller.handGrapR)
            {
                if(controller.handTriggerL || controller.handTriggerR) 
                {
                    airForce.Play();
                    air.gameObject.SetActive(true);
                }
                else
                {
                    airForce.Pause();
                    air.gameObject.SetActive(false);
                }
                if(controller.clearFilterDirty)
                {
                    controller.airFilterGuideObject[10].SetActive(false);
                    controller.airFilterGuideObject[11].SetActive(false);
                    controller.airFilterGuideObject[12].SetActive(true);

                }
            }
        }
    }
}
