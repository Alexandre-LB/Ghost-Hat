using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBox : Item
{
    public float ghost;
    public List<Sprite> states;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.sprite = states[0];
    }

    private void Update()
    {
        Mouse();

        if (ghost == 1)
        {
            spriteRenderer.sprite = states[1];
        }
        else if (ghost == 2)
        {
            spriteRenderer.sprite = states[2];
        }
        else if (ghost == 3)
        {
            spriteRenderer.sprite = states[3];
        }
        else if(ghost == 4)
        {
            spriteRenderer.sprite = states[4];
        }
        else
        {
            spriteRenderer.sprite = states[0];
        }
    }
}
