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
    //tablebefore 안지워짐 + 이너체크 넣으면 들고 있는 이너 사라지게 하기
}
