using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public GameObject button;
    public Image carte;

    void Update()
    {
        Debug.Log(carte.rectTransform.position);
        if(GameManager.State == GameState.MainMenu)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && carte.rectTransform.position.x <= 3298)
            {
                Debug.Log(transform.position);
                carte.rectTransform.position = new Vector2(carte.rectTransform.position.x + 40, carte.rectTransform.position.y);
                button.transform.position = new Vector2(button.transform.position.x + 40, button.transform.position.y);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f && carte.rectTransform.position.x >= -1341)
            {
                carte.rectTransform.position = new Vector2(carte.rectTransform.position.x - 40, carte.rectTransform.position.y);
                button.transform.position = new Vector2(button.transform.position.x - 40, button.transform.position.y);
            }
        }
    }
}
