using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInnerChecker : MonoBehaviour
{
    public GameObject filterInner;
    public GameObject filterInnerTable;
    public FilterInnerProcess innerProcess;

    public bool InnerCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if(innerProcess.AirCheckClearBool == true)
        {
            if (other.CompareTag("FilterInner"))
            {
                filterInner.gameObject.SetActive(false);
                filterInnerTable.gameObject.SetActive(true);
                InnerCheck = true;
            }
        }
    }
}
