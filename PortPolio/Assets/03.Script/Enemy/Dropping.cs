using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropping : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rigidbody2D;
    Animator animator;
    bool jumping = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x - player.transform.position.x <= 10f)
        {
            rigidbody2D.gravityScale = 5;
                
        }
        animator.SetBool("Jumping", jumping);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        jumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        jumping = true;
    }
}
