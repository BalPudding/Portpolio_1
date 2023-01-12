using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndSlammed: MonoBehaviour
{
    Animator animator;
    bool reachUpPos = true;
    public float stopYPos;
    bool reachWallPos = true;
    bool isStanding;
    public bool standUp;
    UpAndDisaapear reaperAAnim;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        reaperAAnim = GameObject.Find("reaper_AppearAnim").GetComponent<UpAndDisaapear>();
    }
    // Update is called once per frame
    void Update()
    {
        //상승
        if (reachUpPos == true)
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
            if (transform.position.y >= stopYPos)
            {
                reachUpPos = false;
            }
        }
        //벽으로 이동 & 애니메이터 작동
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
        //넘어지기 & 일어나기 애니메이션 재생
        if(reaperAAnim.upTime >= 10.4f && standUp == false)
        {
            standUp = true;
            transform.position = new Vector3(transform.position.x, 0,8.5f);
            isStanding = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        animator.SetBool("StandUp", isStanding);
    }
}
