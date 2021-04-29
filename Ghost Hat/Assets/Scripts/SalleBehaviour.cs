using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleBehaviour : MonoBehaviour
{
    int nbFantôme = 0;
    //public List<GameObject> ghostList = new List<GameObject>();
    public List<GameObject> objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //nbFantôme = ghostList.Count;
        Debug.Log(nbFantôme);
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
        /*int indexO = objects.Count;
        Debug.Log(indexO);
        int indexF = ghostList.Count;
        Debug.Log(indexF);
        int nbAleaO = Random.Range(0, indexO-1);
        int nbAleaF = Random.Range(0, indexF-1);
        GameObject AleaObject = objects[nbAleaO];
        GameObject AleaFantôme = objects[nbAleaF];
        AleaFantôme.transform.parent = AleaObject.transform;
        objects.RemoveAt(nbAleaO);
        ghostList.RemoveAt(nbAleaF);*/
    }
}
