using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomHandler : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam;

    [SerializeField]
    private float zoomStep, minCamSize, maxCamSize;
    // Update is called once per frame
    void Start()
    {
        cam.m_Lens.OrthographicSize = 5f;
    }
    private void Update()
    {
        ZoomIn();
        ZoomOut();
    }

    private void ZoomIn()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            float zoomAmount = (cam.m_Lens.OrthographicSize + zoomStep);
            cam.m_Lens.OrthographicSize = Mathf.Clamp(zoomAmount, minCamSize, maxCamSize);
        }
    }

    private void ZoomOut()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            float zoomAmount = (cam.m_Lens.OrthographicSize - zoomStep);
            cam.m_Lens.OrthographicSize = Mathf.Clamp(zoomAmount, minCamSize, maxCamSize);
        }
        
    }
}
