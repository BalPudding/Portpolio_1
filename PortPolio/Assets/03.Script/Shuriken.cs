using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Obstacle")
        {
            GameObject obj = Resources.Load<GameObject>("Prefabs/DealDamage");
            Instantiate(obj,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
