using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : Item
{
    public Sprite radar;
    public Sprite radarGhost;
    private Transform ghostObject;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Oreille"))
        {
            this.ghostObject = GameObject.FindGameObjectWithTag("Oreille").transform;
        }
    }

    void Update()
    {
        Mouse(0.05f, 0);
        if (ghostObject != null)
        {
            float distToPlayer = Vector2.Distance(transform.position, ghostObject.position);

            if (distToPlayer < 1)
            {
                spriteRenderer.sprite = radarGhost;
            }
            else
            {
                spriteRenderer.sprite = radar;
            }
        }
    }
}
