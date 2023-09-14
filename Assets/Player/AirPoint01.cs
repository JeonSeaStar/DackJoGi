using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint01 : MonoBehaviour
{
    public bool airPointCheck01;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Air"))
        {
            airPointCheck01 = true;
        }
    }

}
