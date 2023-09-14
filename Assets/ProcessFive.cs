using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessFive : MonoBehaviour
{
    public SelectUI selectUI;
    public GameObject door1;
    public GameObject door2;

    public void Awake()
    {
        selectUI.NextGuide();
        door1.SetActive(false);
        door2.SetActive(true);
    }
}
