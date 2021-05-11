using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    public GameObject LightOff;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && LightOff.activeSelf)
        {
            LightOff.SetActive(false);
        }
        else if (Input.GetMouseButtonUp(0) && !LightOff.activeSelf)
        {
            LightOff.SetActive(true);
        }
    }
}