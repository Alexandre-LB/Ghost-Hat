using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salle : MonoBehaviour
{
    public HouseBehaviour maison;
    public Salle room;
    public List<Object> listObject = new List<Object>();
    public List<GhostIA> ghostLimit = new List<GhostIA>();

    private void Update()
    {
        if(ghostLimit.Count == 3)
        {
            maison.listSalle.Remove(room);
        }
    }
}
