using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestOilHandle : MonoBehaviour
{
    public float time;
    public Animator animator;
    public OVRPlayerController controller;
    public bool handle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                handle = true;
                animator.SetTrigger("Start");
            }
        }
    }
}
