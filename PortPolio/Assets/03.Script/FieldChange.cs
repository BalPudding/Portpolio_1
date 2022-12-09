using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldChange : MonoBehaviour
{
    public GameObject activate;
    public GameObject inactivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && CameraController.Instance.cameraMoving_00 == false)
        {
            CameraController.Instance.cameraMoving_00 = true;
            activate.SetActive(true);
            StartCoroutine(Inactivate());
        }
        else if (collision.gameObject.tag == "Player" && CameraController.Instance.cameraMoving_00 == true)
        {
            CameraController.Instance.cameraMoving_00 = false;
            activate.SetActive(true);
            StartCoroutine(Inactivate());
            CameraController.Instance.isHorizontal = true;
            CameraController.Instance.cameraY = -20;
        }

        IEnumerator Inactivate()
        {
            yield return new WaitForSeconds(4f);
            inactivate.SetActive(false);
        }
    }
}
