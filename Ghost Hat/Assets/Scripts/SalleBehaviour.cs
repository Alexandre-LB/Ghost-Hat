using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleBehaviour : MonoBehaviour
{
    int nbFant�me = 0;
    public GameObject fant�me;
    public GameObject fant�me1;
    public GameObject fant�me2;
    public GameObject fant�me3;
    List<GameObject> fant�mes;
    List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        nbFant�me = Random.Range(1, 5);
        Debug.Log(nbFant�me);
        fant�mes.Add(fant�me);
        fant�mes.Add(fant�me1);
        fant�mes.Add(fant�me2);
        fant�mes.Add(fant�me3);
        MainFant�me();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainFant�me()
    {
        for(int i = nbFant�me; 0 < i; i=-1)
        {
            switch(i)
            {
                case 4:
                    ObjectFant�me();
                    break;
                case 3:
                    ObjectFant�me();
                    break;
                case 2:
                    ObjectFant�me();
                    break;
                case 1:
                    ObjectFant�me();
                    break;
            }
        }
    }
    void ObjectFant�me()
    {
        int indexO = objects.Count;
        int indexF = fant�mes.Count;
        int nbAleaO = Random.Range(0, indexO + 1);
        int nbAleaF = Random.Range(0, indexF + 1);
        GameObject AleaObject = objects[nbAleaO];
        GameObject AleaFant�me = objects[nbAleaF];
        //AleaObject = 
        //objects.RemoveAt()
    }
}
