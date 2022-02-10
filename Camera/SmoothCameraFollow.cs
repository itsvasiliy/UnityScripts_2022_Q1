using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform targetTransform;

    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -5f);

    [SerializeField] private float smoothSpeed = 0.0125f;

    private void LateUpdate()
    {
        if (targetTransform != null)
        {
            Vector3 desiredPosition = targetTransform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed);

            cameraTransform.position = smoothedPosition;
        }
    }
}