using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleBehaviour : MonoBehaviour
{
    int nbFantôme = 0;
    public GameObject fantôme;
    public GameObject fantôme1;
    public GameObject fantôme2;
    public GameObject fantôme3;
    List<GameObject> fantômes;
    List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        nbFantôme = Random.Range(1, 5);
        Debug.Log(nbFantôme);
        fantômes.Add(fantôme);
        fantômes.Add(fantôme1);
        fantômes.Add(fantôme2);
        fantômes.Add(fantôme3);
        MainFantôme();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainFantôme()
    {
        for(int i = nbFantôme; 0 < i; i=-1)
        {
            switch(i)
            {
                case 4:
                    ObjectFantôme();
                    break;
                case 3:
                    ObjectFantôme();
                    break;
                case 2:
                    ObjectFantôme();
                    break;
                case 1:
                    ObjectFantôme();
                    break;
            }
        }
    }
    void ObjectFantôme()
    {
        int indexO = objects.Count;
        int indexF = fantômes.Count;
        int nbAleaO = Random.Range(0, indexO + 1);
        int nbAleaF = Random.Range(0, indexF + 1);
        GameObject AleaObject = objects[nbAleaO];
        GameObject AleaFantôme = objects[nbAleaF];
        //AleaObject = 
        //objects.RemoveAt()
    }
}
