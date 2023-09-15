using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessFive : MonoBehaviour
{
    public SelectUI selectUI;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public void Awake()
    {
        selectUI.NextGuide();
        door1.SetActive(false);
        door2.SetActive(true);
        door3.SetActive(false);
    }
}
