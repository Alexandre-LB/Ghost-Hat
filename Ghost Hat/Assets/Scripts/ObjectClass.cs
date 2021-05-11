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

        if (fantome != null && fantome.type == FantomeType.Gourmand)
        {
            this.gameObject.tag = "Gateau";
        }
        if (fantome != null && fantome.type == FantomeType.Oreille)
        {
            this.gameObject.tag = "Oreille";
        }
        if (fantome != null && fantome.type == FantomeType.Invisible)
        {
            this.gameObject.tag = "Lumiere";
        }
        if (fantome != null && fantome.type == FantomeType.Timide)
        {
            this.gameObject.tag = "Camera";
        }
    }

    private void Update()
    {
        Debug.Log(fantome);
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
        if (collision.CompareTag("LightAura"))
        {
            spriteRenderer.color = defaultcolor;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0) && fantome != null && UIManager.Item == Inventory.None)
        {
            fantome.ActiveGhost();
            fantome = null;
            this.gameObject.tag = "HouseObject";
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
