using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int direction = 1;
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
    }
}
