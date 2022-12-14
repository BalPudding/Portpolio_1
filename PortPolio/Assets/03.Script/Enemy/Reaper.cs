using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    public GameObject reaper_bullet_3;
    public GameObject reaper_bullet_6;
    public GameObject drainFocus;
    public GameObject drainCrossLine;
    int positionRange = 6;
    int patternRange = 4;
    float movingCool;
    public float difficulty;
    bool patternCool;
    bool isMoving;
    bool isShooting;
    float drainTimer;
    bool isDraining;
    bool isHit;
    bool isPhase_2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        StartCoroutine("Laugh");
    }

    void Update()
    {
        //�¿����
        if(transform.position.x - PlayerC.Instance.transform.position.x<=0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        //������ �ӵ�
        movingCool += Time.deltaTime;
        if (movingCool >= difficulty)
        {
            movingCool = 0;
            isShooting = false;
            patternCool = true;
            positionRange = Random.Range(0, 6);
            patternRange = Random.Range(0,6);
        }
        if(isMoving == true)
        {
            gameObject.layer = 11;
            gameObject.tag = "Untagged";
        }
        else
        {
            gameObject.layer = 7;
            gameObject.tag = "Enemy";
        }
        //��ġ���泭�� + ����
        if (positionRange == 0)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(390, -37.5f), 0.05f);
            if(transform.position.x == 390 && transform.position.y == -37.5f)
            {
                isMoving = false;
                if(patternRange == 0 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3();
                }
                if(patternRange == 1 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6();
                }
                if(patternRange == 2 && patternCool == true)
                {
                    patternCool = false;
                    StartCoroutine("Laugh");
                }
                if(patternRange == 3 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3_2();
                }
                if(patternRange == 4 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6_2();
                }
                if (patternRange == 5 && patternCool == true)
                {
                    patternCool = false;
                    Draining();
                }
            }
        }
        if (positionRange == 1)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(405, -37.5f), 0.05f);
            if (transform.position.x == 405 && transform.position.y == -37.5f)
            {
                isMoving = false;
                if (patternRange == 0 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3();
                }
                if (patternRange == 1 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6();
                }
                if(patternRange ==2 && patternCool == true)
                {
                    patternCool = false;
                    StartCoroutine("Laugh");
                }
                if (patternRange == 3 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3_2();
                }
                if (patternRange == 4 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6_2();
                }
                if (patternRange == 5 && patternCool == true)
                {
                    patternCool = false;
                    Draining();
                }
            }
        }
        if (positionRange == 2)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(390, -41.2f), 0.05f);
            if (transform.position.x == 390 && transform.position.y == -41.2f)
            {
                isMoving = false;
                if (patternRange == 0 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3();
                }
                if (patternRange == 1 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6();
                }
                if (patternRange == 2 && patternCool == true)
                {
                    patternCool = false;
                    StartCoroutine("Laugh");
                }
                if (patternRange == 3 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3_2();
                }
                if (patternRange == 4 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6_2();
                }
                if (patternRange == 5 && patternCool == true)
                {
                    patternCool = false;
                    Draining();
                }
            }
        }
        if (positionRange == 3)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(405, -41.2f), 0.05f);
            if (transform.position.x == 405 && transform.position.y == -41.2f)
            {
                isMoving = false;
                if (patternRange == 0 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3();
                }
                if (patternRange == 1 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6();
                }
                if (patternRange == 2 && patternCool == true)
                {
                    patternCool = false;
                    StartCoroutine("Laugh");
                }
                if (patternRange == 3 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3_2();
                }
                if (patternRange == 4 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6_2();
                }
                if (patternRange == 5 && patternCool == true)
                {
                    patternCool = false;
                    Draining();
                }
            }
        }
        if (positionRange == 4)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(390, -45.7f), 0.05f);
            if (transform.position.x == 390 && transform.position.y == -45.7f)
            {
                isMoving = false;
                if (patternRange == 0 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3();
                }
                if (patternRange == 1 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6();
                }
                if (patternRange == 2 && patternCool == true)
                {
                    patternCool = false;
                    StartCoroutine("Laugh");
                }
                if (patternRange == 3 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3_2();
                }
                if (patternRange == 4 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6_2();
                }
                if (patternRange == 5 && patternCool == true)
                {
                    patternCool = false;
                    Draining();
                }
            }
        }
        if (positionRange == 5)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(405, -45.7f), 0.05f);
            if (transform.position.x == 405 && transform.position.y == -45.7f)
            {
                isMoving = false;
                if (patternRange == 0 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3();
                }
                if (patternRange == 1 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6();
                }
                if (patternRange == 2 && patternCool == true)
                {
                    patternCool = false;
                    StartCoroutine("Laugh");
                }
                if (patternRange == 3 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_3_2();
                }
                if (patternRange == 4 && patternCool == true)
                {
                    patternCool = false;
                    Shoot_6_2();
                }
                if (patternRange == 5 && patternCool == true)
                {
                    patternCool = false;
                    Draining();
                }
            }
        }
        if(isDraining == true)
        {
            drainTimer += Time.deltaTime;
            if(isHit == true)
            {
                drainFocus.SetActive(false);
                drainCrossLine.SetActive(false);
                drainTimer = 0;
                movingCool = 1;
                isDraining = false;
            }
            else if (drainTimer >= 3)
            {
                drainFocus.SetActive(false);
                drainCrossLine.SetActive(false);
                ActiveDrain();
                drainTimer = 0;
                movingCool = 1;
                isDraining = false;
            }
        }
        //2������
        if(isPhase_2 == true)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerC.Instance.transform.position, 0.008f);
        }
        //�ִϸ�����
        animator.SetBool("Moving", isMoving);
        animator.SetBool("Shooting", isShooting);
        animator.SetBool("Draining", isDraining);
        animator.SetBool("Hitted", isHit);
        animator.SetBool("Phase_2", isPhase_2);
    }

    //��������
    void Shoot_3()
    {
        isShooting = true;
        GameObject bulletT = Instantiate(reaper_bullet_3, transform.position, transform.rotation);
    }
    void Shoot_6()
    {
        isShooting = true;
        GameObject bullet_6_01 = Instantiate(reaper_bullet_6, transform.position, transform.rotation);
    }
    void Shoot_3_2()
    {
        isShooting = true;
        GameObject bulletT = Instantiate(reaper_bullet_3, transform.position, transform.rotation);
        StartCoroutine("Shoot_3_2C");
    }
    void Shoot_6_2()
    {
        isShooting = true;
        GameObject bullet_6_01 = Instantiate(reaper_bullet_6, transform.position, transform.rotation);
        StartCoroutine("Shoot_3_2C");
    }
    void Draining()
    {
        drainFocus.SetActive(true);
        drainCrossLine.SetActive(true);

        isHit = false;
        isDraining = true;
        movingCool = -10;
    }
    void ActiveDrain()
    {
        UIManager.Instance.currentDrainHp += 50;
        UIManager.Instance.currentHP -= 50;
        PlayerC.Instance.OnDamage();
    }

    //�ǰ�����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shuriken")
        {
            isHit = true;
            UIManager.Instance.currentDrainHp -= 10;
            if (UIManager.Instance.currentDrainHp <= 0)
            {
                UIManager.Instance.currentReaperFirstHp -= 10;
                if (UIManager.Instance.currentReaperFirstHp <= 0)
                {
                    UIManager.Instance.currentReaperSecondHp -= 10;
                    if (UIManager.Instance.currentReaperSecondHp <= 0)
                    {
                        Phase2();
                    }
                }
            }
        }
    }
    
    //2������
    void Phase2()
    {
        CameraController.Instance.Phase2Cam();
        movingCool = -500;
        isHit = true;
        isShooting = false;
        StartCoroutine("Phase_2_C");
    }
    //�ڷ�ƾ ��ġ
    IEnumerator Laugh()
    {
        yield return new WaitForSeconds(3.0f);
    }
    IEnumerator Shoot_3_2C()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject bulletT = Instantiate(reaper_bullet_3, transform.position, transform.rotation);
    }
    IEnumerator Phase_2_C()
    {
        yield return new WaitForSeconds(3.0f);
        isPhase_2 = true;
    }
}