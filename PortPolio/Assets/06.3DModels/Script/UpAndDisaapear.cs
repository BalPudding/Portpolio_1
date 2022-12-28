using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDisaapear : MonoBehaviour
{
    Animator animator;
    bool reachUpPos = true;
    public float stopYPos;
    bool onTunring;
    float timeCheck;
    public float upTime;
    GameObject smoke_00;
    GameObject smoke_01;
    GameObject smoke_02;
    GameObject smoke_03;
    ParticleSystem smokeP_00;
    ParticleSystem smokeP_01;
    ParticleSystem smokeP_02;
    ParticleSystem smokeP_03;
    GameObject subMesh;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        timeCheck = 5;
        smoke_00 = transform.Find("smoke_thick_00").gameObject;
        smoke_01 = transform.Find("smoke_thick_01").gameObject;
        smoke_02 = transform.Find("smoke_thick_02").gameObject;
        smoke_03 = transform.Find("smoke_thick_03").gameObject;
        smokeP_00 = smoke_00.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_01 = smoke_01.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_02 = smoke_02.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_03 = smoke_03.transform.Find("Particle System").GetComponent<ParticleSystem>();
        subMesh = transform.Find("Submesh").gameObject;
    }

    void Update()
    {
        var em00 = smokeP_00.emission;
        var em01 = smokeP_01.emission;
        var em02 = smokeP_02.emission;
        var em03 = smokeP_03.emission;
        upTime += Time.deltaTime;
        //상승
        if (reachUpPos == true)
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
            if(transform.position.y >= stopYPos)
            {
                reachUpPos = false;
            }
        }
        //애니메이터 작동
        if (reachUpPos == false)
        {
            animator.enabled = true;
        }
        //뒤도돌기
        if (upTime >= timeCheck)
        {
            onTunring = true;
        }
        //연기 나타났다 자연스럽게 사라지기
        if(upTime >= timeCheck + 1)
        {
            smoke_00.SetActive(true);
            smoke_01.SetActive(true);
            smoke_02.SetActive(true);
            smoke_03.SetActive(true);
        }
        if(upTime >= timeCheck + 3)
        {
            subMesh.SetActive(false);
            em00.enabled = false;
            em01.enabled = false;
            em02.enabled = false;
            em03.enabled = false;
        }
        animator.SetBool("Throw", reachUpPos);
        animator.SetBool("Turn", onTunring);
    }
}
