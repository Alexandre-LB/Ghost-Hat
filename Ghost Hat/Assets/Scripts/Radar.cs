using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : Item
{
    public Animator anim;
    private Transform ghostObject;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Oreille"))
        {
            this.ghostObject = GameObject.FindGameObjectWithTag("Oreille").transform;
        }
    }

    void Update()
    {
        Mouse();
        if (ghostObject != null)
        {
            float distToPlayer = Vector2.Distance(transform.position, ghostObject.position);
            anim.speed = 2 / distToPlayer;
        }
    }
}
