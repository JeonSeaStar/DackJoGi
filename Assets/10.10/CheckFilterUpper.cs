using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFilterUpper : MonoBehaviour
{
    public OVRPlayerController controller;
    public GameObject[] filterUppers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FilterUpper"))
        {
            filterUppers[0].SetActive(false);
            filterUppers[1].SetActive(true);
            controller.ProcessClear07();
        }
    }
}
