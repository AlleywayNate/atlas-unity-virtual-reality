using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportationRay;
    public GameObject rightTeleportationRay;

    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    public XRRayInteractor leftRay; 
    public XRRayInteractor rightRay; 

    void Update ()
    {
        bool isleftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftHitPosition, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        leftTeleportationRay.SetActive(isleftRayHovering && leftCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() == 0.1f);
        
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightHitPosition, out Vector3 rightNormal, out int rightNmber, out bool rightValid);
        rightTeleportationRay.SetActive(isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() == 0.1f);

    }
}
