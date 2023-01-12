using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperCamera : MonoBehaviour
{
    public GameObject boss_Intro;
    public GameObject reaper_Health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraController.Instance.ReaperCam();
            PlayerC.Instance.transform.position = new Vector2(387.5f, transform.position.y+1);
        }
        boss_Intro.SetActive(true);
        reaper_Health.SetActive(true);
    }
}
