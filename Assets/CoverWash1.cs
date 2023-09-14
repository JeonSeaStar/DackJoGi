using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverWash1 : MonoBehaviour
{
    public bool coverWashCheck1 = false;
    public GameObject dirty1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            coverWashCheck1  = true;
            dirty1.SetActive(false);
        }
    }
}
