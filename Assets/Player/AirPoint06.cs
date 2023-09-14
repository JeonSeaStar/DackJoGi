using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint06 : MonoBehaviour
{
    public bool airPointCheck06;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck06 = true;
        }
    }
}
