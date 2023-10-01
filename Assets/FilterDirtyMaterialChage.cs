using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterDirtyMaterialChage : MonoBehaviour
{
    public OVRPlayerController controller;
    public float changeMatFloat;

    private void Start()
    {
        changeMatFloat = controller.filterDirtyMat.GetFloat("_DetailAlbedoAdjustment");
        controller = GetComponent<OVRPlayerController>();
    }

    private void OnDisable()
    {
        changeMatFloat += 0.1f;
        controller.filterDirtyMat.SetFloat("_DetailAlbedoAdjustment", changeMatFloat);
    }

}
