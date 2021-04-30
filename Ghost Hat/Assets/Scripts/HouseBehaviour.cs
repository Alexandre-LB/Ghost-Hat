using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    public int tabX;
    public int tabY;
    public List<Salle> listSalle = new List<Salle>();
    public List<GhostIA> listFantome = new List<GhostIA>();
    void Awake()
    {
        GameManager.Instance.cameraRoom = new bool[tabX, tabY];
    }
}
