using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaCon : MonoBehaviour
{
    private static CinemaCon instance = null;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject wallCam;
    public GameObject mainCam;
    GameObject gen;
    PlayerController3D playerController3D;
    float phase1Time;
    public float phase1TimeLimit;
    public bool destroyBullet;
    //인스턴스화
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static CinemaCon Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    private void start()
    {
        gen = GameObject.Find("genji_MainModel");
        playerController3D = gen.transform.Find("Main Camera").GetComponent<PlayerController3D>();

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
        //2페이즈 돌입 애니
        if(destroyBullet == true)
        {
            wallCam.SetActive(false);
            mainCam.SetActive(true);
        }
    }
}
