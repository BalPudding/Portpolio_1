using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public GameObject shuriken;
    public GameObject shield;
    public GameObject hitplatform;
    public GameObject damagedObj;
    public float jumpForce;
    public int jumpcount;
    bool isSlide;
    bool isRising;
    bool onGround = true;
    float leftdelay;
    bool ldelayon;
    float rightdelay;
    bool rdelayon;
    int bullet = 30;
    int maxbullet = 30;
    bool deflect;
    bool deflectCool;
    bool Adelay;
    bool damaged;
    float fade;
    bool fading;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //점프
        if (Input.GetKeyDown(KeyCode.Space) == true && jumpcount < 2)
        {
            isRising = true;
            onGround = false;
            jumpcount += 1;
            rigidbody2D.velocity = Vector2.zero;

            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
        //슬라이딩
        if (Input.GetKey(KeyCode.LeftControl) == true && onGround == true)
        {
            isSlide = true;
            boxCollider2D.offset = new Vector2(0, -0.45f);
            boxCollider2D.size = new Vector2(1.9f, 0.9f);
        }
        else
        {
            isSlide = false;
            boxCollider2D.offset = new Vector2(0, 0f);
            boxCollider2D.size = new Vector2(1.3f, 1.8f);
        }
        //마우스 좌클릭 공격
        if (Input.GetKey(KeyCode.Mouse0) == true && ldelayon == false && rdelayon == false && bullet != 0 && Adelay == false)
        {
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
        //애니메이터
        animator.SetBool("Sliding", isSlide);
        animator.SetBool("Jumping", isRising);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //경사감지
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isRising = false;
            onGround = true;
            jumpcount = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle"|| collision.gameObject.tag == "Enemy")
        {
            OnDamage();
        }
    }
}
