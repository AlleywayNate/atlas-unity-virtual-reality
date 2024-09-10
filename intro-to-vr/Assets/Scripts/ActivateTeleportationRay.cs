using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject leftTeleportationRay;
    public GameObject rightTeleportationRay;

    public InputActionProperty leftActivateAction;
    public InputActionProperty rightActivateAction;

    void Update ()
    {
        leftTeleportationRay.SetActive(leftActivateAction.action.IsPressed());
        rightTeleportationRay.SetActive(rightActivateAction.action.IsPressed());
    }
}
