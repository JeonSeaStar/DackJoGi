using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelOilFilter : MonoBehaviour
{
    public OVRPlayerController playerController;

    public GameObject[] chage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OilFilter"))
        {
            playerController.OilProcessClear02();
            playerController.delOilFilter = true;

            chage[0].SetActive(false);
            chage[1].SetActive(true);
            playerController.OilFilterRequest01Pass = true;
        }
    }
}
