using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Scrolling scrolling;
    public SpriteRenderer Slash;
    public GameObject shuriken;
    public GameObject shield;
    public GameObject hitplatform;
    public GameObject damagedObj;
    public float jumpForce;
    public float moveSpeed;
    public int jumpcount;
    bool isMoving;
    public float Sdelay;
    public bool Sdelayon;
    bool isRising;
    float leftdelay;
    bool ldelayon;
    float rightdelay;
    bool rdelayon;
    public int bullet = 30;
    int maxbullet = 30;
    bool deflect;
    public bool deflectCool;
    bool Adelay;
    bool damaged;
    float fade;
    bool fading;
    public float deflectcoolUI;
    public float playerDistrictL;
    public float playerDistrictR;
    public float playerDistrictB;
    public bool freeze;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        scrolling = shuriken.GetComponent<Scrolling>();
    }

    void Update()
    {
        //이동제한
        if (transform.position.x <= playerDistrictL)
        {
            transform.position = new Vector2(playerDistrictL + 1, transform.position.y);
        }
        if(transform.position.x>= playerDistrictR)
        {
            transform.position = new Vector2(playerDistrictR - 1, transform.position.y);
        }
        if(transform.position.y <= playerDistrictB)
        {
            transform.position = new Vector2(transform.position.x, playerDistrictB + 3);
        }
        //좌우이동
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * moveSpeed;
        if(xSpeed != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if(xSpeed < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (xSpeed >0)
        {
            spriteRenderer.flipX = false;
        }

        Vector2 newVelocity = new Vector2(xSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = newVelocity;

        //점프
        if (Input.GetKeyDown(KeyCode.Space) == true && jumpcount < 2)
        {
            isRising = true;
            jumpcount += 1;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
        //질풍참
        //좌상
        if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) && Sdelayon == false)
        {
            transform.Translate(new Vector2(- 4f, 4f));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = false;
            obj.transform.rotation = Quaternion.Euler(0, 0, 135);
            Instantiate(obj, transform.position, obj.transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        //우상
        else if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.D) && Sdelayon == false)
        {
            transform.Translate(new Vector2(4f, 4f));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = false;
            obj.transform.rotation = Quaternion.Euler(0, 0, 45);
            Instantiate(obj, transform.position, obj.transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        //좌하
        else if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.A) && Sdelayon == false)
        {
            transform.Translate(new Vector2(-4f, -4f));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = false;
            obj.transform.rotation = Quaternion.Euler(0, 0, -135);
            Instantiate(obj, transform.position, obj.transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        //우하
        else if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.D) && Sdelayon == false)
        {
            transform.Translate(new Vector2(4f, -4f));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = false;
            obj.transform.rotation = Quaternion.Euler(0, 0, -45);
            Instantiate(obj, transform.position, obj.transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        //우
        else if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.D) == true && Sdelayon == false)
        {
            transform.Translate(new Vector2(6f,0));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = false;
            Instantiate(obj, transform.position, transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        //좌
        else if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.A) == true && Sdelayon == false)
        {
            transform.Translate(new Vector2(-6f, 0));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = true;
            Instantiate(obj, transform.position, transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        //상
        else if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.W) == true && Sdelayon == false)
        {
            transform.Translate(new Vector2(0, 6f));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = false;
            obj.transform.rotation = Quaternion.Euler(0, 0, 90);
            Instantiate(obj, transform.position, obj.transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        //하
        else if (Input.GetKeyDown(KeyCode.LeftShift) == true && Input.GetKey(KeyCode.S) == true && Sdelayon == false)
        {
            transform.Translate(new Vector2(0, -6f));
            GameObject obj = Resources.Load<GameObject>("Prefabs/Slash");
            Slash.flipX = false;
            obj.transform.rotation = Quaternion.Euler(0, 0, -90);
            Instantiate(obj, transform.position, obj.transform.rotation);
            Sdelayon = true;
            rigidbody2D.velocity = Vector2.zero;
        }
        if (Sdelay <= 1)
        {
            Sdelayon = false;
            Sdelay = 2;
        }
        else if (Sdelayon == false)
        {
            Sdelay = 2;
        }
        if (Sdelayon == true)
        {
            Sdelay -= Time.deltaTime;
        }

        //마우스 좌클릭 공격
        if (Input.GetKey(KeyCode.Mouse0) == true && ldelayon == false && rdelayon == false && bullet != 0 && Adelay == false)
        {
            if (spriteRenderer.flipX == true)
            {
                scrolling.speed = 30;
            }
            else
            {
                scrolling.speed = -30;
            }
            bullet -= 1;
            GameObject bullet1 = Instantiate(shuriken, transform.position, transform.rotation);
            StartCoroutine("LeftClick");
            ldelayon = true;
        }
        if (ldelayon == true)
        {
            leftdelay += Time.deltaTime;
            if (leftdelay >= 0.88)
            {
                ldelayon = false;
                leftdelay = 0;
            }
        }
        //마우스 우클릭 공격
        if (Input.GetKey(KeyCode.Mouse1) == true && ldelayon == false && rdelayon == false && bullet != 0 && Adelay == false)
        {
            if (spriteRenderer.flipX == true)
            {
                scrolling.speed = 30;
            }
            else
            {
                scrolling.speed = -30;
            }
            bullet -= 3;
            GameObject bulletT = Instantiate(shuriken, transform.position, Quaternion.Euler(0, 0, 15));
            GameObject bulletM = Instantiate(shuriken, transform.position, transform.rotation);
            GameObject bulletB = Instantiate(shuriken, transform.position, Quaternion.Euler(0, 0, -15));
            rdelayon = true;
        }
        if (rdelayon == true)
        {
            rightdelay += Time.deltaTime;
            if (rightdelay >= 0.68)
            {
                rdelayon = false;
                rightdelay = 0;
            }
        }
        //재장전
        if (Input.GetKeyDown(KeyCode.R) == true && bullet != 30)
        {
            Adelay = true;
            StartCoroutine("Reload");
            bullet = maxbullet;
        }
        //튕겨내기
        if (Input.GetKeyDown(KeyCode.E) == true && deflectCool == false)
        {
            shield.SetActive(true);
            deflect = true;
            deflectCool = true;
            Adelay = true;
            StartCoroutine("Deflect");
            StartCoroutine("DeflectCool");
        }
        if (deflectCool == true)
        {
            deflectcoolUI -= Time.deltaTime;
        }
        else
        {
            deflectcoolUI = 9f;
        }
        //페이드
        if (fading == true)
        {
            if (fade < 0.5f)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f - fade);
            }
            else
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, fade);
                if (fade > 1f)
                {
                    fade = 0;
                }
            }
        }
        fade += Time.deltaTime;
        //얼리기
        if(freeze == true)
        {
            rigidbody2D.velocity = Vector2.zero;
            isRising = true;
            spriteRenderer.flipX = false;
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        //애니메이터
        animator.SetBool("Jumping", isRising);
        animator.SetBool("Moving", isMoving);
    }
    //좌클릭 코루틴
    IEnumerator LeftClick()
    {
        yield return new WaitForSeconds(0.1f);
        bullet -= 1;
        GameObject bullet1 = Instantiate(shuriken, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        bullet -= 1;
        GameObject bullet2 = Instantiate(shuriken, transform.position, transform.rotation);
        yield break;
    }
    //재장전 코루틴
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.0f);
        Adelay = false;
    }
    //튕겨내기 코루틴
    IEnumerator Deflect()
    {
        yield return new WaitForSeconds(2.0f);
        shield.SetActive(false);
        deflect = false;
        Adelay = false;
    }
    IEnumerator DeflectCool()
    {
        yield return new WaitForSeconds(8.0f);
        deflectCool = false;
    }
    //데미지 코루틴
    IEnumerator OnDamageC()
    {
        yield return new WaitForSeconds(0.5f);
        damagedObj.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        hitplatform.SetActive(false);
        fading = false;
        spriteRenderer.color = new Color(1f, 1f, 1f, 255);
        gameObject.layer = 0;
    }
    IEnumerator FreezeC()
    {
        yield return new WaitForSeconds(3.0f);
        freeze = false;
    }
    //데미지메서드
    void OnDamage()
    {
        damagedObj.SetActive(true);
        animator.SetTrigger("Damaged");
        hitplatform.SetActive(true);
        gameObject.layer = 11;
        StartCoroutine("OnDamageC");
        fading = true;
    }
    //위치값 고정 메서드
    public void Freeze()
    {
        freeze = true;
        StartCoroutine("FreezeC");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //경사감지
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isRising = false;
            jumpcount = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(shield.activeInHierarchy == false)
        {
            if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy"||collision.gameObject.tag == "Bullet")
            {
                OnDamage();
            }
        }
        else if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy")
        {
            OnDamage();
        }
    }

}
