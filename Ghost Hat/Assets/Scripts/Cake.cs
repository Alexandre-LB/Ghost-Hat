using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : Item
{
    private bool move;
    private bool placed;
    public Rigidbody2D rb2d;

    void Start()
    {
        
    }

    void Update()
    {
        if (move == false)
        {
            Mouse();
        }

        if (Input.GetMouseButton(0) && placed == false)
        {
            move = true;
            UIManager.Instance.ChangeItem(Inventory.None);
            StartCoroutine(ItemActivate());
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    IEnumerator ItemActivate()
    {
        yield return new WaitForSeconds(1);
        placed = true;
    }

    private void OnMouseDown()
    {
        if (placed == true && Input.GetMouseButton(0) && UIManager.Item == Inventory.None)
        {
            UIManager.Instance.polaroid.SetActive(true);
            Destroy(gameObject);
        }
    }
}
