using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float rotate;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotate * Time.deltaTime));
    }
}
