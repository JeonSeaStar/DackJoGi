using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeyGlasses : MonoBehaviour
{
    public OVRPlayerController playerController;
    public GameObject me;
    public GameObject eyeDirty;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Head"))
        {
            playerController.isSafey = true;
            me.SetActive(false);
            eyeDirty.SetActive(false);
        }
    }
}
