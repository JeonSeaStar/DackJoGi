using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint12 : MonoBehaviour
{
    public bool airPointCheck12;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck12 = true;
        }
    }
}
