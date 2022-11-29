using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Shield")
        {
            GameObject Obj = Resources.Load<GameObject>("Prefabs/Deflect");
            Instantiate(Obj, new Vector3(transform.position.x-0.5f,transform.position.y,0),transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            UIManager.Instance.currentHP -= damage;
            GameObject Obj = Resources.Load<GameObject>("Prefabs/Deflect");
            Instantiate(Obj, new Vector3(transform.position.x - 0.5f, transform.position.y, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}
