using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float fade;
    public int speed;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
            if (fade < 0.5f)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f - fade);
            }
            else
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, fade);
                if (fade > 1f)
                {
                    fade = 0;
                }
            }
            fade += Time.deltaTime*speed;
        }
}
