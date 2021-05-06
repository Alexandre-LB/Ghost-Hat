using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform[,] tabSalle;
    public List<SalleData> salles = new List<SalleData>();
    int currentX = 0;
    int currentY = 0;
    int nbSalleX;
    int nbSalleY;

    // Start is called before the first frame update
    void Start()
    {
        nbSalleX = salles.Count/2 +1;
        nbSalleY = salles.Count / 2+1 ;
        tabSalle = new Transform[nbSalleX, nbSalleY];
        for (int i = 0; i < nbSalleY; i++)
        {
            for (int j = 0; j < nbSalleX; j++)
            {
                tabSalle[j, i] = null;
            }
        }
        foreach(SalleData salleData in salles)
        {
            tabSalle[salleData.posX, salleData.posY] = salleData.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if(currentY+1 < nbSalleY)
            {
                currentY++;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (currentY > 0)
            {
                currentY--;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if(currentX+1 < nbSalleX)
            {
                currentX++;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (currentX > 0)
            {
                currentX--;
            }
        }
        if (tabSalle[currentX, currentY] != null)
        {
            Camera.main.transform.position = Vector2.Lerp(transform.position, tabSalle[currentX, currentY].position, Time.deltaTime);
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
[Serializable]
public class SalleData
{
    public Transform position;
    public int posX;
    public int posY;
}
