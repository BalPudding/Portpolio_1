using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public bool isHorizontal;
    public float cameraY = 0f;
    public bool cameraMoving_00;
    public float changeRocate;
    bool reaperCam;

    public GameObject player;

    private void Update()
    {
        if(transform.position.x >= 411 && reaperCam ==false)
        {
            reaperCam = true;
            isHorizontal = false;
            transform.position = new Vector3(411, -41,-10);
        }
        if (isHorizontal == true)
        {
            Vector3 dir = player.transform.position - this.transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, cameraY * Time.deltaTime, 0.0f);
            this.transform.Translate(moveVector);
        }
        if (cameraMoving_00 == true)
        {
            cameraY = -5;
            if (transform.position.y <= changeRocate)
            {
                cameraMoving_00 = false;
                cameraY = 0;
            }
        }
    }
    public void ReaperCam()
    {
        transform.position = new Vector3(438, -41,-10);
    }
}