using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alexandre

public class Item : MonoBehaviour
{
    Vector3 mousePosition;

    public virtual void Mouse(float x, float y)
    {
        mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + y, transform.position.z);
        transform.position = mousePosition;
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
        UIManager.Instance.ChangeItem(Inventory.None);
    }
}
