using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeOring : MonoBehaviour
{
    public OVRPlayerController playerController;

    public GameObject[] orings;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Oring"))
        {
            orings[0].gameObject.SetActive(false);
            orings[1].gameObject.SetActive(true);
            playerController.ProcessClear02();
        }
    }

}
