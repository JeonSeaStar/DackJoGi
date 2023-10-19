using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestInnerFilter : MonoBehaviour
{
    public OVRPlayerController playerController;

    public GameObject[] chage;
    public Material innerFilterMat;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FilterInner"))
        {
            playerController.AirFilterRequest03Pass = true;
        }
        if(other.CompareTag("Air"))
        {
            chage[0].SetActive(false);
            chage[1].SetActive(true);
            innerFilterMat.SetFloat("_DetailAlbedoAdjustment", 1);
        }
    }
}
