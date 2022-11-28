using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper_Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
