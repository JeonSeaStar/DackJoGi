using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OringChecker : MonoBehaviour
{
    public OVRPlayerController playerController;
    public GameObject[] orings;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Oring"))
        {
            orings[0].SetActive(false);
            orings[1].SetActive(true);
            playerController.ProcessClear06();
        }
    }
}
