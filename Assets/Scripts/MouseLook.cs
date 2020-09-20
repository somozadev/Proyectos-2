using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public GameObject camerasParent;         // Parent object of all cameras that should rotate with mouse
    public float hRotationSpeed = 100f;      // Player rotates along y axis
    public float vRotationSpeed = 80f;       // Cam rotates along x axis
    public float maxVerticalAngle;           // maximun rotation along x axis
    public float minVerticalAngle;           // minimum rotation along x axis
    public float smoothTime = 0.05f;

    float vCamRotationAngles;                // variable to apply Vertical Rotation
    float hPlayerRotation;                   // variable to apply Horizontal Rotation
    float currentHVelocity;                  // smooth horizonal velocity
    float currentVVelocity;                  // smooth vertica velocity
    float targetCamEulers;                   // variable to accumulate the eurler angles along x axis
    Vector3 targetCamRotation;               /* aux variable to store the targetRotation of the 
                                             camerasParent avoiding to instatiate a new Vector 3 every Frame */
    public float verticalAxis { get; set; }
    public float horizontalAxis { get; set; }

    void Start()
    {
        // Hide and lock mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        // Get Mouse input
        targetCamEulers += verticalAxis * vRotationSpeed * Time.deltaTime;
        float targetPlayerRotation = horizontalAxis * hRotationSpeed * Time.deltaTime;

        // Player Rotation
        hPlayerRotation = Mathf.SmoothDamp(hPlayerRotation, targetPlayerRotation, ref currentHVelocity, smoothTime);
        transform.Rotate(0f, hPlayerRotation, 0f);

        //Cam Rotation
        targetCamEulers = Mathf.Clamp(targetCamEulers, minVerticalAngle, maxVerticalAngle);
        vCamRotationAngles = Mathf.SmoothDamp(vCamRotationAngles, targetCamEulers, ref currentVVelocity, smoothTime);

        targetCamRotation.Set(-vCamRotationAngles, 0f, 0f);
        camerasParent.transform.localEulerAngles = targetCamRotation;
    }
}
