using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint02 : MonoBehaviour
{
    public bool airPointCheck02;
    public GameObject dirty2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck02 = true;
            dirty2.SetActive(false);
        }
    }
}
