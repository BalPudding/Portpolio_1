using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    public GameObject reaper_bullet;
    int positionRange = 6;
    int patternRange = 4;
    float movingCool;
    bool patternCool;
    bool isMoving;
    bool isShooting;

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
        //좌우반전
        if(transform.position.x - PlayerC.Instance.transform.position.x<=0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        //움직임 속도
        movingCool += Time.deltaTime;
        if (movingCool >= 5)
        {
            movingCool = 0;
            isShooting = false;
            patternCool = true;
            positionRange = Random.Range(0, 6);
            patternRange = Random.Range(0,5);
        }
        //위치변경난수 + 패턴
        if (positionRange == 0)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(430, -37.5f), 0.05f);
            if(transform.position.x == 430 && transform.position.y == -37.5f)
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
            }
        }
        if (positionRange == 1)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(446, -37.5f), 0.05f);
            if (transform.position.x == 446 && transform.position.y == -37.5f)
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
            }
        }
        if (positionRange == 2)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(430, -41.2f), 0.05f);
            if (transform.position.x == 430 && transform.position.y == -41.2f)
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
            }
        }
        if (positionRange == 3)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(446, -41.2f), 0.05f);
            if (transform.position.x == 446 && transform.position.y == -41.2f)
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
            }
        }
        if (positionRange == 4)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(430, -45.7f), 0.05f);
            if (transform.position.x == 430 && transform.position.y == -45.7f)
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
            }
        }
        if (positionRange == 5)
        {
            isMoving = true;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(446, -45.7f), 0.05f);
            if (transform.position.x == 446 && transform.position.y == -45.7f)
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
            }
        }
        //애니메이터
        animator.SetBool("Moving", isMoving);
        animator.SetBool("Shooting", isShooting);
    }

    //공격패턴
    void Shoot_3()
    {
        isShooting = true;
        GameObject bulletT = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bulletM = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bulletB = Instantiate(reaper_bullet, transform.position, transform.rotation);

        bulletT.transform.LookAt(PlayerC.Instance.transform.position);
        bulletM.transform.LookAt(PlayerC.Instance.transform.position);
        bulletB.transform.LookAt(PlayerC.Instance.transform.position);

        bulletT.transform.rotation = Quaternion.Euler(0, 0, 15);
        bulletM.transform.rotation = Quaternion.Euler(0, 0, 0);
        bulletB.transform.rotation = Quaternion.Euler(0, 0, -15);
    }
    void Shoot_6()
    {
        isShooting = true;
        GameObject bullet_6_01 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_02 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_03 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_04 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_05 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_06 = Instantiate(reaper_bullet, transform.position, transform.rotation);

        bullet_6_01.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_02.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_03.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_04.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_05.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_06.transform.LookAt(PlayerC.Instance.transform.position);

        bullet_6_01.transform.rotation = Quaternion.Euler(0, 0, 45);
        bullet_6_02.transform.rotation = Quaternion.Euler(0, 0, 27);
        bullet_6_03.transform.rotation = Quaternion.Euler(0, 0, 9);
        bullet_6_04.transform.rotation = Quaternion.Euler(0, 0, -9);
        bullet_6_05.transform.rotation = Quaternion.Euler(0, 0, -27);
        bullet_6_06.transform.rotation = Quaternion.Euler(0, 0, -45);
    }
    void Shoot_3_2()
    {
        isShooting = true;
        GameObject bulletT = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bulletM = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bulletB = Instantiate(reaper_bullet, transform.position, transform.rotation);

        bulletT.transform.LookAt(PlayerC.Instance.transform.position);
        bulletM.transform.LookAt(PlayerC.Instance.transform.position);
        bulletB.transform.LookAt(PlayerC.Instance.transform.position);

        bulletT.transform.rotation = Quaternion.Euler(0, 0, 15);
        bulletM.transform.rotation = Quaternion.Euler(0, 0, 0);
        bulletB.transform.rotation = Quaternion.Euler(0, 0, -15);
        StartCoroutine("Shoot_3_2C");
    }
    void Shoot_6_2()
    {
        isShooting = true;
        GameObject bullet_6_01 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_02 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_03 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_04 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_05 = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bullet_6_06 = Instantiate(reaper_bullet, transform.position, transform.rotation);

        bullet_6_01.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_02.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_03.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_04.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_05.transform.LookAt(PlayerC.Instance.transform.position);
        bullet_6_06.transform.LookAt(PlayerC.Instance.transform.position);

        bullet_6_01.transform.rotation = Quaternion.Euler(0, 0, 45);
        bullet_6_02.transform.rotation = Quaternion.Euler(0, 0, 27);
        bullet_6_03.transform.rotation = Quaternion.Euler(0, 0, 9);
        bullet_6_04.transform.rotation = Quaternion.Euler(0, 0, -9);
        bullet_6_05.transform.rotation = Quaternion.Euler(0, 0, -27);
        bullet_6_06.transform.rotation = Quaternion.Euler(0, 0, -45);
        StartCoroutine("Shoot_3_2C");
    }
    
    //코루틴 뭉치
    IEnumerator Laugh()
    {
        yield return new WaitForSeconds(3.0f);
    }
    IEnumerator Shoot_3_2C()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject bulletT = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bulletM = Instantiate(reaper_bullet, transform.position, transform.rotation);
        GameObject bulletB = Instantiate(reaper_bullet, transform.position, transform.rotation);

        bulletT.transform.LookAt(PlayerC.Instance.transform.position);
        bulletM.transform.LookAt(PlayerC.Instance.transform.position);
        bulletB.transform.LookAt(PlayerC.Instance.transform.position);

        bulletT.transform.rotation = Quaternion.Euler(0, 0, 15);
        bulletM.transform.rotation = Quaternion.Euler(0, 0, 0);
        bulletB.transform.rotation = Quaternion.Euler(0, 0, -15);
    }
}
