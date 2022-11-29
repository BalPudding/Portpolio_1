using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reaper_Bullet : MonoBehaviour
{
    private void Start()
    {
        Vector3 dir = PlayerC.Instance.transform.position - transform.position;

        //== 타겟 방향으로 회전함 ==//
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
