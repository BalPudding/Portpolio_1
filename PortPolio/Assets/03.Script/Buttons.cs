using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject howtoplay;
    public void StartButton()
    {
        GameManager.Instance.GoStage_01();
    }
    public void OnHowToPlayButton()
    {
        howtoplay.SetActive(true);
    }
    public void OffHowToPlayButton()
    {
        howtoplay.SetActive(false);
    }
    public void MainMenuButton()
    {
        GameManager.Instance.GoMainMenu();
    }
    public void EndGame()
    {
        GameManager.Instance.QuitGame();
    }
}
