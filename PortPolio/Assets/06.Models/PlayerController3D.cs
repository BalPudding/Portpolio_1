using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public GameObject wallCam;
    public GameObject knife;
    Animator animator;
    FirstPerson firstPerson;
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
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) == true && actionDelayOn == true)
        {
            isRightClick = true;
        }
        else if (Input.GetKeyDown(KeyCode.V) == true)
        {
            isSlash = true;
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
}
