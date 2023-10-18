/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Codice.CM.Triggers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRHand : MonoBehaviour,
    OVRSkeleton.IOVRSkeletonDataProvider,
    OVRSkeletonRenderer.IOVRSkeletonRendererDataProvider,
    OVRMesh.IOVRMeshDataProvider,
    OVRMeshRenderer.IOVRMeshRendererDataProvider
{
    public enum Hand
    {
        None = OVRPlugin.Hand.None,
        HandLeft = OVRPlugin.Hand.HandLeft,
        HandRight = OVRPlugin.Hand.HandRight,
    }

    public enum HandFinger
    {
        Thumb = OVRPlugin.HandFinger.Thumb,
        Index = OVRPlugin.HandFinger.Index,
        Middle = OVRPlugin.HandFinger.Middle,
        Ring = OVRPlugin.HandFinger.Ring,
        Pinky = OVRPlugin.HandFinger.Pinky,
        Max = OVRPlugin.HandFinger.Max,
    }

    public enum TrackingConfidence
    {
        Low = OVRPlugin.TrackingConfidence.Low,
        High = OVRPlugin.TrackingConfidence.High
    }

    [SerializeField]
    private Hand HandType = Hand.None;

    internal void SetHandType(Hand type)
    {
        HandType = type;
    }

    [SerializeField]
    private Transform _pointerPoseRoot = null;

    /// <summary>
    /// Determines if the controller should be hidden based on held state.
    /// </summary>
    public OVRInput.InputDeviceShowState m_showState = OVRInput.InputDeviceShowState.ControllerNotInHand;

    private GameObject _pointerPoseGO;
    private OVRPlugin.HandState _handState = new OVRPlugin.HandState();


    public bool IsDataValid { get; private set; }
    public bool IsDataHighConfidence { get; private set; }
    public bool IsTracked { get; private set; }
    public bool IsSystemGestureInProgress { get; private set; }
    public bool IsPointerPoseValid { get; private set; }
    public Transform PointerPose { get; private set; }
    public float HandScale { get; private set; }
    public TrackingConfidence HandConfidence { get; private set; }
    public bool IsDominantHand { get; private set; }

    private void Awake()
    {
        _pointerPoseGO = new GameObject();
        PointerPose = _pointerPoseGO.transform;
        if (_pointerPoseRoot != null)
        {
            PointerPose.SetParent(_pointerPoseRoot, false);
        }

        GetHandState(OVRPlugin.Step.Render);
    }

    private void Start()
    {
        controller = GetComponent<OVRPlayerController>();
    }

    private void Update()
    {
        GetHandState(OVRPlugin.Step.Render);
    }

    private void FixedUpdate()
    {
        if (OVRPlugin.nativeXrApi != OVRPlugin.XrApi.OpenXR)
        {
            GetHandState(OVRPlugin.Step.Physics);
        }
    }

    private void GetHandState(OVRPlugin.Step step)
    {
        if (OVRPlugin.GetHandState(step, (OVRPlugin.Hand)HandType, ref _handState))
        {
            IsTracked = (_handState.Status & OVRPlugin.HandStatus.HandTracked) != 0;
            IsSystemGestureInProgress = (_handState.Status & OVRPlugin.HandStatus.SystemGestureInProgress) != 0;
            IsPointerPoseValid = (_handState.Status & OVRPlugin.HandStatus.InputStateValid) != 0;
            IsDominantHand = (_handState.Status & OVRPlugin.HandStatus.DominantHand) != 0;
            PointerPose.localPosition = _handState.PointerPose.Position.FromFlippedZVector3f();
            PointerPose.localRotation = _handState.PointerPose.Orientation.FromFlippedZQuatf();
            HandScale = _handState.HandScale;
            HandConfidence = (TrackingConfidence)_handState.HandConfidence;

            IsDataValid = true;
            IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;

            // Hands cannot be doing pointer poses or system gestures when they are holding controllers
            //OVRInput.Hand inputHandType = (HandType == Hand.)
            OVRInput.ControllerInHandState controllerInHandState =
                OVRInput.GetControllerIsInHandState((OVRInput.Hand)HandType);
            if (controllerInHandState == OVRInput.ControllerInHandState.ControllerInHand)
            {
                // This hand is holding a controller
                IsSystemGestureInProgress = false;
                IsPointerPoseValid = false;
            }

            switch (m_showState)
            {
                case OVRInput.InputDeviceShowState.Always:
                    // intentionally blank
                    break;
                case OVRInput.InputDeviceShowState.ControllerInHandOrNoHand:
                    if (controllerInHandState == OVRInput.ControllerInHandState.ControllerNotInHand)
                    {
                        IsDataValid = false;
                    }
                    break;
                case OVRInput.InputDeviceShowState.ControllerInHand:
                    if (controllerInHandState != OVRInput.ControllerInHandState.ControllerInHand)
                    {
                        IsDataValid = false;
                    }
                    break;
                case OVRInput.InputDeviceShowState.ControllerNotInHand:
                    if (controllerInHandState != OVRInput.ControllerInHandState.ControllerNotInHand)
                    {
                        IsDataValid = false;
                    }
                    break;
                case OVRInput.InputDeviceShowState.NoHand:
                    if (controllerInHandState != OVRInput.ControllerInHandState.NoHand)
                    {
                        IsDataValid = false;
                    }
                    break;
            }
        }
        else
        {
            IsTracked = false;
            IsSystemGestureInProgress = false;
            IsPointerPoseValid = false;
            PointerPose.localPosition = Vector3.zero;
            PointerPose.localRotation = Quaternion.identity;
            HandScale = 1.0f;
            HandConfidence = TrackingConfidence.Low;

            IsDataValid = false;
            IsDataHighConfidence = false;
        }
    }

    public bool GetFingerIsPinching(HandFinger finger)
    {
        return IsDataValid && (((int)_handState.Pinches & (1 << (int)finger)) != 0);
    }

    public float GetFingerPinchStrength(HandFinger finger)
    {
        if (IsDataValid
            && _handState.PinchStrength != null
            && _handState.PinchStrength.Length == (int)OVRPlugin.HandFinger.Max)
        {
            return _handState.PinchStrength[(int)finger];
        }

        return 0.0f;
    }

    public TrackingConfidence GetFingerConfidence(HandFinger finger)
    {
        if (IsDataValid
            && _handState.FingerConfidences != null
            && _handState.FingerConfidences.Length == (int)OVRPlugin.HandFinger.Max)
        {
            return (TrackingConfidence)_handState.FingerConfidences[(int)finger];
        }

        return TrackingConfidence.Low;
    }

    OVRSkeleton.SkeletonType OVRSkeleton.IOVRSkeletonDataProvider.GetSkeletonType()
    {
        switch (HandType)
        {
            case Hand.HandLeft:
                return OVRSkeleton.SkeletonType.HandLeft;
            case Hand.HandRight:
                return OVRSkeleton.SkeletonType.HandRight;
            case Hand.None:
            default:
                return OVRSkeleton.SkeletonType.None;
        }
    }

    OVRSkeleton.SkeletonPoseData OVRSkeleton.IOVRSkeletonDataProvider.GetSkeletonPoseData()
    {
        var data = new OVRSkeleton.SkeletonPoseData();
        data.IsDataValid = IsDataValid;
        if (IsDataValid)
        {
            data.RootPose = _handState.RootPose;
            data.RootScale = _handState.HandScale;
            data.BoneRotations = _handState.BoneRotations;
            data.IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;
        }

        return data;
    }

    OVRSkeletonRenderer.SkeletonRendererData OVRSkeletonRenderer.IOVRSkeletonRendererDataProvider.
        GetSkeletonRendererData()
    {
        var data = new OVRSkeletonRenderer.SkeletonRendererData();

        data.IsDataValid = IsDataValid;
        if (IsDataValid)
        {
            data.RootScale = _handState.HandScale;
            data.IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;
            data.ShouldUseSystemGestureMaterial = IsSystemGestureInProgress;
        }

        return data;
    }


    OVRMesh.MeshType OVRMesh.IOVRMeshDataProvider.GetMeshType()
    {
        switch (HandType)
        {
            case Hand.None:
                return OVRMesh.MeshType.None;
            case Hand.HandLeft:
                return OVRMesh.MeshType.HandLeft;
            case Hand.HandRight:
                return OVRMesh.MeshType.HandRight;
            default:
                return OVRMesh.MeshType.None;
        }
    }

    OVRMeshRenderer.MeshRendererData OVRMeshRenderer.IOVRMeshRendererDataProvider.GetMeshRendererData()
    {
        var data = new OVRMeshRenderer.MeshRendererData();

        data.IsDataValid = IsDataValid;
        if (IsDataValid)
        {
            data.IsDataHighConfidence = IsTracked && HandConfidence == TrackingConfidence.High;
            data.ShouldUseSystemGestureMaterial = IsSystemGestureInProgress;
        }

        return data;
    }


    #region 내가 추가한 것------------------------------------------- 손 같은 경우 왼쪽 오른쪽에 따른 햅틱 필요해보임

    public OVRPlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BuckleClose1"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                //사운드 및 햅틱
                //controller.audioSource.PlayOneShot(controller.audioClips[0], 0.1f);
                //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RHand);
                controller.bucklesClose[0].gameObject.SetActive(false);
                controller.bucklesOpen[0].gameObject.SetActive(true);
            }
        }
        if (other.CompareTag("BuckleClose2"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

                controller.bucklesClose[1].gameObject.SetActive(false);
                controller.bucklesOpen[1].gameObject.SetActive(true);
            }
        }
        if (other.CompareTag("BuckleClose3"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

                controller.bucklesClose[2].gameObject.SetActive(false);
                controller.bucklesOpen[2].gameObject.SetActive(true);
            }
        }
        if (other.CompareTag("BuckleClose4"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

                controller.bucklesClose[3].gameObject.SetActive(false);
                controller.bucklesOpen[3].gameObject.SetActive(true);
            }
        }
        if (other.CompareTag("BuckleOpen1"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

                controller.bucklesClose[0].gameObject.SetActive(true);
                controller.bucklesOpen[0].gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("BuckleOpen2"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

                controller.bucklesClose[1].gameObject.SetActive(true);
                controller.bucklesOpen[1].gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("BuckleOpen3"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

                controller.bucklesClose[2].gameObject.SetActive(true);
                controller.bucklesOpen[2].gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("BuckleOpen4"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

                controller.bucklesClose[3].gameObject.SetActive(true);
                controller.bucklesOpen[3].gameObject.SetActive(false);
            }
        }
        if(other.CompareTag("Oring"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

            }
        }
        if (other.CompareTag("HandTowal"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

            }
        }
        if (other.CompareTag("BlowGun"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

            }
        }
        if (other.CompareTag("FilterInner"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {

            }
        }
        if (other.CompareTag("FilterUpper"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                controller.checkOrings[0].SetActive(false);
                controller.checkOrings[1].SetActive(true);
            }
        }
        
        //
        if (other.CompareTag("OilFilterValve"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                controller.oilFilterValveOff = true;
                controller.oilFilterValve.SetTrigger("Start");
                Invoke("OilProcess01", 1.1f);
            }
        }
        if (other.CompareTag("OilFilterValveClose"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                controller.oilFilterValveOn = true;
                controller.oilFilterValveClose.SetTrigger("Strat");
                Invoke("OilProcess05", 1.1f);
            }
        }

        if (other.CompareTag("OilGrease"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                controller.oilGreaseHand = true;
            }
        }
        if (other.CompareTag("OilFilterGrease"))
        {
            if (controller.oilGreaseHand)
            {
                controller.greaseCheck = true;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BuckleClose1") || other.CompareTag("BuckleClose2") || other.CompareTag("BuckleClose3") || other.CompareTag("BuckleClose4"))
        {
            CheckPreBuckels();
        }
        if (other.CompareTag("BukleOpen1") || other.CompareTag("BukleOpen2") || other.CompareTag("BukleOpen3") || other.CompareTag("BukleOpen4"))
        {
            CheckAfterBukels();
        }
        //굳이 나눌 필요?
        //if (other.CompareTag("FilterUpper"))
        //{
        //    if (controller.handGrapL || controller.handGrapR)
        //    {

        //    }
        //}

        if (other.CompareTag("HandTowal"))
        {
            CheckUpperDirty();
            CheckBaseDirty();
        }

        if (other.CompareTag("BlowGun"))
        {
            CheckFilterDirty();
        }


        //
        if (other.CompareTag("OilFilter"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                controller.oilFilterOffTime += Time.deltaTime;
                if (controller.oilFilterOffTime >= 3f)
                {
                    controller.oilFilterOff = true;
                    controller.oilFilterLoose.SetTrigger("Start");
                    Invoke("OilProcess02", 2.1f);
                }
                if (!controller.oilBowlSet && controller.oilFilterOff && !controller.oilDirtyCheck)
                {
                    controller.oilDirtyParticle.SetActive(true);
                    Invoke("OilDirty", 3f);
                }
            }
        }

        //
        if (other.CompareTag("NewOilFilter"))
        {
            if (controller.handGrapL || controller.handGrapR)
            {
                controller.oilFilterOnTime += Time.deltaTime;
                if(controller.oilFilterOnTime >= 3f)
                {
                    controller.oliFilterOn = true;
                    controller.oilFilterTight.SetTrigger("Start");
                    Invoke("OilProcess04", 2.1f);
                }
            }
        }

    }

    public void OilDirty()
    {
        controller.oilDirty.SetActive(true);
        controller.oilDirtyCheck = true;
        controller.oilDirtyParticle.SetActive(false);
    }

    private void CheckPreBuckels()
    {
        if (!controller.preBuckles)
        {
            for (int i = 0; i < controller.bucklesOpen.Length; i++)
            {
                if (controller.bucklesOpen[i].gameObject.activeSelf)
                {
                    controller.preBuckles = true;
                    controller.ProcessClear01();
                }
            }
        }
    }

    private void CheckAfterBukels()
    {
        if (controller.preBuckles)
        {
            for (int i = 0; i < controller.bucklesClose.Length; i++)
            {
                if (controller.bucklesClose[i].gameObject.activeSelf)
                {
                    controller.afterBuckles = true;
                    controller.ProcessClear08();
                }
            }
        }
    }

    private void CheckUpperDirty()
    {
        for(int i = 0; i < controller.upperDirtys.Length; i ++)
        {
            if (!controller.upperDirtys[i].gameObject.activeSelf)
            {
                controller.clearUpperDirty = true;
                controller.upperDirtyMat.SetFloat("_DetailScale", 0f);
            }
        }
    }
    
    private void CheckFilterDirty()
    {
        for (int i = 0; i < controller.airDirtys.Length ; i++)
        {
            if (!controller.airDirtys[i].gameObject.activeSelf)
            {
                controller.clearFilterDirty = true;
                controller.filterDirtyMat.SetFloat("_DetailScale", 0f);
            }
        }
    }

    private void CheckBaseDirty()
    {
        for (int i = 0; i < controller.baseDirtys.Length; i++)
        {
            if (!controller.baseDirtys[i].gameObject.activeSelf)
            {
                controller.clearBaseDirty = true;
                controller.baseDirtyMat.SetFloat("_DetailScale", 0f);
                if(!controller.airCompressorCheck)
                {
                    controller.ProcessClear04();
                    controller.ChangeTable();
                }
                else
                {
                    controller.PartProcessClear01();
                }
            }
        }
    }

    //오일프로세스
    public void OilProcess01()
    {
        controller.OilProcessClear01();
    }
    public void OilProcess02()
    {
        controller.OilProcessClear02();
    }
    public void OilProcess03() //DelOilFilter에서 넘겨줌
    {
        controller.OilProcessClear03();
    }
    public void OilProcess04()
    {
        controller.OilProcessClear04();
    }
    public void OilProcess05()
    {
        controller.OilProcessClear05();
    }


    #endregion
}
