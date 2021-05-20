using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    public int x;
    public int y;
    int compteur;
    public Salle[,] salle;
    public List<Salle> listSalle = new List<Salle>();
    public List<GhostIA> listFantome = new List<GhostIA>();
    int oreille;
    int gateau;
    int timide;
    int lumiere;
    float score;

    void Awake()
    {
        compteur = 0;
        salle = new Salle[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                salle[i, j].maison = this;
                salle[i, j] = listSalle[compteur];
                compteur++;
            }
        }
        for (int i = 0; i < listFantome.Count; i++)
        {
            listFantome[i].maison = this;
            listFantome[i].ChooseObject();
        }
    }
    void Start()
    {
        GhostNumber();
    }
    void Update()
    {
        if (listFantome.Count == 0)
        {
            score = UIManager.Instance.tictac * UIManager.Instance.panik;
            GameManager.Instance.ChangeState(GameState.MainMenu);
            UIManager.Instance.victoryScreen.SetActive(true);
            if(score >= 10000)
            {
                UIManager.Instance.star2.SetActive(true);
                if(score >= 20000)
                {
                    UIManager.Instance.star3.SetActive(true);
                }
            }
            UIManager.Instance.score.text = (int)score + " points";
        }
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
