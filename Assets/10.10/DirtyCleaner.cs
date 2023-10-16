using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyCleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dirty"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
