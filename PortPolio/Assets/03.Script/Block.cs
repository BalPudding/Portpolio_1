using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    public bool isOn;
    float cooling;
    bool change;
    bool stopper;
    // Start is called before the first frame update
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        if(isOn == true)
        {
            cooling = 3.1f;
        }
        if(isOn == false)
        {
            cooling = -0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cooling >= 3)
        {
            change = true;
            isOn = true;
        }
        else if (cooling <= 0)
        {
            change = false;
            isOn = false;
        }

        if(change == true)
        {
            cooling -= Time.deltaTime;
        }
        else if(change == false)
        {
            cooling += Time.deltaTime;
        }

        if (isOn == true && stopper == false)
        {
            stopper = true;
            StartCoroutine(IsOnC());
        }
        else if (isOn == false&& stopper == true)
        {
            stopper = false;
            StartCoroutine(IsOffC());
        }
    }
    IEnumerator IsOnC()
    {
        GameObject obj = Resources.Load<GameObject>("Prefabs/BlinkBlock_Effect");
        Instantiate(obj, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = new Color(1f, 1f, 1f, 255f);
        boxCollider2D.enabled = true;
    }
    IEnumerator IsOffC()
    {
        GameObject obj = Resources.Load<GameObject>("Prefabs/BlinkBlock_Effect");
        Instantiate(obj, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        boxCollider2D.enabled = false;
    }
}
