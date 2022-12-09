using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글턴
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
    //스테이지1으로
    public void GoStage_01()
    {
        SceneManager.LoadScene("01.Stage01");
    }
    //메인메뉴로
    public void GoMainMenu()
    {
        SceneManager.LoadScene("00.Intro");
    }
    //데드씬으로
    public void LoadDead()
    {
        SceneManager.LoadScene("09.Death");
    }
    //게임끄기
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
