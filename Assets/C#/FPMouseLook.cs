using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMouseLook : MonoBehaviour
{//实现第一人称摄像机的上下左右旋转
    private Transform cameraTransform;
    [SerializeField] private Transform characterTransform;
    private Vector3 cameraRotation;
    public float MouseSensitivity;
    public Vector2 MaxminAngle;

    private void Start()
    {
        cameraTransform = transform;
    }

    void Update()
    {
        var tmp_MouseX = Input.GetAxis("Mouse X");
        var tmp_MouseY = Input.GetAxis("Mouse Y");
        cameraRotation.x -= tmp_MouseY * MouseSensitivity;
        cameraRotation.y += tmp_MouseX * MouseSensitivity;

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, MaxminAngle.x, MaxminAngle.y);

        cameraTransform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0);
        characterTransform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
    }
}
