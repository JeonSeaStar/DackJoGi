using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterUpperCheck : MonoBehaviour
{
    public bool filterUpperCheck = false;
    public GameObject upper;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FilterUpper"))
        {
            filterUpperCheck = true;
            SelectUI.instance.NextHighLight();
            upper.gameObject.SetActive(false);
        }
    }
}
