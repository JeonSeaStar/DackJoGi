using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeOutter : MonoBehaviour
{
    public OVRPlayerController playerController;

    public GameObject[] outterFilters;

    private void OnTriggerEnter(Collider other)
    {
        if(playerController.clearFilterDirty)
        {
            if (other.CompareTag("OutterFilter"))
            {
                outterFilters[0].SetActive(false);
                outterFilters[1].SetActive(true);
                
                playerController.ProcessClear03();
            }
        }
    }
}
