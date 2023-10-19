using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestOilFilterOpen : MonoBehaviour
{
    public OVRPlayerController playerController;
    public RequestOilHandle handle;
    public float time;
    public GameObject[] chage;
    public Animator animator;
    public GameObject dirtyParticle;
    public GameObject dirtyObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (playerController.handGrapL || playerController.handGrapR)
            {
                time += Time.deltaTime;
                if(time >= 3f)
                {
                    animator.SetTrigger("Start");
                    Invoke("Chage", 2.1f);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("RequestOilFilterOpen"))
        {
            if(!handle.handle)
            {
                dirtyObject.SetActive(true);
                dirtyParticle.SetActive(true);
            }
        }
    }

    public void Chage()
    {
        time = 0;
        chage[0].SetActive(false);
        chage[1].SetActive(true);
    }

    public void Dirty()
    {
        if(dirtyObject.activeSelf)
        {
            //점수까기
        }
    }

    public void HandleClose()
    {
        if(!handle.handle)
        {
            //점수까기
        }
    }
}
