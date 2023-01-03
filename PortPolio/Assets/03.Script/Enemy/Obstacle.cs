using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool cankill;
    public float damage;
    public float effectSize;
    public int health;
    float destroyRocate;
    private void Start()
    {
        destroyRocate = 13f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shuriken"&& cankill == true)
        {
            GameObject Obj = Resources.Load<GameObject>("Prefabs/Enemy_Destroy_small");
            Obj.transform.localScale = new Vector3(effectSize, effectSize, 1);
            health -= 1;
            if (health <= 0)
            {
                Instantiate(Obj, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "Player")
        {
            UIManager.Instance.currentHP -= damage;
        }
    }
    private void Update()
    {
        if (PlayerC.Instance.transform.position.x - gameObject.transform.position.x >= destroyRocate)
        {
            Destroy(gameObject);
        }
    }
}
