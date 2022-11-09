using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shield")
        {
            GameObject Obj = Resources.Load<GameObject>("Prefabs/Deflect");
            Instantiate(Obj, new Vector3(transform.position.x-0.5f,transform.position.y,0),transform.rotation);
            Destroy(gameObject);
        }
        
        if(collision.gameObject.tag =="Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
