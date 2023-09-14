using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint09 : MonoBehaviour
{
    public bool airPointCheck09;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck09 = true;
        }
    }
}
