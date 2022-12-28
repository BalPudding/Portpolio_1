using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject cam;
    
    Camera wallCam;
    Vector3 screenCenter;
    private void Awake()
    {
        wallCam = cam.GetComponent<Camera>();    
    }
    void Start()
    {
        screenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    void Update()
    {
        transform.LookAt(screenCenter);
    }
}
