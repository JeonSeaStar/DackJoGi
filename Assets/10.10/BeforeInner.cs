using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeInner : MonoBehaviour
{
    public OVRPlayerController controller;
    public GameObject[] Inners;

    private void OnTriggerEnter(Collider other)
    {
        if (controller.clearFilterDirty)
        {
            if (other.gameObject.CompareTag("TableInner"))
            {
                Inners[0].gameObject.SetActive(false);
                Inners[1].gameObject.SetActive(true);
                controller.ProcessClear03();
            }
        }
    }
}
