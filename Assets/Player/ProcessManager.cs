using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    public TableUpperChecker upperChecker;
    public TableInnerChecker innerChecker;

    public GameObject beforeTable;
    public GameObject afterTable;

    public GameObject[] processOBJ;

    public void Update()
    {
        if(upperChecker.UpperCheck == true)
        {
            processOBJ[0].gameObject.SetActive(false);
            processOBJ[1].gameObject.SetActive(true);
        }

        if(innerChecker.InnerCheck == true)
        {
            processOBJ[1].gameObject.SetActive(false);
            processOBJ[2].gameObject.SetActive(true);

            beforeTable.gameObject.SetActive(false);
            afterTable.gameObject.SetActive(true);
        }

        

        

        
    }
}
