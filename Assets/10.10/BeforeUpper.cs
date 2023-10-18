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
            if (other.gameObject.CompareTag("FilterUpperCheck"))
            {
                Uppers[0].gameObject.SetActive(false);
                Uppers[1].gameObject.SetActive(true);

                orings[0].SetActive(false);
                orings[1].SetActive(true);
                
            }
        }
    }
}
