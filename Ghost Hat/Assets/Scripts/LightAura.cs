using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAura : MonoBehaviour
{
    public GameObject lightAura;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.room.lumiere)
        {
            this.gameObject.SetActive(false);
        }
        if (GameManager.Instance.room.lumiere == false)
        {
            this.gameObject.SetActive(true);
        }
    }
}
