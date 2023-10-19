using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyCleaner : MonoBehaviour
{
    public OVRPlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dirty"))
        {
            other.gameObject.SetActive(false);
            if(playerController.clearUpperDirty)
            {
                playerController.airFilterGuideObject[7].SetActive(true);
            }
        }
    }
}
