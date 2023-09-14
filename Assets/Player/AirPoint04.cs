using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint04 : MonoBehaviour
{
    public bool airPointCheck04;
    public GameObject dirty4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck04 = true;
            dirty4.SetActive(false);
        }
    }
}
