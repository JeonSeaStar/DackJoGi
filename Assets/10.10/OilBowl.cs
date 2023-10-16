using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBowl : MonoBehaviour
{
    public OVRPlayerController playerController;
    public GameObject[] chage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OilBowlCkeck"))
        {
            playerController.oilBowlSet = true;
            chage[0].SetActive(false);
            chage[1].SetActive(true);
        }
    }
}
