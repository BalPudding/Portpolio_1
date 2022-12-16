using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    Animator animator;
    bool reachUpPos = true;
    public float stopYPos;
    bool onTunring;
    public float timeCheck;
    float upTime;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
    }

    void Update()
    {
        upTime += Time.deltaTime;
        if (reachUpPos == true)
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
            if(transform.position.y >= stopYPos)
            {
                reachUpPos = false;
            }
        }
        if (reachUpPos == false)
        {
            animator.enabled = true;
        }
        if (upTime >= timeCheck)
        {
            onTunring = true;
        }
        animator.SetBool("Throw", reachUpPos);
        animator.SetBool("Turn", onTunring);
    }
}
