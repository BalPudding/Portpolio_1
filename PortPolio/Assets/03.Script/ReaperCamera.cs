using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperCamera : MonoBehaviour
{
    CameraController cameraController;
    PlayerC playerC;
    public GameObject boss_Intro;
    public GameObject reaper_Health;

    private void Awake()
    {
        cameraController = GameObject.Find("MainCamera").GetComponent<CameraController>();
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cameraController.ReaperCam();
            playerC.transform.position = new Vector2(427.5f, transform.position.y+0.8f);
        }
        boss_Intro.SetActive(true);
        reaper_Health.SetActive(true);
    }
}
