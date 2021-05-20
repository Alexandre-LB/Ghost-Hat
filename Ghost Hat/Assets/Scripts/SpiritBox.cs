using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBox : Item
{
    public float ghost;
    public List<Sprite> states;
    public SpriteRenderer spriteRenderer;
    Salle room;

    void Start()
    {
        spriteRenderer.sprite = states[0];
    }

    private void Update()
    {
        room = GameManager.Instance.room;
        Mouse(0, 0);

        switch (room.ghostList.Count)
        {
            case 1:
                spriteRenderer.sprite = states[1];
                break;
            case 2:
                spriteRenderer.sprite = states[2];
                break;
            case 3:
                spriteRenderer.sprite = states[3];
                break;
            case 4:
                spriteRenderer.sprite = states[4];
                break;
            default:
                spriteRenderer.sprite = states[0];
                break;
        }
    }
}
