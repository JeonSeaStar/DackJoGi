using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverWash7 : MonoBehaviour
{
    public bool coverWashCheck7 = false;
    public GameObject dirty7;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("HandTowal"))
        {
            coverWashCheck7 = true;
            dirty7.SetActive(false);
        }
    }
}
