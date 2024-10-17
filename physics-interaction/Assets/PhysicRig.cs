using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicRig : MonoBehaviour
{
    public Transform playerHead;
    public Transform leftController;
    public Transform rightController;

    public ConfigurableJoint headJoint;
    public ConfigurableJoint leftHandJoint;
    public ConfigurableJoint rightHandJoint;

    public CapsuleCollider bodyCollider;

    public float bodyHeightMin = 0.5f;
    public float bodyHeightMax = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Adjust body height and center based on the head's Y position
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(playerHead.localPosition.x, bodyCollider.height / 2, playerHead.localPosition.z);

        // Apply positions and rotations relative to joint anchors
        leftHandJoint.targetPosition = leftController.localPosition - leftHandJoint.anchor;
        leftHandJoint.targetRotation = leftController.localRotation;

        rightHandJoint.targetPosition = rightController.localPosition - rightHandJoint.anchor;
        rightHandJoint.targetRotation = rightController.localRotation;

        headJoint.targetPosition = playerHead.localPosition - headJoint.anchor;
    }
}