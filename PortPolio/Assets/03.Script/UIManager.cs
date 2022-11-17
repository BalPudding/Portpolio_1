using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //인스턴스화
    private static UIManager instance = null;
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
    public static UIManager Instance
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
    PlayerC playerC;
    public Slider hpBar;
    public Slider deflectBar;
    public Slider slashBar;
    public float maxHP;
    public float currentHP;
    public float sMaxCool = 8;
    public float sCool;
    float maxCool = 8;
    float deCool;
    public TextMeshProUGUI current;
    public TextMeshProUGUI slashcool;
    public TextMeshProUGUI deflectcool;


    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
    }
    void Update()
    {
        //체력
        hpBar.value = currentHP / maxHP;
        //총알
        current.text = playerC.bullet.ToString();
        //질풍참
        if (playerC.Sdelayon == true)
        {
            sCool += Time.deltaTime;
            slashcool.color = new Color(0, 0, 0, 255f);
            slashcool.text = playerC.Sdelay.ToString("F0");
        }
        else
        {
            sCool = 0;
            slashcool.color = new Color(0, 0, 0, 0f);
        }
         slashBar.value = sCool / sMaxCool;

        //튕겨내기
        if (playerC.deflectCool == true)
        {
            deCool += Time.deltaTime;
            deflectcool.color = new Color(0, 0, 0, 255f);
            deflectcool.text = playerC.deflectcoolUI.ToString("F0");
        }
        else
        {
            deCool = 0;
            deflectcool.color = new Color(0, 0, 0, 0f);
        }
        deflectBar.value = deCool / maxCool;
    }
}
