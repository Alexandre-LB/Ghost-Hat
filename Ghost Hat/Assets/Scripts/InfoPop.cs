using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPop : MonoBehaviour
{
    public GameObject info;
    float time = 0;
    bool active = false;
    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;
            if (time >= 2)
            {
                info.SetActive(true);
            }
        }
    }
    public void ActiveInfo()
    {
        active = true;
    }
    public void DesactiveInfo()
    {
        active = false;
        info.SetActive(false);
        time = 0;
    }
}
