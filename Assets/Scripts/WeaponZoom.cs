using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomInSensitivity = 2f;
    [SerializeField] float zoomOutSensitivity = .5f;

    bool zoomedInToggle = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
                fpsController.RotationSpeed = zoomInSensitivity;
            }

            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
                fpsController.RotationSpeed = zoomOutSensitivity;
            }
        }
    }


}
