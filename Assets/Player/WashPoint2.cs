using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashPoint2 : MonoBehaviour
{
    public bool washP2 = false;
    public GameObject dirty2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            washP2 = true;
            dirty2.SetActive(false);
        }
    }
}
