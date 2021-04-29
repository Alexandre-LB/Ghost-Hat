using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color defaultcolor;
    Color ghostColor;
    bool ghost = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultcolor = spriteRenderer.color;
        ghostColor = new Color(0, 255, 255, 100);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LightAura") && ghost == true)
        {
            spriteRenderer.color = ghostColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LightAura") && ghost == true)
        {
            spriteRenderer.color = defaultcolor;
        }
    }
}
