using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    void Update()
    {
        if (UIManager.Instance.currentHP <= 0)
        {
            for (int i = 0; i < 12; i++)
            {
                int j = i * 30;
                GameObject Obj = Resources.Load<GameObject>("Prefabs/Effect_Die");
                Instantiate(Obj, transform.position, Quaternion.Euler(0, 0, j));
            }
            Destroy(gameObject);
        }
    }
}
