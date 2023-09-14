using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashPoint4 : MonoBehaviour
{
    public bool washP4 = false;
    public GameObject dirty4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            washP4 = true;
            dirty4.SetActive(false);
        }
    }
}
