using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverWash4 : MonoBehaviour
{
    public bool coverWashCheck4 = false;
    public GameObject dirty4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            coverWashCheck4 = true;
            dirty4.SetActive(false);
        }
    }
}
