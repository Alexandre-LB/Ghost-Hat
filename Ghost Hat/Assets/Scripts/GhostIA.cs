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
        ChooseObject();
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
    void ChooseObject()
    {
        ownRoom = maison.listSalle[Random.Range(0, maison.listSalle.Count)];
        if(ghost.type == FantomeType.Gourmand && ownRoom.cuisine)
        {
            ChooseObject();
        }
        else
        {
            ownRoom.ghostLimit.Add(ghost);
            rand = Random.Range(0, ownRoom.listObject.Count);
            ownRoom.listObject[rand].fantome = ghost;
            ownRoom.listObject.RemoveAt(rand);
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
