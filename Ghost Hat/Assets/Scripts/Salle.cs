using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    public HouseBehaviour maison;
    public Salle room;
    public bool cuisine;
    public Transform position;
    public int posX;
    public int posY;
    [HideInInspector]
    public bool cake;
    [HideInInspector]
    public bool gourmand;
    public List<ObjectClass> listObject = new List<ObjectClass>();
    public List<GhostIA> ghostLimit = new List<GhostIA>();

    private void Update()
    {
        if (ghostLimit.Count == 3)
        {
            maison.listSalle.Remove(room);
        }
    }
}
