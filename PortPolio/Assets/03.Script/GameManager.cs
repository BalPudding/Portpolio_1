using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�̱���
    private static GameManager instance = null;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    //��������1����
    public void GoStage_01()
    {
        SceneManager.LoadScene("01.Stage01");
    }
    //���θ޴���
    public void GoMainMenu()
    {
        SceneManager.LoadScene("00.Intro");
    }
    //���������
    public void LoadDead()
    {
        SceneManager.LoadScene("09.Death");
    }
    //���Ӳ���
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
