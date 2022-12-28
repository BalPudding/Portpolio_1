using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaCon : MonoBehaviour
{
    //�ν��Ͻ�ȭ
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
    private static CinemaCon instance = null;
    PlayerController3D playerController3D;
    UpAndSlammed upAndSlammed;
    Animator genAnimator;
    GameObject gen;
    public GameObject reap2PhaseAnim;
    TurnAndThrow turnAndThrow;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject mainCam;
    public GameObject wallCam;
    float phase1Time;
    public float phase1TimeLimit;
    public bool destroyBullet;


    //����ī�޶󺯼�
    bool isStandUp;
    bool phase2Anim;
    bool isthrowing = false;






    void Start()
    {
        gen = GameObject.Find("genji_MainModel");
        playerController3D = gen.GetComponent<PlayerController3D>();
        upAndSlammed = gen.GetComponent<UpAndSlammed>();
        genAnimator = gen.GetComponent<Animator>();
        turnAndThrow = reap2PhaseAnim.GetComponent<TurnAndThrow>();

        //���� ī�޶� ����
        mainCam.transform.rotation = Quaternion.Euler(new Vector3(23, 180, 0));
    }

    void Update()
    {
        //�Ͼ�� �ִϸ��̼��� �����ϸ� ���ӽ���
        if (upAndSlammed.standUp == true && isStandUp == false)
        {
            isStandUp = true;
            transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
            StartCoroutine("Disable");
        }

        //���� ���۽��� & 1������ Ÿ�̸� ����
        if (playerController3D.enabled == true)
        {
            phase1Time += Time.deltaTime;
        }
        if (phase1Time >= phase1TimeLimit)
        {
            phase1.SetActive(false);
            destroyBullet = true;
        }

        //1����� ������ ī�޶� ��ġ���� & �ִϸ��̼� ���
        if (destroyBullet == true && phase2Anim == false)
        {
            phase2Anim = true;
            wallCam.SetActive(false);
            mainCam.SetActive(true);
            mainCam.transform.localPosition = new Vector3(mainCam.transform.localPosition.x, 0.138f, mainCam.transform.localPosition.z);
            mainCam.transform.rotation = Quaternion.Euler(0, 180, 0);
            genAnimator.enabled = false;
            playerController3D.enabled = false;
            reap2PhaseAnim.SetActive(true);
        }
        if (turnAndThrow.isTurnOn == true && isthrowing == false)
        {
            gen.transform.rotation = Quaternion.Euler(0, 180, 0);
            gen.transform.Translate(0, 0, 8 * Time.deltaTime);
            if (gen.transform.position.z <= 2)
            {
                genAnimator.enabled = true;
                genAnimator.Rebind();
            }
            if (gen.transform.position.z <= 0.1f)
            {
                isthrowing = true;
                playerController3D.enabled = true;
                mainCam.SetActive(false);
            }
        }
    }
    //�ڷ�ƾ ��ġ
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2.5f);
        playerController3D.enabled = true;
        mainCam.SetActive(false);
        wallCam.SetActive(true);
        phase1.SetActive(true);
    }
}
