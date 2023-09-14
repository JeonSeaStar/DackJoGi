using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashPoint3 : MonoBehaviour
{
    public bool washP3 = false;
    public GameObject dirty3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            washP3 = true;
            dirty3.SetActive(false);
        }
    }
}
