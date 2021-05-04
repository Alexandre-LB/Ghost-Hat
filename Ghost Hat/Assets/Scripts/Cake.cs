using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : Item
{
    private bool move;

    void Start()
    {
        
    }

    void Update()
    {
        if (move == false)
        {
            Mouse();
        }

        if (Input.GetMouseButton(0))
        {
            move = true;
        }
    }
}
