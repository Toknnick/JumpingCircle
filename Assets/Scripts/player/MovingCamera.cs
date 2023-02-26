using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    private Transform target;
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    
    public void SetTartget(Transform target)
    {
        this.target = target;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
