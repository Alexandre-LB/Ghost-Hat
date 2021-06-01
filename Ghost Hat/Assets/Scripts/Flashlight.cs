using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Item
{
    public GameObject lightAura;

    private void Update()
    {
        Mouse(0, 0);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            transform.Rotate(Vector3.forward * 6);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            transform.Rotate(Vector3.back * 6);
        }
        if (Input.GetMouseButton(1))
        {
            Destroy();
        }

        if (GameManager.Instance.room.lumiere)
        {
            lightAura.SetActive(false);
        }
        else
        {
            lightAura.SetActive(true);
        }
    }
}
