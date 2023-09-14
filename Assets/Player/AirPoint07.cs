using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint07 : MonoBehaviour
{
    public bool airPointCheck07;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck07 = true;
        }
    }
}
