using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMoving : MonoBehaviour
{
    public float maxLeft;
    public float maxRight;
    public float speed;

    public bool first = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));
        if(transform.position.x >= maxRight && first == false)
        {
            first = true;
            speed *= -1;
        }
        if (transform.position.x <= maxLeft && first == false)
        {
            first = true;
            speed *= -1;
        }
        first = false;
    }
}
