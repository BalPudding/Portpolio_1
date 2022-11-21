using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBot : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    float jumpdelay;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Jumping") == false)
        {
            jumpdelay += Time.deltaTime;
            if(jumpdelay >= 2)
            {
                jumpdelay = 0;
                rigidbody2D.AddForce(new Vector2(0, 1400));
            }
        }
        else
        {
            jumpdelay = 0;
        }
    }
}
