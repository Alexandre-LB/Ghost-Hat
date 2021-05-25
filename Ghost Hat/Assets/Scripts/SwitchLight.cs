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
    
    // Start is called before the first frame update
    void Start()
    {
        LightOff.SetActive(false);
    }

    // Update is called once per frame
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
