using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCompressorChecker : MonoBehaviour
{
    public OVRPlayerController playerController;
    public Material innerFilterMat;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Air"))
        {
            playerController.airCompressorCheck = true;
            innerFilterMat.SetFloat("_DetailAlbedoAdjustment", 1);
        }
    }
}
