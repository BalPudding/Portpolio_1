using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEffect : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float fade;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 2f * Time.deltaTime);
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f - fade);
        fade += Time.deltaTime;
    }
}
