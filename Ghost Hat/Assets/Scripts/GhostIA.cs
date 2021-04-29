using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhostIA : MonoBehaviour
{
    public HouseBehaviour maison;
    public GhostIA ghost;
    public GameObject fantome;
    public FantomeType type;
    Salle ownRoom;
    int rand;
    private void Awake()
    {
        ownRoom = maison.listSalle[Random.Range(0, maison.listSalle.Count)];
        ownRoom.ghostLimit.Add(ghost);
        rand = Random.Range(0, ownRoom.listObject.Count);
        ownRoom.listObject[rand].fantome = ghost;
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
        fantome.SetActive(true);
    }
}
public enum FantomeType
{
    Gourmand,
    Oreille,
    Timide,
    Invisible
}
