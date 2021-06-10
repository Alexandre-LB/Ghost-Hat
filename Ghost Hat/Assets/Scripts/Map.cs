using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("a");
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            transform.Rotate(Vector3.forward * 6);
            Debug.Log("b");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            transform.Rotate(Vector3.back * 6);
        }
    }
}
