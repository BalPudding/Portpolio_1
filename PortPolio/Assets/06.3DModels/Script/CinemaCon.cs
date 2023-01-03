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
    FinishV finishV;
    UpAndSlammed upAndSlammed;
    Animator genAnimator;
    GameObject gen;
    public GameObject reap2PhaseAnim;
    TurnAndThrow turnAndThrow;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject genKnife;
    public GameObject mainCam;
    public GameObject wallCam;
    public GameObject smoke;
    float phase1Time;
    public float phase1TimeLimit;
    public bool destroyBullet;


    //����ī�޶󺯼�
    bool isStandUp;
    bool phase2Anim;
    bool isthrowing = false;
    bool phase3AnimReady;
    bool activeTime;
    float outTimecheck;






    void Start()
    {
        gen = GameObject.Find("genji_MainModel");
        playerController3D = gen.GetComponent<PlayerController3D>();
        upAndSlammed = gen.GetComponent<UpAndSlammed>();
        genAnimator = gen.GetComponent<Animator>();
        finishV = gen.GetComponent<FinishV>();
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
        //2������ �ִϸ��̼� ��� & ���ͷ� �̵�
        if (turnAndThrow.isTurnOn == true && isthrowing == false)
        {
            wallCam.transform.position = new Vector3(0, 1.45f, 0);
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
                StartCoroutine("Disable2");
            }
        }
        //������ �ִϸ��̼� ���
        if(destroyBullet == true && phase2Anim == true && phase3AnimReady == true)
        {
            phase3AnimReady = false;
            wallCam.SetActive(false);
            mainCam.SetActive(true);
            mainCam.transform.localPosition = new Vector3(mainCam.transform.localPosition.x, 0.138f, mainCam.transform.localPosition.z);
            gen.transform.rotation = Quaternion.Euler(0, 180, 0);
            mainCam.transform.rotation = Quaternion.Euler(0, 180, 0);
            phase3.SetActive(true);
            playerController3D.enabled = false;
            finishV.enabled = true;
        } 
        //������ �ϰ�
        if(finishV.enabled == true && Input.GetKeyDown(KeyCode.V) == true)
        {
            genKnife.SetActive(true);
            genAnimator.SetTrigger("Fin");
            activeTime = true;
        }
        //���� �ִϸ��̼� Ÿ��üũ
        if(activeTime == true)
        {
            outTimecheck += Time.deltaTime;
            if (outTimecheck >= 3)
            {
                smoke.SetActive(true);
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
    IEnumerator Disable2()
    {
        yield return new WaitForSeconds(2.5f);
        playerController3D.enabled = true;
        mainCam.SetActive(false);
        wallCam.SetActive(true);
        phase2.SetActive(true);
        phase1Time = 0;
        destroyBullet = false;
        phase3AnimReady = true;
    }
}
