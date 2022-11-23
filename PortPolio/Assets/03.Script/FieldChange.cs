using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldChange : MonoBehaviour
{
    PlayerC playerC;
    CameraController cameraController;
    public GameObject activate;
    public GameObject inactivate;
    public float newDistrictL;
    public float newDistrictR;
    public float newDistrictB;
    public float changeRocate;
    private void Awake()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
        cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerC.playerDistrictL = newDistrictL;
            playerC.playerDistrictR = newDistrictR;
            playerC.playerDistrictB = newDistrictB;
            cameraController.changeRocate = changeRocate;
            cameraController.cameraMoving_00 = true;
            playerC.Freeze();
            activate.SetActive(true);
            Invoke("Inactivate", 4f);
        }
    }
    void Inactivate()
    {
        inactivate.SetActive(false);
    }
}
