using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverWash3 : MonoBehaviour
{
    public bool coverWashCheck3 = false;
    public GameObject dirty3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            coverWashCheck3 = true;
            dirty3.SetActive(false);
        }
    }
}
