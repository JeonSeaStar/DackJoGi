using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDestory : MonoBehaviour
{
    public GameObject innerCheck;
    public GameObject tableBefore;

    private void Update()
    {
        if(innerCheck.gameObject.activeSelf == true)
        {
            tableBefore.gameObject.SetActive(false);
        }
    }
    //tablebefore �������� + �̳�üũ ������ ��� �ִ� �̳� ������� �ϱ�
}
