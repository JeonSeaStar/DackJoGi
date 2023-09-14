using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashPoint2 : MonoBehaviour
{
    public bool washP2 = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            washP2 = true;
        }
    }
}
