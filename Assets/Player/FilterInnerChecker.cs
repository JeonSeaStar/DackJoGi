using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterInnerChecker : MonoBehaviour
{
    public bool filterInnerCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FilterInner"))
        {
            filterInnerCheck = true;
        }
    }
}
