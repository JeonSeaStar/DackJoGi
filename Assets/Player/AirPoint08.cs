using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint08 : MonoBehaviour
{
    public bool airPointCheck08;
    public GameObject dirty8;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck08 = true;
            dirty8.SetActive(false);
        }
    }
}
