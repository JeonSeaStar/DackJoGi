using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUpperChecker : MonoBehaviour
{
    public GameObject filterUpper;
    public GameObject filterUpperTable;
    public FilterUpperProcess upperProcess;
    public bool UpperCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if(upperProcess.washClear == true)
        {
            if (other.CompareTag("FilterUpper"))
            {
                filterUpper.gameObject.SetActive(false);
                filterUpperTable.gameObject.SetActive(true);
                UpperCheck = true;
                SelectUI.instance.NextHighLight();
            }
        }
    }
}
