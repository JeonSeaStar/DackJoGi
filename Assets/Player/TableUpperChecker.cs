using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUpperChecker : MonoBehaviour
{
    public GameObject filterUpper;
    public GameObject filterUpperTable;

    public bool UpperCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FilterUpper"))
        {
            filterUpper.gameObject.SetActive(false);
            filterUpperTable.gameObject.SetActive(true);
            UpperCheck = true;
        }
    }
}
