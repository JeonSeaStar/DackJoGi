using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBottle : MonoBehaviour
{
    public float tilt;
    public float tiltTime = 0;
    public bool oilFilterClose;
    public GameObject particle;
    public GameObject[] chage;
    public OVRPlayerController playerController; 
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("OilFilter"))
        {
            oilFilterClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("OilFilter"))
        {
            oilFilterClose = false;
        }
    }

    private void Update() // --> 스테이로 변경 가능
    {
        tilt = transform.rotation.eulerAngles.z;
        if (tilt > 70f && tilt < 280f && oilFilterClose)// 기울기 왼쪽이 : 70 +- 5도, 오른쪽이 : 280 +- 5도
        {
            particle.SetActive(true);
            tiltTime = Time.deltaTime;
            if(tiltTime == 2f)
            {
                chage[0].SetActive(false);
                chage[1].SetActive(true);
                
                playerController.oilFull = true;
                playerController.oilFilterGuideObject[5].SetActive(false);
                playerController.oilFilterGuideObject[6].SetActive(false);
                playerController.oilFilterGuideObject[7].SetActive(true);
                playerController.oilFilterGuideObject[8].SetActive(true);
            }

        }
        else
        {
            particle.SetActive(false);
        }
    }
}
