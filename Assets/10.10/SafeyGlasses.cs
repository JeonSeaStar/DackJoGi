using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeyGlasses : MonoBehaviour
{
    public OVRPlayerController playerController;
    public GameObject me;
    public GameObject eyeDirty;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Head"))
        {
            playerController.isSafey = true;
            playerController.airFilterGuideObject[0].SetActive(false);
            playerController.airFilterGuideObject[1].SetActive(true);
            playerController.airFilterGuideObject[2].SetActive(true);
            playerController.airFilterGuideObject[3].SetActive(true);
            playerController.airFilterGuideObject[4].SetActive(true);
            me.SetActive(false);
            eyeDirty.SetActive(false);
        }
    }
}
