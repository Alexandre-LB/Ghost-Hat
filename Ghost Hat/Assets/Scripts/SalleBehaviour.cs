using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleBehaviour : MonoBehaviour
{
    int nbFant�me = 0;
    //public List<GameObject> ghostList = new List<GameObject>();
    public List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //nbFant�me = ghostList.Count;
        Debug.Log(nbFant�me);
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
        /*int indexO = objects.Count;
        Debug.Log(indexO);
        int indexF = ghostList.Count;
        Debug.Log(indexF);
        int nbAleaO = Random.Range(0, indexO-1);
        int nbAleaF = Random.Range(0, indexF-1);
        GameObject AleaObject = objects[nbAleaO];
        GameObject AleaFant�me = objects[nbAleaF];
        AleaFant�me.transform.parent = AleaObject.transform;
        objects.RemoveAt(nbAleaO);
        ghostList.RemoveAt(nbAleaF);*/
    }
}
