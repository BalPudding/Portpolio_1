using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaCon : MonoBehaviour
{
    public GameObject phase1;
    GameObject gen;
    GameObject[] bullet;
    PlayerController3D playerController3D;
    float phase1Time;
    public float phase1TimeLimit;
    private void Awake()
    {
        gen = GameObject.Find("genji_MainModel");
        playerController3D = gen.GetComponent<PlayerController3D>();
        bullet = GameObject.FindGameObjectsWithTag("Enemy");
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
            
            Destroy(bullet);
        }
    }
}
