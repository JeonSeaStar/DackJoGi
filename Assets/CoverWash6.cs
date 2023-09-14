using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverWash6 : MonoBehaviour
{
    public bool coverWashCheck6 = false;
    public GameObject dirty6;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            coverWashCheck6 = true;
            dirty6.SetActive(false);
        }
    }
}
