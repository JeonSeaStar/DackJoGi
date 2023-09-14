using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterUpperProcess : MonoBehaviour
{
    public WashPoint1 wP1;
    public WashPoint2 wP2;
    public WashPoint3 wP3;
    public WashPoint4 wP4;

    public bool washClear = false;

    public GameObject tableCol;


    public void Update()
    {
        CheckAllClear();
        
    }

    public void CheckAllClear()
    {
        if(wP1.washP1 && wP2.washP2 && wP3.washP3 && wP4.washP4)
        {
            washClear = true;
            tableCol.gameObject.SetActive(true);
        }
    }

    
}
