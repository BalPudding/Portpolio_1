using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling3D : MonoBehaviour
{
    public float bulletSpeed;
    void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime,0,0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle")
        {
            GameObject obj = Resources.Load<GameObject>("Prefabs/DealDamage");
            Instantiate(obj, transform.position, Quaternion.Euler(0,0,0));
            Destroy(gameObject);
        }
    }
}
