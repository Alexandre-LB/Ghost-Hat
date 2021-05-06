using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Vector2[,] tabSalle;
    public List<SalleData> salles = new List<SalleData>();
    int currentX = 0;
    int currentY = 0;
    int nbSalleX;
    int nbSalleY;
    int k = 0;
    Vector2 vector2 = new Vector2();
    

    // Start is called before the first frame update
    void Start()
    {
        nbSalleX = salles.Count/2 + 1;
        nbSalleY = salles.Count / 2 ;
        tabSalle = new Vector2[nbSalleY, nbSalleX];
        for (int i = 0; i < nbSalleY; i++)
        {
            for (int j = 0; j < nbSalleX; j++)
            {
                tabSalle[i, j] = salles[k].position.position;
                k += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(currentY < nbSalleY)
            {
                currentY++;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentY > 0)
            {
                currentY--;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(currentX < nbSalleX)
            {
                currentX++;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentX > 0)
            {
                currentX--;
            }
        }
        Camera.main.transform.position = tabSalle[currentY, currentX];
    }
}
[Serializable]
public class SalleData
{
    public Transform position;
    public int posX;
    public int posY;
}
