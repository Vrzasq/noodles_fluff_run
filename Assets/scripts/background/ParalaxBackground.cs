using System;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float paralaxEffect = 0.5f;

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
            throw new NullReferenceException($"{nameof(cameraTransform)} is null");

        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * paralaxEffect;
        lastCameraPosition = cameraTransform.position;
    }

}
