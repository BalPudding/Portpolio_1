using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperBullet3D : MonoBehaviour
{
    public float speed;
    public int health;

    private void Awake()
    {
    }
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
       if(CinemaCon.Instance.destroyBullet == true)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shuriken")
        {
            health -= 1;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
     if(other.gameObject.tag == "Slash")
        {
            Destroy(gameObject);
        }   
    }
}
