using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : Item
{
    private bool move;
    private bool placed;
    public Rigidbody2D rb2d;

    void Update()
    {
        if (move == false)
        {
            Mouse(0,0);
        }

        if (Input.GetMouseButton(0) && placed == false)
        {
            move = true;
            UIManager.Instance.cake.SetActive(false);
            UIManager.Instance.ChangeItem(Inventory.None);
            placed = true;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnMouseDown()
    {
        if (placed == true && Input.GetMouseButton(0) && UIManager.Item == Inventory.None)
        {
            UIManager.Instance.cake.SetActive(true);
            Destroy(gameObject);
        }
    }
}
