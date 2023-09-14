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
            Debug.Log("���� �׸� �۵� Ȯ��");
        }
        
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.8f)
        {
            Debug.Log("������ �׸� �۵� Ȯ��");
        }

        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.8f)
        {
            Debug.Log("���� Ʈ���� �۵� Ȯ��");
        }

        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.8f)
        {
            Debug.Log("������ Ʈ���� �۵� Ȯ��");
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
        //�ֻ��� ������Ʈ�� �׷���� ����ϰ� ������ �־��ָ� �۵������� ��

    }
}
