using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFreezer : MonoBehaviour
{
    public GameObject reaper;
    private void Awake()
    {
    }
    void IntroFreeze()
    {
        PlayerC.Instance.Freeze();
    }
    void CallReaper()
    {
        this.gameObject.SetActive(false);
        reaper.SetActive(true);
    }
}
