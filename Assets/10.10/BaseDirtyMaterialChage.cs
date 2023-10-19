using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDirtyMaterialChage : MonoBehaviour
{
    public OVRPlayerController controller;
    public float changeMatFloat;

    private void OnDisable()
    {
        changeMatFloat = controller.upperDirtyMat.GetFloat("_DetailAlbedoAdjustment");
        changeMatFloat += 0.12f;
        controller.upperDirtyMat.SetFloat("_DetailAlbedoAdjustment", changeMatFloat);

    }
}
