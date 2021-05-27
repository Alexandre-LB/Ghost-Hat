using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    public GameObject LightOff;
    public Salle salle;
    public SpriteRenderer spriteRenderer;
    public Sprite allumer;
    public Sprite eteins;
    
    void Start()
    {
        LightOff.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && LightOff.activeSelf)
        {
            spriteRenderer.sprite = allumer;
            LightOff.SetActive(false);
            salle.lumiere = true;
        }
        else if (Input.GetMouseButtonUp(0) && !LightOff.activeSelf)
        {
            spriteRenderer.sprite = eteins;
            LightOff.SetActive(true);
            salle.lumiere = false;
        }
    }
}
