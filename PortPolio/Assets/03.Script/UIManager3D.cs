using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager3D : MonoBehaviour
{
    //인스턴스화
    private static UIManager3D instance = null;
    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static UIManager3D Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public Slider hpBar;
    public float maxHP;
    public float currentHP;

    void Update()
    {
        //체력
        hpBar.value = currentHP / maxHP;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        //사망 감지
        if (currentHP <= 0)
        {
            Invoke("LoadDead", 3f);
        }
    }
    //사망
    void LoadDead()
    {
        GameManager.Instance.LoadDead();
        currentHP = 200;
    }
}
