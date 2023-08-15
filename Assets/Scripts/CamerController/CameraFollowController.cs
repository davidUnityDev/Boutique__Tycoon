using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 

    public Vector3 offset; 
    [SerializeField] private Transform leftBoundary, bottomBoundary, rightBoundary, topBoundary;
    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, leftBoundary.position.x, rightBoundary.position.x);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, bottomBoundary.position.y, topBoundary.position.y);

        transform.position = smoothedPosition;
    }
}
