using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverWash2 : MonoBehaviour
{
    public bool coverWashCheck2 = false;
    public GameObject dirty2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            coverWashCheck2 = true;
            dirty2.SetActive(false);
        }
    }
}
