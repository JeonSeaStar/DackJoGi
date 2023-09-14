using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint04 : MonoBehaviour
{
    public bool airPointCheck04;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck04 = true;
        }
    }
}
