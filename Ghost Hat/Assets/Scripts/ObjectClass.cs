using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            tag = "Gateau";
        }
        if (fantome != null && fantome.type == FantomeType.Oreille)
        {
            tag = "Oreille";
        }
        if (fantome != null && fantome.type == FantomeType.Invisible)
        {
            tag = "Lumiere";
        }
        if (fantome != null && fantome.type == FantomeType.Timide)
        {
            tag = "Camera";
        }
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LightAura") && this.gameObject.tag == "Lumiere")
        {
            spriteRenderer.color = ghostColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LightAura") && gameObject.tag == "Lumiere")
        {
            spriteRenderer.color = defaultcolor;
        }
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0) && fantome != null && fantome.type != FantomeType.Gourmand && UIManager.Item == Inventory.None)
        {
            fantome.ActiveGhost();
            fantome = null;
            tag = "HouseObject";
        }
        else if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0) && UIManager.Item == Inventory.None)
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
