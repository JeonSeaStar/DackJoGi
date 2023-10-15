using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFilter : MonoBehaviour
{
    public OVRPlayerController controller;
    public GameObject[] filters;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FilterCheck"))
        {
            filters[0].SetActive(false);
            filters[1].SetActive(true);
            controller.ProcessClear05();
        }    

    }
}
