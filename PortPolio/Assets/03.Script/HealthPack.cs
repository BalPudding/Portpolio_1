using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public bool BigSize;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (BigSize == true)
            {
                UIManager.Instance.currentHP += 250;
            }
            else
            {
                UIManager.Instance.currentHP += 75;
            }
            GameObject Obj = Resources.Load<GameObject>("Prefabs/Healing");
            Instantiate(Obj, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
