using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public GameObject wallCam;
    public GameObject knife;
    public GameObject shuriken3D;
    GameObject bulletHole;
    Animator animator;
    FirstPerson firstPerson;
    Shooter shooter;
    bool isLeftClick;
    bool isRightClick;
    bool isSlash;
    float knifeActiver = 0;
    bool actionDelayOn = true;
    float actionDelay;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        firstPerson = wallCam.GetComponent<FirstPerson>();
        bulletHole = wallCam.transform.Find("BulletHole").gameObject;
        shooter = bulletHole.GetComponent<Shooter>();

        animator.SetBool("StandUp", true);
    }

    // Update is called once per frame
    void Update()
    {
        knifeActiver += Time.deltaTime;
        
        if(actionDelayOn == false)
        {
            actionDelay += Time.deltaTime;
            if(actionDelay >= 1)
            {
                actionDelayOn = true;
            }
        }

        transform.position = new Vector3(wallCam.transform.position.x, wallCam.transform.position.y - 1.45f, wallCam.transform.position.z);
        transform.rotation = Quaternion.Euler(transform.rotation.x, firstPerson.yRotate, 0);

        if(Input.GetKeyDown(KeyCode.Mouse0) == true && actionDelayOn == true)
        {
            isLeftClick = true;
            actionDelay = 0;
            actionDelayOn = false;
            Instantiate(shuriken3D, bulletHole.transform.position,Quaternion.Euler(firstPerson.xRotate+90,firstPerson.yRotate,90));
            StartCoroutine("LeftClick");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) == true && actionDelayOn == true)
        {
            isRightClick = true;
            actionDelay = 0;
            actionDelayOn = false;
            Instantiate(shuriken3D, bulletHole.transform.position, Quaternion.Euler(firstPerson.xRotate + 90, firstPerson.yRotate, 105));
            Instantiate(shuriken3D, bulletHole.transform.position, Quaternion.Euler(firstPerson.xRotate + 90, firstPerson.yRotate, 90));
            Instantiate(shuriken3D, bulletHole.transform.position, Quaternion.Euler(firstPerson.xRotate + 90, firstPerson.yRotate, 75));
        }
        else if (Input.GetKeyDown(KeyCode.V) == true)
        {
            isSlash = true;
            actionDelay = 0;
            actionDelayOn = false;
            knifeActiver = 0;
        }
        else if(animator.GetBool("StandUp") == true)
        {
            isSlash = false;
            isLeftClick = false;
            isRightClick = false;
        }
        if (knifeActiver <= 1)
        {
            knife.SetActive(true);
        }
        else if(knifeActiver> 1)
        {
            knife.SetActive(false);
        }
        animator.SetBool("LeftClick", isLeftClick);
        animator.SetBool("RightClick", isRightClick);
        animator.SetBool("Slash", isSlash);
    }
    IEnumerator LeftClick()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(shuriken3D, bulletHole.transform.position, Quaternion.Euler(firstPerson.xRotate + 90, firstPerson.yRotate, 90));
        yield return new WaitForSeconds(0.1f);
        Instantiate(shuriken3D, bulletHole.transform.position, Quaternion.Euler(firstPerson.xRotate + 90, firstPerson.yRotate, 90));
        yield break;
    }
}
