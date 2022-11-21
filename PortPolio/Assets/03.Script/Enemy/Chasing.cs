using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    PlayerC playerC;
    private void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, playerC.transform.position, 0.01f);
            }
}
