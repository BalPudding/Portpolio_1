using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController3D : MonoBehaviour
{
    Slammed slammed;
    bool isStandUp;
    public GameObject wallCam;
    FirstPerson firstPerson;
    // Start is called before the first frame update
    void Start()
    {
        slammed = GameObject.Find("genji_MainModel").GetComponent<Slammed>();
        transform.rotation = Quaternion.Euler(new Vector3(23, 180, 0));
        firstPerson = wallCam.GetComponent<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slammed.standUp == true && isStandUp == false)
        {
            isStandUp = true;
            transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            StartCoroutine("Disable");
        }
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
        wallCam.SetActive(true);
        firstPerson.enabled = true;
    }
}
