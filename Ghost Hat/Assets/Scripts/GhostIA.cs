using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhostIA : MonoBehaviour
{
    public GhostIA ghost;
    public FantomeType type;
    public HouseBehaviour maison;
    Object objet;
    Salle ownRoom;
    int rand;
    private void Awake()
    {
        rand = Random.Range(0, maison.listSalle.Count);
        ownRoom = maison.listSalle[rand];
        ownRoom.ghostLimit.Add(ghost);
        rand = Random.Range(0, ownRoom.listObject.Count);
        objet = ownRoom.listObject[rand];
        objet.fantome = ghost;
        ownRoom.listObject.RemoveAt(rand);        
    }
    void Update()
    {
        switch (type)
        {
            case FantomeType.Gourmand:
                break;
            case FantomeType.Oreille:
                break;
            case FantomeType.Timide:
                break;
            case FantomeType.Invisible:
                break;
        }   
    }
    public void ActiveGhost()
    {
        //ghost.SetActive(true);
    }
}
public enum FantomeType
{
    Gourmand,
    Oreille,
    Timide,
    Invisible
}
