using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterInnerChecker : MonoBehaviour
{
    public bool filterInnerCheck = false;
    public GameObject innerFilter;
    public GameObject innerfilterOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FilterInner"))
        {
            filterInnerCheck = true;
            innerFilter.gameObject.SetActive(false);
            innerfilterOut.gameObject.SetActive(false);
        }
    }
}
