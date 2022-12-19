using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slammed : MonoBehaviour
{
    Animator animator;
    bool reachUpPos = true;
    public float stopYPos;
    bool reachWallPos = true;
    bool isStanding;
    public bool standUp;
    Up reaperAAnim;
    PlayerController3D playerController3D;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        reaperAAnim = GameObject.Find("reaper_AppearAnim").GetComponent<Up>();
        playerController3D = gameObject.GetComponent<PlayerController3D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (reachUpPos == true)
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
            if (transform.position.y >= stopYPos)
            {
                reachUpPos = false;
            }
        }
        if(reachUpPos == false && reachWallPos == true)
        {
            transform.Translate(0, 0, -8*Time.deltaTime);
            if(transform.position.z>= 6)
            {
                animator.enabled = true;
            }
            if (transform.position.z >= 8.5f)
            {
                reachWallPos = false;
                
            }
        }
        if(reaperAAnim.upTime >= 9 && standUp == false)
        {
            standUp = true;
            transform.position = new Vector3(transform.position.x, 0,8.5f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isStanding = true;
            playerController3D.enabled = true;
        }
        animator.SetBool("StandUp", isStanding);
    }
}
