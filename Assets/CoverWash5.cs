using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverWash5 : MonoBehaviour
{
    public bool coverWashCheck5 = false;
    public GameObject dirty5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HandTowal"))
        {
            coverWashCheck5 = true;
            dirty5.SetActive(false);
        }
    }
}
