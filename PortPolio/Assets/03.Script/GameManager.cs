using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.Instance.currentHP <= 0)
        {
            Invoke("LoadDead",3f);
        }
    }
    void LoadDead()
    {
        UIManager.Instance.currentHP = 200;
        SceneManager.LoadScene("09.Death");
    }
}
