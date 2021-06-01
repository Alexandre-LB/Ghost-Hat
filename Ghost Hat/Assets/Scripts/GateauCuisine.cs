using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateauCuisine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            UIManager.Instance.cake.SetActive(true);
            Destroy(this);
        }
    }
}
