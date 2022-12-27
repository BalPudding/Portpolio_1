using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController3D : MonoBehaviour
{
    Slammed slammed;
    bool isStandUp;
    public GameObject wallCam;
    public GameObject phase_1;
    FirstPerson firstPerson;
    PlayerController3D playerController3D;
    bool upPosition;
    // Start is called before the first frame update
    void Start()
    {
        slammed = GameObject.Find("genji_MainModel").GetComponent<Slammed>();
        transform.rotation = Quaternion.Euler(new Vector3(23, 180, 0));
        firstPerson = wallCam.GetComponent<FirstPerson>();
        playerController3D = GameObject.Find("genji_MainModel").GetComponent<PlayerController3D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slammed.standUp == true && isStandUp == false)
        {
            isStandUp = true;
            transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
            StartCoroutine("Disable");
        }
        if(CinemaCon.Instance.destroyBullet == true && upPosition == false)
        {
            upPosition = true;
        }
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2.5f);
        playerController3D.enabled = true;
        gameObject.SetActive(false);
        wallCam.SetActive(true);
        phase_1.SetActive(true);
    }
}
