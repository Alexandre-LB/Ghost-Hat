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
        for (int i = 0; i < tabX; i++)
        {
            for (int j = 0; j < tabY; j++)
            {
                GameManager.Instance.cameraRoom[i, j] = false;
            }
        }
    }
}
