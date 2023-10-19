using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterDirtyMaterialChage : MonoBehaviour
{
    public OVRPlayerController controller;
    public float changeMatFloat;
    public GameObject eyeDirty;

    private void OnDisable()
    {
        changeMatFloat = controller.upperDirtyMat.GetFloat("_DetailAlbedoAdjustment");
        changeMatFloat += 0.1f;
        controller.upperDirtyMat.SetFloat("_DetailAlbedoAdjustment", changeMatFloat);
        if(!controller.isSafey)
        {
            eyeDirty.SetActive(true);
        }
    }

}
