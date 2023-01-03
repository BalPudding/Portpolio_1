using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PlayerC playerC;
    float spawnCool;
    public float min;
    public float max;
    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
            if (gameObject.transform.position.x - playerC.transform.position.x <= 13f && gameObject.transform.position.x - playerC.transform.position.x >= -13f)
            {
                spawnCool -= Time.deltaTime;
                if (spawnCool <= 0)
                {
                    spawnCool = Random.Range(min, max);
                    GameObject obj = Resources.Load<GameObject>("Prefabs/Enemy");
                    Instantiate(obj, transform.position, transform.rotation);
                }
            }
    }
}
