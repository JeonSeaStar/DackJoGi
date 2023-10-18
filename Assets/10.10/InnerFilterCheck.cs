using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerFilterCheck : MonoBehaviour
{
    public OVRPlayerController playerController;
    public GameObject[] InnerFilter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FilterInner"))
        {
            InnerFilter[0].SetActive(false);
            InnerFilter[1].SetActive(true);
            playerController.ChangeTable();
            playerController.PartProcessClear03();
        }
    }
}
