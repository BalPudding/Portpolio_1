using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperShooter3D : MonoBehaviour
{
    public GameObject bullet;
    public float shootTime;
    GameObject gen;
    float startRange;
    private void Awake()
    {
        gen = GameObject.Find("genji_MainModel");
    }
    private void OnEnable()
    {
        startRange = Random.Range(0, shootTime)+1;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(gen.transform.position.x, gen.transform.position.y + 1, gen.transform.position.z));
        startRange -= Time.deltaTime;
        if(startRange <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(transform.localEulerAngles.x+90,transform.localEulerAngles.y,0));
            startRange = Random.Range(0, shootTime);
        }
    }
}
