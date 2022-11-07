using UnityEngine;

public class PlayerC : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;
    Animator animator;
    public GameObject shuriken;
    public GameObject shuriken_spread;
    public float jumpForce;
    public int jumpcount;
    bool isSlide;
    bool isRising = false;
    float leftdelay;
    bool ldelayon;
    float rightdelay;
    bool rdelayon;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //점프
        if (Input.GetKeyDown(KeyCode.Space) == true && jumpcount < 2)
        {
            isRising = true;
            jumpcount += 1;
            rigidbody2D.velocity = Vector2.zero;

            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
        //슬라이딩
        if(Input.GetKey(KeyCode.LeftControl) == true)
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
        if(Input.GetKeyDown(KeyCode.Mouse0) == true && ldelayon == false)
        {
                GameObject bullet = Instantiate(shuriken, transform.position, transform.rotation);
            ldelayon = true;
        }
        if (ldelayon == true)
        {
            leftdelay += Time.deltaTime;
            if(leftdelay >= 0.88)
            {
                ldelayon = false;
                leftdelay = 0;
            }
        }
        //마우스 우클릭 공격
        if (Input.GetKeyDown(KeyCode.Mouse1) == true && rdelayon == false)
        {
            GameObject bullet = Instantiate(shuriken_spread, transform.position, transform.rotation);
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
        //애니메이터
        animator.SetBool("Sliding", isSlide);
        animator.SetBool("Jumping", isRising);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isRising = false;
            jumpcount = 0;
        }
    }
}
