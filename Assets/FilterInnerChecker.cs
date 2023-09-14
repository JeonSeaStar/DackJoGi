using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterInnerChecker : MonoBehaviour
{
    public AirFilterBefore airFilter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FilterInner"))
        {
            airFilter.filterInnerCheckBool = true;
        }
    }
}
