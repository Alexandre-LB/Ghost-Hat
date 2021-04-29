using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhostIA : MonoBehaviour
{
    public GameObject ghost;
    public FantomeType type;
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
        ghost.SetActive(true);
    }
}
public enum FantomeType
{
    Gourmand,
    Oreille,
    Timide,
    Invisible
}
