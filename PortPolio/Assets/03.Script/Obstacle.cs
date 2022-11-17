using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool cankill;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shuriken"&& cankill == true)
        {
            GameObject Obj = Resources.Load<GameObject>("Prefabs/Enemy_Destroy_small");
            Instantiate(Obj, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
