using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutTimeCheck : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CinemaCon.Instance.outTimecheck >=5.5f)
        {
            animator.SetTrigger("NowOut"); 
        }
    }
}
