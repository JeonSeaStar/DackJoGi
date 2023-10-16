using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilFilter : MonoBehaviour
{
    public OVRPlayerController playerController;

    public GameObject chage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OilFilterCheck"))
        {
            playerController.oilFilterCheck = true;
            chage.gameObject.SetActive(false);
        }
    }
}
