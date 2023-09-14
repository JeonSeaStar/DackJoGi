using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint03 : MonoBehaviour
{
    public bool airPointCheck03;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck03 = true;
        }
    }
}
