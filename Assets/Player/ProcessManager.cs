using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    public TableUpperChecker upperChecker;
    public TableInnerChecker innerChecker;

    public GameObject beforeTable;
    public GameObject afterTable;
    public GameObject afterOBJ1;
    public GameObject afterOBJ2;

    public GameObject[] processOBJ;

    public FilterInnerChecker filterInner;
    public GameObject innerAfter;
    public FilterUpperCheck upperCheck;
    public GameObject upperAfter;

    public ProcessFour processFour;

    public void Update()
    {
       
        if(upperChecker.UpperCheck == true)
        {
            processOBJ[0].gameObject.SetActive(false);
            if (afterTable.gameObject.activeSelf == true)
            {
                processOBJ[5].gameObject.SetActive(false);
            }
            else
            {
                processOBJ[5].gameObject.SetActive(true);
            }
            
            processOBJ[1].gameObject.SetActive(true);
        }

        if(innerChecker.InnerCheck == true)
        {
            processOBJ[1].gameObject.SetActive(false);
            processOBJ[2].gameObject.SetActive(true);

            afterTable.gameObject.SetActive(true);
            if(filterInner.filterInnerCheck == true)
            {
                afterOBJ1.gameObject.SetActive(false);
            }
            else
            {
                afterOBJ1.gameObject.SetActive(true);
            }
            
            if(upperCheck.filterUpperCheck)
            {
                afterOBJ2.gameObject.SetActive(false);
            }
            else
            {
                afterOBJ2.gameObject.SetActive(true);
            }
            
        }

        if(filterInner.filterInnerCheck == true)
        {
            processOBJ[2].SetActive(false);
            processOBJ[3].SetActive(true);
        }

        if(upperCheck.filterUpperCheck == true && processFour.buckleChecker)
        {
            processOBJ[3].SetActive(false);
            processOBJ[4].SetActive(true);
        }



        

        

        
    }
}
