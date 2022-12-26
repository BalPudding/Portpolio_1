using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaCon : MonoBehaviour
{
    public GameObject phase1;
    public GameObject phase2;
    GameObject gen;
    PlayerController3D playerController3D;
    float phase1Time;
    public float phase1TimeLimit;
    public bool destroyBullet;
    private void Awake()
    {
        gen = GameObject.Find("genji_MainModel");
        playerController3D = gen.GetComponent<PlayerController3D>();
    }
    void Update()
    {
        if(playerController3D.enabled == true)
        {
            phase1Time += Time.deltaTime;
        }
        if (phase1Time >= phase1TimeLimit)
        {
            phase1.SetActive(false);
            destroyBullet = true;
        }
    }
}
