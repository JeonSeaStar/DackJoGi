using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDirtyCleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AirDirty"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
