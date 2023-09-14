using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashPoint1 : MonoBehaviour
{
    public bool washP1 = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("HandTowal"))
        {
            washP1 = true;
        }
    }
}
