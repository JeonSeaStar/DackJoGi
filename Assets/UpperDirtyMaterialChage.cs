using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperDirtyMaterialChage : MonoBehaviour
{
    public OVRPlayerController controller;
    public float changeMatFloat;

    private void Start()
    {
        changeMatFloat = controller.upperDirtyMat.GetFloat("_DetailAlbedoAdjustment");
        controller = GetComponent<OVRPlayerController>();
    }

    private void OnDisable()
    {
        changeMatFloat += 0.15f;
        controller.upperDirtyMat.SetFloat("_DetailAlbedoAdjustment", changeMatFloat);
    }
}
