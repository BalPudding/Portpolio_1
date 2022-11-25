using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PlayerC playerC;
    float spawnCool;
    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerC>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.freeze != true)
        {
            if (gameObject.transform.position.x - playerC.transform.position.x <= 13f && gameObject.transform.position.x - playerC.transform.position.x >= -13f)
            {
                spawnCool -= Time.deltaTime;
                if (spawnCool <= 0)
                {
                    spawnCool = Random.Range(2.0f, 3.0f);
                    GameObject obj = Resources.Load<GameObject>("Prefabs/Enemy");
                    Instantiate(obj, transform.position, transform.rotation);
                }
            }
            else
            {
                spawnCool = Random.Range(2.0f, 3.0f);
            }
        }
    }
}
