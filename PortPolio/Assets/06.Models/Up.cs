using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    Animator animator;
    bool reachUpPos = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        transform.position = new Vector3(3, -2, 0);
    }

    void Update()
    {
        if (reachUpPos == true)
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
            if(transform.position.y >= 0)
            {
                reachUpPos = false;
            }
        }
        animator.SetBool("Throw", reachUpPos);
    }
}
