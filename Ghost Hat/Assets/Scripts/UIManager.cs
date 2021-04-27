using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }
    int panik = 100;
    float panikCountDown = 0;
    public float fear;
    int hour = 19;
    int minUni = 0;
    int minDiz = 0;
    float timer = 0;
    public Text time;
    void Awake()
    {
        _instance = this;
        time.text = hour + "H" + minDiz + minUni;
    }
    void Update()
    {
        panikCountDown += Time.deltaTime;
        if (panikCountDown > fear && panik > 0)
        {
            panik -= 1;
            //Debug.Log("jauge de panique = " + panik + "%");
            panikCountDown = 0;
        }
        timer += Time.deltaTime;
        if(timer > 1 && hour != 0)
        {
            if (minUni != 9)
            {
                minUni += 1;
            }
            else if(minDiz != 5)
            {
                minUni = 0;
                minDiz += 1;
            }
            else if(hour != 23)
            {
                minUni = 0;
                minDiz = 0;
                hour += 1;
            }
            else
            {
                minUni = 0;
                minDiz = 0;
                hour = 0;
            }
            time.text = hour + "H" + minDiz + minUni;
            timer = 0;
        }
    }
}
