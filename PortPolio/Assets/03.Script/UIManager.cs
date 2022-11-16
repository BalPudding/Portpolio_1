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
    public float maxHP;
    public float currentHP;
    public float maxCool = 8;
    public float deCool;
    public TextMeshProUGUI current;
    public TextMeshProUGUI deflectcool;


    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
    }
    void Update()
    {
        current.text = playerC.bullet.ToString();
        if(playerC.deflectCool == true)
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
        hpBar.value = currentHP / maxHP;
        deflectBar.value = deCool / maxCool;
    }
}
