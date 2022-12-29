using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishV : MonoBehaviour
{
    Animator animator;
    bool isSlash;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) == true)
            {
                isSlash = true;
            }
        animator.SetBool("StandUp", false);
        animator.SetBool("Slash", isSlash);
    }
}
