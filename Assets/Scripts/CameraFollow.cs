using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tank;
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        float smoothSpeed = 5f;
        Vector3 targetPosition = tank.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
