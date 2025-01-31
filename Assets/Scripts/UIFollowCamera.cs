using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        transform.position = cameraTransform.position;
    }
}