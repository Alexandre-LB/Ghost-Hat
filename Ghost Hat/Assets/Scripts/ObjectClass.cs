using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClass : MonoBehaviour
{
    //[HideInInspector]
    public GhostIA fantome;
    SpriteRenderer spriteRenderer;
    Color defaultcolor;
    Color ghostColor;

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
        if (collision.CompareTag("LightAura") && fantome != null)
        {
            spriteRenderer.color = ghostColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LightAura") && fantome != null)
        {
            spriteRenderer.color = defaultcolor;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0) && fantome != null)
        {
            fantome.ActiveGhost();
        }
        else if (Input.GetMouseButton(0))
        {
            if (UIManager.Instance.panik <= 30)
            {
                UIManager.Instance.panik = 0;
                UIManager.Instance.pointeur.transform.position = new Vector2(710, UIManager.Instance.pointeur.transform.position.y);
            }
            else
            {
                UIManager.Instance.panik -= 30;
                UIManager.Instance.pointeur.transform.position = new Vector2(UIManager.Instance.pointeur.transform.position.x - 150, UIManager.Instance.pointeur.transform.position.y);
            }
        }
    }
}
