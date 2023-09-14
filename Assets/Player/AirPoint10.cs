using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPoint10 : MonoBehaviour
{
    public bool airPointCheck10;
    public GameObject dirty10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Air"))
        {
            airPointCheck10 = true;
            dirty10.SetActive(false);
        }
    }
}
