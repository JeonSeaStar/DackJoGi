using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUpper : MonoBehaviour
{
    public GameObject checker;

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == checker)
        {
            SelectUI.instance.NextHighLight();
            checker.SetActive(false);
        }
    }
}
