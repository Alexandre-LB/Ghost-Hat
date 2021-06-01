using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    float timerCake = 0;
    public HouseBehaviour maison;
    public Salle room;
    public bool cuisine;
    public Transform position;
    public int posX;
    public int posY;
    [HideInInspector]
    public bool cameraStand;
    [HideInInspector]
    public Cake gateau;
    [HideInInspector]
    public bool lumiere = true;
    [HideInInspector]
    public GhostIA gourmand;
    [HideInInspector]
    public GhostIA timide;
    public List<ObjectClass> listObject = new List<ObjectClass>();
    [HideInInspector]
    public List<GhostIA> ghostList = new List<GhostIA>();

    private void Start()
    {
        lumiere = true;    
    }

    private void Update()
    {
        if (ghostList.Count == 3)
        {
            maison.listSalle.Remove(room);
        }

        if(gateau != null && gourmand != null)
        {
            timerCake += Time.deltaTime;
            if (timerCake > 5.0f)
            {
                gourmand.Manger();
            }
        }

        if(lumiere == false && cameraStand == true && timide != null)
        {
            timide.Apparait();
        }
    }
}
