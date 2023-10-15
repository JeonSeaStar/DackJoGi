using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDirtyMaterialChage : MonoBehaviour
{
    public OVRPlayerController controller;
    public float changeMatFloat;

    void Start()
    {
        changeMatFloat = controller.baseDirtyMat.GetFloat("_DetailAlbedoAdjustment");
        controller = GetComponent<OVRPlayerController>();
    }

    private void OnDisable()
    {
        changeMatFloat += 0.12f;
        controller.baseDirtyMat.SetFloat("_DetailAlbedoAdjustment", changeMatFloat);
    }
}
