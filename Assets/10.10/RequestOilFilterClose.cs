using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestOilFilterClose : MonoBehaviour
{
    public OVRPlayerController playerController;

    public GameObject[] chage;
    public Animator animator;
    public float time;


    private void OnTriggerEnter(Collider other)
    {
        if(playerController.greaseCheck)
        {
            //점수 업
        }
        if(playerController.oilFull)
        {
            //점수 업
        }
        if(other.CompareTag("OilFilter"))
        {
            chage[0].SetActive(false);
            chage[1].SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!playerController.OilFilterRequest02Pass)
        {
            if (other.CompareTag("Hand"))
            {
                if (chage[1].activeSelf)
                {
                    if (playerController.handGrapL || playerController.handGrapR)
                    {
                        time += Time.deltaTime;
                        if (time >= 3f)
                        {
                            animator.SetTrigger("Start");
                            playerController.OilFilterRequest02Pass = true;
                        }
                    }
                }
            }
        }
    }
}
