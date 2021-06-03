using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : Item
{
    public Animator anim;
    public HouseBehaviour houseObject;
    private float ghostTarget;
    private Vector3 ghostPos;
    private float distToPlayer;

    private void Start()
    {
        this.houseObject = HouseBehaviour.FindObjectOfType<HouseBehaviour>();
    }

    void FixedUpdate()
    {
        Mouse(-0.02f, 1);
        ghostTarget = distToPlayer;
        for (int i = 0; i < houseObject.listFantome.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("Oreille").tag != null && houseObject.listFantome[i].tag == GameObject.FindGameObjectWithTag("Oreille").tag)
            {
                distToPlayer = Vector2.Distance(transform.position, houseObject.listFantome[i].transform.position);
                if (distToPlayer < ghostTarget)
                {
                    ghostTarget = Vector2.Distance(transform.position, houseObject.listFantome[i].transform.position);
                }
            }
        }
        if (ghostTarget > 9)
        {
            anim.speed = 0.5f;
        }
        else
        {
            anim.speed = 3 - Mathf.Sqrt(ghostTarget);
        }
    }
}
