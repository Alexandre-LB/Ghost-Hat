using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform[,] tabSalle;
    int currentX = 0;
    int currentY = 0;
    int nbSalleX;
    int nbSalleY;
    public HouseBehaviour house;
    bool moving;

    void Awake()
    {
        nbSalleX = house.x/2 +1;
        nbSalleY = house.y / 2+1 ;
        tabSalle = new Transform[nbSalleX, nbSalleY];
        for (int i = 0; i < nbSalleY; i++)
        {
            for (int j = 0; j < nbSalleX; j++)
            {
                tabSalle[j, i] = null;
            }
        }
        foreach(Salle salleData in house.listSalle)
        {
            tabSalle[salleData.posX, salleData.posY] = salleData.position;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && moving == false)
        {
            if(currentY+1 < nbSalleY)
            {
                StartCoroutine(Moving());
                currentY++;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && moving == false)
        {
            if (currentY > 0)
            {
                StartCoroutine(Moving());
                currentY--;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && moving == false)
        {
            if(currentX+1 < nbSalleX)
            {
                StartCoroutine(Moving());
                currentX++;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && moving == false)
        {
            if (currentX > 0)
            {
                StartCoroutine(Moving());
                currentX--;
            }
        }
        if (tabSalle[currentX, currentY] != null)
        {
            Camera.main.transform.position = Vector2.Lerp(transform.position, tabSalle[currentX, currentY].position, 5*Time.deltaTime);
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        GameManager.Instance.room = house.salle[currentX,currentY];

        IEnumerator Moving()
        {
            moving = true;
            yield return new WaitForSeconds(1);
            moving = false;
        }
    }
}

