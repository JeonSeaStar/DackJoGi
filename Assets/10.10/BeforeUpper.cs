using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeUpper : MonoBehaviour
{
    public OVRPlayerController controller;
    public GameObject[] Uppers;

    private void OnTriggerEnter(Collider other)
    {
        if(controller.clearUpperDirty)
        {
            if (other.gameObject.CompareTag("TableUpper"))
            {
                Uppers[0].gameObject.SetActive(false);
                Uppers[1].gameObject.SetActive(true);
                controller.ProcessClear02();
            }
        }
    }
}
