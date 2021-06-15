using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Quentin et Cédric
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
                if(compteur < listSalle.Count)
                {
                    salle[i, j] = listSalle[compteur];
                    compteur++;
                }
            }
        }
        for (int i = 0; i < listFantome.Count; i++)
        {
            listFantome[i].ChooseObject();
        }
        GameManager.Instance.room = listSalle[0];
    }
    void Start()
    {
        GhostNumber();
    }
    void Update()
    {
        if (listFantome.Count == 0 && GameManager.State == GameState.Game)
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
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 2:
                    if(UIManager.Instance.score1 < score)
                    {
                        UIManager.Instance.score1 = (int)score;
                        UIManager.Instance.score1Text.text = UIManager.Instance.score1 + "points";
                        UIManager.Instance.Level1Star1.SetActive(true);
                        if(UIManager.Instance.score1 >= 10000)
                        {
                            UIManager.Instance.Level1Star2.SetActive(true);
                            if (UIManager.Instance.score1 >= 20000)
                            {
                                UIManager.Instance.Level1Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 3:
                    if (UIManager.Instance.score2 < score)
                    {
                        UIManager.Instance.score2 = (int)score;
                        UIManager.Instance.score2Text.text = UIManager.Instance.score2 + "points";
                        UIManager.Instance.Level2Star1.SetActive(true);
                        if (UIManager.Instance.score2 >= 10000)
                        {
                            UIManager.Instance.Level2Star2.SetActive(true);
                            if (UIManager.Instance.score2 >= 20000)
                            {
                                UIManager.Instance.Level2Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 4:
                    if (UIManager.Instance.score3 < score)
                    {
                        UIManager.Instance.score3 = (int)score;
                        UIManager.Instance.score3Text.text = UIManager.Instance.score3 + "points";
                        UIManager.Instance.Level3Star1.SetActive(true);
                        if (UIManager.Instance.score3 >= 10000)
                        {
                            UIManager.Instance.Level3Star2.SetActive(true);
                            if (UIManager.Instance.score3 >= 20000)
                            {
                                UIManager.Instance.Level3Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 5:
                    if (UIManager.Instance.score4 < score)
                    {
                        UIManager.Instance.score4 = (int)score;
                        UIManager.Instance.score4Text.text = UIManager.Instance.score4 + "points";
                        UIManager.Instance.Level4Star1.SetActive(true);
                        if (UIManager.Instance.score4 >= 10000)
                        {
                            UIManager.Instance.Level4Star2.SetActive(true);
                            if (UIManager.Instance.score4 >= 20000)
                            {
                                UIManager.Instance.Level4Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 6:
                    if (UIManager.Instance.score5 < score)
                    {
                        UIManager.Instance.score5 = (int)score;
                        UIManager.Instance.score5Text.text = UIManager.Instance.score5 + "points";
                        UIManager.Instance.Level5Star1.SetActive(true);
                        if (UIManager.Instance.score5 >= 10000)
                        {
                            UIManager.Instance.Level5Star2.SetActive(true);
                            if (UIManager.Instance.score5 >= 20000)
                            {
                                UIManager.Instance.Level5Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 7:
                    if (UIManager.Instance.score6 < score)
                    {
                        UIManager.Instance.score6 = (int)score;
                        UIManager.Instance.score6Text.text = UIManager.Instance.score6 + "points";
                        UIManager.Instance.Level6Star1.SetActive(true);
                        if (UIManager.Instance.score6 >= 10000)
                        {
                            UIManager.Instance.Level6Star2.SetActive(true);
                            if (UIManager.Instance.score6 >= 20000)
                            {
                                UIManager.Instance.Level6Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 8:
                    if (UIManager.Instance.score7 < score)
                    {
                        UIManager.Instance.score7 = (int)score;
                        UIManager.Instance.score7Text.text = UIManager.Instance.score7 + "points";
                        UIManager.Instance.Level7Star1.SetActive(true);
                        if (UIManager.Instance.score7 >= 10000)
                        {
                            UIManager.Instance.Level7Star2.SetActive(true);
                            if (UIManager.Instance.score7 >= 20000)
                            {
                                UIManager.Instance.Level7Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 9:
                    if (UIManager.Instance.score8 < score)
                    {
                        UIManager.Instance.score8 = (int)score;
                        UIManager.Instance.score8Text.text = UIManager.Instance.score8 + "points";
                        UIManager.Instance.Level8Star1.SetActive(true);
                        if (UIManager.Instance.score8 >= 10000)
                        {
                            UIManager.Instance.Level8Star2.SetActive(true);
                            if (UIManager.Instance.score8 >= 20000)
                            {
                                UIManager.Instance.Level8Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 10:
                    if (UIManager.Instance.score9 < score)
                    {
                        UIManager.Instance.score9 = (int)score;
                        UIManager.Instance.score9Text.text = UIManager.Instance.score9 + "points";
                        UIManager.Instance.Level9Star1.SetActive(true);
                        if (UIManager.Instance.score9 >= 10000)
                        {
                            UIManager.Instance.Level9Star2.SetActive(true);
                            if (UIManager.Instance.score9 >= 20000)
                            {
                                UIManager.Instance.Level9Star3.SetActive(true);
                            }
                        }
                    }
                    break;
                case 11:
                    if (UIManager.Instance.score10 < score)
                    {
                        UIManager.Instance.score10 = (int)score;
                        UIManager.Instance.score10Text.text = UIManager.Instance.score10 + "points";
                        UIManager.Instance.Level10Star1.SetActive(true);
                        if (UIManager.Instance.score10 >= 10000)
                        {
                            UIManager.Instance.Level10Star2.SetActive(true);
                            if (UIManager.Instance.score10 >= 20000)
                            {
                                UIManager.Instance.Level10Star3.SetActive(true);
                            }
                        }
                    }
                    break;
            }
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
