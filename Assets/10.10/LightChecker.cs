using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChecker : MonoBehaviour
{
    public OVRPlayerController controller;
    public GameObject lights;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                if (controller.handTriggerL || controller.handTriggerR)
                {
                    lights.gameObject.SetActive(true);
                }
                else
                {
                    lights.gameObject.SetActive(false);
                }
            }
        }
    }
}
