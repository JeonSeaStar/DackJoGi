using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDes : MonoBehaviour
{
    public GameObject checker;

    private void Update()
    {
        if(checker.gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }
}
