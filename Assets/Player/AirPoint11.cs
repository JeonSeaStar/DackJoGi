using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint11 : MonoBehaviour
{
    public bool airPointCheck11;
    public GameObject dirty11;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck11 = true;
            dirty11.SetActive(false);
        }
    }
}
