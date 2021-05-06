using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhostIA : MonoBehaviour
{
    public HouseBehaviour maison;
    public GameObject fantome;
    public FantomeType type;
    public int speed;
    Rigidbody2D rb;
    Vector2 newPos;
    bool visible;
    Salle ownRoom;
    int rand;

    int mouvX;
    int mouvY;
    private void Awake()
    {
        visible = false;
        rb = GetComponent<Rigidbody2D>();
        newPos = rb.position;
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
        if (visible)
        {
            mouvX = Random.Range((int)ownRoom.transform.position.x - 930, (int)ownRoom.transform.position.x + 930);
            mouvY = Random.Range((int)ownRoom.transform.position.y - 510, (int)ownRoom.transform.position.y + 510);
            while(transform.position.x != mouvX || transform.position.y != mouvY)
            {
                newPos.x -= newPos.x + Time.deltaTime * speed; 
                newPos.y -= newPos.y + Time.deltaTime * speed;
                transform.position = newPos;
            }
        }
    }
    public void ChooseObject()
    {
        ownRoom = maison.listSalle[Random.Range(0, maison.listSalle.Count)];
        if(type == FantomeType.Gourmand && ownRoom.cuisine || type == FantomeType.Gourmand && ownRoom.gourmand)
        {
            ChooseObject();
        }
        else
        {
            ownRoom.ghostLimit.Add(this);
            rand = Random.Range(0, ownRoom.listObject.Count);
            ownRoom.listObject[rand].fantome = this;
            ownRoom.listObject.RemoveAt(rand);
            if(type == FantomeType.Gourmand)
            {
                ownRoom.gourmand = true;
            }
            Instantiate(this, ownRoom.listObject[rand].transform.position, Quaternion.identity);
        }
    }
    public void ActiveGhost()
    {
        visible = true;
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
