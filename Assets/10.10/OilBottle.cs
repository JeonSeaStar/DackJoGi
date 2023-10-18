using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBottle : MonoBehaviour
{
    public float tilt;
    public float tiltTime = 0;
    public bool oilFilterClose;
    public ParticleSystem particle;
    public GameObject[] chage;

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

    private void Update() // --> �����̷� ���� ����
    {
        tilt = transform.rotation.eulerAngles.z;
        if (tilt > 70f && tilt < 280f && oilFilterClose)// ���� ������ : 70 +- 5��, �������� : 280 +- 5��
        {
            
            tiltTime = Time.deltaTime;
            if(tiltTime == 2f)
            {
                chage[0].SetActive(false);
                chage[1].SetActive(true);
            }

        }
    }
}
