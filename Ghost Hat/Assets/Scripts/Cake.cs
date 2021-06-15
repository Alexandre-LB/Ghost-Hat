using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Alexandre
public class Cake : Item
{
    [SerializeField]
    private bool move;
    [SerializeField]
    private bool placed;
    public Rigidbody2D rb2d;

    void Update()
    {
        if (move == false)
        {
            Mouse(0,0);
            if (Input.GetMouseButton(1) && !UIManager.Instance.cake.activeSelf)
            {
                Destroy();
            }
        }

        if (Input.GetMouseButton(0) && placed == false)
        {
            move = true;
            UIManager.Instance.cake.SetActive(false);
            UIManager.Instance.ChangeItem(Inventory.None);
            placed = true;
            GameManager.Instance.room.gateau = this;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }

        if (GameManager.Instance.moving == true && placed == false)
        {
            UIManager.Instance.ChangeItem(Inventory.None);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (placed == true && Input.GetMouseButton(0) && UIManager.Item == Inventory.None && !UIManager.Instance.cake.activeSelf)
        {
            UIManager.Instance.cake.SetActive(true);
            Destroy(gameObject);
            GameManager.Instance.room.gateau = null;
        }
    }
}
