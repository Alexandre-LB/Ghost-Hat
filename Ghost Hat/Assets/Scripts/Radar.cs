using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : Item
{
    public Sprite radar;
    public Sprite radarGhost;
    private Transform ghostObject;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        Mouse(0.05f, 0);
        if (GameObject.FindGameObjectWithTag("Oreille"))
        {
            this.ghostObject = GameObject.FindGameObjectWithTag("Oreille").transform;
            float distToPlayer = Vector2.Distance(transform.position, ghostObject.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Oreille"))
        {
            spriteRenderer.sprite = radarGhost;
        }
    } 
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Oreille"))
        {
            spriteRenderer.sprite = radar;
        }
    }
}
