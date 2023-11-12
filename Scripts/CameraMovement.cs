using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;
    private Vector3 dragOrigin;
    private float zoom = 1.5f;
    private GameObject BuildMenu;

    private void Awake() 
    {
        BuildMenu = GameObject.Find("BuildMenu");
    }

    private void Start() 
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // prevent movement if build menu is open
        if (BuildMenu.activeSelf) {return;}

        PanCamera();
        ZoomCamera();
    }

    private Vector3 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = GetMousePosition();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - GetMousePosition();
            cam.transform.position += difference;
        }
    }

    private void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") == 0) {return;}

        if (0.1 < cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoom)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
    }
}
