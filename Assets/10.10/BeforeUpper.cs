using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeUpper : MonoBehaviour
{
    public OVRPlayerController controller;
    public GameObject[] Uppers;
    public GameObject[] orings;

    private void OnTriggerEnter(Collider other)
    {
        if(controller.clearUpperDirty)
        {
            controller.airFilterGuideObject[7].SetActive(true);
            if (other.gameObject.CompareTag("FilterUpperCheck"))
            {
                controller.airFilterGuideObject[5].SetActive(false);
                controller.airFilterGuideObject[6].SetActive(false);
                controller.airFilterGuideObject[7].SetActive(false);
                controller.airFilterGuideObject[8].SetActive(true);
                controller.airFilterGuideObject[9].SetActive(true);
                Uppers[0].gameObject.SetActive(false);
                Uppers[1].gameObject.SetActive(true);

                orings[0].SetActive(false);
                orings[1].SetActive(true);
                
            }
        }
    }
}
