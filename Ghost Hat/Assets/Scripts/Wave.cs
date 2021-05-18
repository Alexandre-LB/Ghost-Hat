using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : Item
{
    public Animator anim;
    private Transform ghostObject;

    void Update()
    {
        Mouse(-0.02f, 1);
        if (GameObject.FindGameObjectWithTag("Oreille"))
        {
            this.ghostObject = GameObject.FindGameObjectWithTag("Oreille").transform;
        }
        if (ghostObject != null)
        {
            float distToPlayer = Vector2.Distance(transform.position, ghostObject.position);
            anim.speed = 2 / distToPlayer;
        }
    }
}
