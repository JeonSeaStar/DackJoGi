using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint05 : MonoBehaviour
{
    public bool airPointCheck05;
    public GameObject dirty5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck05 = true;
            dirty5.SetActive(false);
        }
    }
}
