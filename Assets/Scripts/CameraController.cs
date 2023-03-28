using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] int maxCameraDistance;
    [SerializeField] int minCameraDistance;
    private CinemachineComponentBase cinemachineComponentBase;

    void Update()
    {
        if (cinemachineComponentBase == null)
        {
            cinemachineComponentBase = cinemachineVirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }
        HandleMovement();
        HandleZoom();
        HandleRotation();

    }

    private void HandleZoom()
    {
        var mouseWheelInput = Input.mouseScrollDelta.y;
        var cameraDistance = (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance;
        
        if (mouseWheelInput == 0 || 
            (cameraDistance <= minCameraDistance && mouseWheelInput == 1) || 
            (cameraDistance > maxCameraDistance && mouseWheelInput == -1))
        {
            return;
        }

        if (cinemachineComponentBase is CinemachineFramingTransposer)
        {
            (cinemachineComponentBase as CinemachineFramingTransposer).m_CameraDistance -= mouseWheelInput * movementSpeed;
        }
    }

    private void HandleRotation()
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y += 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y -= 1f;
        }

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z -= 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x += 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x -= 1f;
        }

        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * movementSpeed * Time.deltaTime;
    }
}

