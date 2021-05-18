using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    public List<Salle> listSalle = new List<Salle>();
    public List<GhostIA> listFantome = new List<GhostIA>();
    int oreille;
    int gateau;
    int timide;
    int lumiere;

    void Start()
    {
        GhostNumber();
    }
    public void GhostNumber()
    {
        oreille = 0;
        gateau = 0;
        timide = 0;
        lumiere = 0;
        for(int i = 0; i < listFantome.Count; i++)
        {
            if(listFantome[i].type == FantomeType.Gourmand)
            {
                gateau++;
            }
            else if(listFantome[i].type == FantomeType.Invisible)
            {
                lumiere++;
            }
            else if (listFantome[i].type == FantomeType.Oreille)
            {
                oreille++;
            }
            else if (listFantome[i].type == FantomeType.Timide)
            {
                timide++;
            }
        }
        UIManager.Instance.gluttonyCount = gateau;
        UIManager.Instance.shyCount = timide;
        UIManager.Instance.earCount = oreille;
        UIManager.Instance.invisibleCount = lumiere;
    }
}
