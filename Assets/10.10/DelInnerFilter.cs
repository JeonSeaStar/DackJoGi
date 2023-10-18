using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelInnerFilter : MonoBehaviour
{
    public OVRPlayerController playerController;
    public GameObject[] innerFilters;
    public GameObject[] innerFilterChecked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FilterInner"))
        {
            innerFilters[0].SetActive(false);
            innerFilters[1].SetActive(true);

            innerFilterChecked[0].SetActive(false);
            innerFilterChecked[1].SetActive(true);
            playerController.PartProcessClear02();

        }
    }
}
