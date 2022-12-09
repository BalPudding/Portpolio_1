using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController instance = null;
    Camera camera;
    public float cameraSpeed = 5.0f;
    public bool isHorizontal;
    public float cameraY;
    public bool cameraMoving_00;
    public float changeRocate;
    bool phase2Cam;
    bool sector01;
    bool sector02;

    public GameObject player;
    public GameObject reaper;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        camera = GetComponent<Camera>();   
    }
    public static CameraController Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private void Update()
    {
        //2페이즈 캠
        Vector3 fixedReaperPos;
        fixedReaperPos = new Vector3(reaper.transform.position.x, reaper.transform.position.y, -10);
        if (phase2Cam == true)
        {
            camera.orthographicSize = 3;
            transform.position = Vector3.Lerp(transform.position, fixedReaperPos, 0.5f);
        }
        //1섹터 카메라 고정
        if (transform.position.x >= 174 && sector01 == false)
        {
            isHorizontal = false;
            sector01 = true;
            transform.position = new Vector3(174, 1, -10);
        }
        //2섹터 카메라 고정
        if (transform.position.x >= 371.5 && sector02 == false)
        {
            isHorizontal = false;
            sector02 = true;
            transform.position = new Vector3(371.5f, -40.8f, -10);
        }
        //섹터1 카메라 무빙
        if (cameraMoving_00 == true)
        {
            isHorizontal = false;
            transform.position = Vector3.Lerp(transform.position, new Vector3(174, -19, -10), 0.008f);
        }
        //카메라가 플레이어를 따라감
        if (isHorizontal == true)
        {
            Vector3 dir = player.transform.position - this.transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, cameraY * Time.deltaTime, 0.0f);
            this.transform.Translate(moveVector);
        }
        if(transform.position.y <= -40.8f)
        {
            cameraY = 0;
        }
    }
    public void ReaperCam()
    {
        isHorizontal = false;
        transform.position = new Vector3(397.5f, -40.8f,-10);
    }

    public void Phase2Cam()
    {
        phase2Cam = true;
    }
}