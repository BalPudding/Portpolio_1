using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperEnding : MonoBehaviour
{
    Animator animator;
    GameObject smoke_00;
    GameObject smoke_01;
    GameObject smoke_02;
    GameObject smoke_03;
    GameObject blood;
    ParticleSystem smokeP_00;
    ParticleSystem smokeP_01;
    ParticleSystem smokeP_02;
    ParticleSystem smokeP_03;
    ParticleSystem bloodP;
    GameObject subMesh;
    public float upTime;
    public bool isDeath;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        smoke_00 = transform.Find("smoke_thick_00").gameObject;
        smoke_01 = transform.Find("smoke_thick_01").gameObject;
        smoke_02 = transform.Find("smoke_thick_02").gameObject;
        smoke_03 = transform.Find("smoke_thick_03").gameObject;
        blood = transform.Find("BloodSpray").gameObject;
        smokeP_00 = smoke_00.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_01 = smoke_01.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_02 = smoke_02.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_03 = smoke_03.transform.Find("Particle System").GetComponent<ParticleSystem>();
        bloodP = blood.transform.Find("Particle System").GetComponent<ParticleSystem>();
        subMesh = transform.Find("mesh").gameObject;
    }

    private void Start()
    {
        subMesh.SetActive(false);
        blood.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        var em00 = smokeP_00.emission;
        var em01 = smokeP_01.emission;
        var em02 = smokeP_02.emission;
        var em03 = smokeP_03.emission;
        upTime += Time.deltaTime;
        if (upTime >= 2)
        {
            subMesh.SetActive(true);
            em00.enabled = false;
            em01.enabled = false;
            em02.enabled = false;
            em03.enabled = false;
            if (Input.GetKeyDown(KeyCode.V) == true)
            {
                blood.SetActive(true);
                animator.enabled = true;
            }
        }
    }
}
