using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GhostIA : MonoBehaviour
{
    public HouseBehaviour maison;
    public GameObject fantome;
    public FantomeType type;
    public int speed;
    Vector2 newPos;
    [HideInInspector]
    public bool visible;
    Salle ownRoom;
    int rand;
    Rigidbody2D rb;
    bool rushCake;
    float moveTimer = 0;
    public AudioClip ghostSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        visible = false;
    }
    void Update()
    {
        moveTimer += Time.deltaTime;
        if (rushCake)
        {
            fantome.transform.position = Vector2.Lerp(transform.position, ownRoom.gateau.transform.position, Time.deltaTime);
        }
        if (visible && moveTimer > 1)
        {
            if (transform.position.x < ownRoom.transform.position.x - 4 && transform.position.y < ownRoom.transform.position.y - 2)
            {
                newPos = new Vector2(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            }
            else if (transform.position.x < ownRoom.transform.position.x - 4 && transform.position.y > ownRoom.transform.position.y + 2)
            {
                newPos = new Vector2(Random.Range(0.1f, 1f), Random.Range(-1f, -0.1f));
            }
            else if (transform.position.x > ownRoom.transform.position.x + 4 && transform.position.y < ownRoom.transform.position.y - 2)
            {
                newPos = new Vector2(Random.Range(-1f, -0.1f), Random.Range(0.1f, 1f));
            }
            else if (transform.position.x > ownRoom.transform.position.x + 4 && transform.position.y > ownRoom.transform.position.y + 2)
            {
                newPos = new Vector2(Random.Range(-1f, -0.1f), Random.Range(-1f, -0.1f));
            }
            else if(transform.position.x < ownRoom.transform.position.x - 4)
            {
                newPos = new Vector2(Random.Range(0.1f, 1f), Random.Range(-1f, 1f));
            }
            else if (transform.position.x > ownRoom.transform.position.x + 4)
            {
                newPos = new Vector2(Random.Range(-1f, -0.1f), Random.Range(-1f, 1f));
            }
            else if (transform.position.y < ownRoom.transform.position.y - 2)
            {
                newPos = new Vector2(Random.Range(-1f, 1f), Random.Range(0.1f, 1f));
            }
            else if (transform.position.y > ownRoom.transform.position.x + 2)
            {
                newPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, -0.1f));
            }
            else
            {
                newPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            }
            moveTimer = 0;
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(newPos * speed);
        rb.velocity = Vector2.zero;
    }
    public void ChooseObject()
    {
        ownRoom = maison.listSalle[Random.Range(0, maison.listSalle.Count)];
        if(type == FantomeType.Gourmand && (ownRoom.cuisine || ownRoom.gourmand != null) || type == FantomeType.Timide && ownRoom.timide != null)
        {
            ChooseObject();
        }
        else
        {
            ownRoom.ghostList.Add(this);
            rand = Random.Range(0, ownRoom.listObject.Count);
            ownRoom.listObject[rand].fantome = this;
            transform.position = ownRoom.listObject[rand].transform.position;
            ownRoom.listObject.RemoveAt(rand);
            if(type == FantomeType.Gourmand)
            {
                ownRoom.gourmand = this;
            }
            if (type == FantomeType.Timide)
            {
                ownRoom.timide = this;
            }
            fantome.SetActive(false);
        }
    }
    public void ActiveGhost()
    {
        SoundManager.Instance.Playsound(ghostSound, 0.1f);
        visible = true;
        fantome.SetActive(true);
    }
    private void OnMouseDown()
    {
        maison.listFantome.Remove(this);
        ownRoom.ghostList.Remove(this);
        maison.GhostNumber();
        Destroy(this.gameObject);
    }

    public void Manger()
    {
        fantome.SetActive(true);
        ownRoom.gourmand = null;
        rushCake = true;
    }

    public void Apparait()
    {
        if (ownRoom != GameManager.Instance.room)
        {
            fantome.SetActive(true);
        }
        else
        {
            fantome.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cake" && tag == "Gateau")
        {
            Destroy(collision.gameObject);
            rushCake = false;
            visible = true;
        }
    }
}
public enum FantomeType
{
    Gourmand,
    Oreille,
    Timide,
    Invisible
}
