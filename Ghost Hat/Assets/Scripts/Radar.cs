using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : Item
{
    public Animator anim;
    private Transform ghostObject;

    void Start()
    {
        this.ghostObject = GameObject.FindGameObjectWithTag("HouseObject").transform;
    }

    void Update()
    {
        Mouse();

        float distToPlayer = Vector2.Distance(transform.position, ghostObject.position);
        anim.speed = 2 / distToPlayer;
    }
}
