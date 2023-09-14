using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterInnerProcess : MonoBehaviour
{
    public AirPoint01 ap1;
    public AirPoint02 ap2;
    public AirPoint03 ap3;
    public AirPoint04 ap4;
    public AirPoint05 ap5;
    public AirPoint06 ap6;
    public AirPoint07 ap7;
    public AirPoint08 ap8;
    public AirPoint09 ap9;
    public AirPoint10 ap10;
    public AirPoint11 ap11;
    public AirPoint12 ap12;

    public GameObject tableCol;

    public bool AirCheckClearBool = false;

    public void Update()
    {
        AirClearCheck();
    }

    public void AirClearCheck()
    {
        if(ap1.airPointCheck01 && ap2.airPointCheck02 && ap3.airPointCheck03 && ap4.airPointCheck04 && ap5.airPointCheck05
            && ap6.airPointCheck06 && ap7.airPointCheck07 && ap8.airPointCheck08 && ap9.airPointCheck09 && ap10.airPointCheck10 
            && ap11.airPointCheck11 && ap12.airPointCheck12)
        {
            AirCheckClearBool = true;
            tableCol.gameObject.SetActive(true);
        }
    }
}
