using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAndThrow : MonoBehaviour
{
    public bool isTurnOn;
    float timer;
    public float turnSpeed;
    public float upTime;
    public float timeCheck;
    float movingspeed;
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
        smoke_00 = transform.Find("smoke_thick_00").gameObject;
        smoke_01 = transform.Find("smoke_thick_01").gameObject;
        smoke_02 = transform.Find("smoke_thick_02").gameObject;
        smoke_03 = transform.Find("smoke_thick_03").gameObject;
        smokeP_00 = smoke_00.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_01 = smoke_01.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_02 = smoke_02.transform.Find("Particle System").GetComponent<ParticleSystem>();
        smokeP_03 = smoke_03.transform.Find("Particle System").GetComponent<ParticleSystem>();
        subMesh = transform.Find("mesh").gameObject;
        subMesh.SetActive(false);
        movingspeed = 200;
    }
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

            transform.Translate(0, 0, movingspeed * Time.deltaTime);
            if(transform.position.z >= 8.3)
            {
                transform.position = new Vector3(0, 0, 8.7f);
                movingspeed = 0;
            }
        }
        if (upTime >= 8)
        {
            isTurnOn = true;
        }


        if (isTurnOn == true)
        {
            transform.Rotate(0, turnSpeed*Time.deltaTime, 0);
            timer += Time.deltaTime;
        }
        if (timer >= 0.2f)
        {
            turnSpeed = 0;
        }
    }
}
