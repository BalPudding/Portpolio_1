using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldChange : MonoBehaviour
{
    PlayerC playerC;
    CameraController cameraController;
    private void Awake()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
        cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerC.playerDistrictL = 195f;
            playerC.playerDistrictB = -28f;
            cameraController.CameraChange01();
            playerC.Freeze();
        }
    }
}
