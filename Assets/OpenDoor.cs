using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject filterDoor;
    public float tilt;
    public HingeJoint joint;
    private void Update()
    {
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.8f)
        {
            Debug.Log("왼쪽 그립 작동 확인");
        }
        
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.8f)
        {
            Debug.Log("오른쪽 그립 작동 확인");
        }

        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.8f)
        {
            Debug.Log("왼쪽 트리거 작동 확인");
        }

        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.8f)
        {
            Debug.Log("오른쪽 트리거 작동 확인");
        }

        if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.8f && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.8f)
        {
            OVRInput.SetControllerVibration(.3f, .3f, OVRInput.Controller.LHand);
            
        }

        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.8f && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.8f)
        {
            OVRInput.SetControllerVibration(.3f, .3f, OVRInput.Controller.RHand);
        }

        if(joint.limits.min > 0)
        {

        }
        //최상위 오브젝트에 그랩어블 사용하고 리지드 넣어주면 작동가능할 듯

    }
}
