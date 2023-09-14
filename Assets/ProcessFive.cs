using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessFive : MonoBehaviour
{
    public SelectUI selectUI;

    public void Awake()
    {
        selectUI.NextGuide();
    }
}
