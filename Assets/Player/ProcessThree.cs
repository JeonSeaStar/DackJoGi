using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessThree : MonoBehaviour
{
    public FilterInnerChecker innerChecker;

    public GameObject beforeInnerFilter;
    public GameObject afterInnerFilter;

    public bool coverWashCheck = false;

    public CoverWash1 cover1;
    public CoverWash2 cover2;
    public CoverWash3 cover3;
    public CoverWash4 cover4;
    public CoverWash5 cover5;
    public CoverWash6 cover6;
    public CoverWash7 cover7;



    public void Update()
    {
        CoverClearCheck();
        if(coverWashCheck == true)
        Check();

    }

    public void Check()
    {
        if(innerChecker.filterInnerCheck == true)
        {
            beforeInnerFilter.gameObject.SetActive(false);
            afterInnerFilter.gameObject.SetActive(true);
        }
    }
    
    public void CoverClearCheck()
    {
        if(cover1.coverWashCheck1 && cover2.coverWashCheck2 && cover3.coverWashCheck3 && cover4.coverWashCheck4
            && cover5.coverWashCheck5 && cover6.coverWashCheck6 && cover7.coverWashCheck7)
        {
            coverWashCheck = true;
        }
    }
}
