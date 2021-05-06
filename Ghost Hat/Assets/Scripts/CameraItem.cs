using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItem : Item
{
    private bool move;
    private bool placed;
    public Camera objectCamera;
    private Transform mainCam;
    private float mainCamPosX;
    private float mainCamPosY;

    private void Awake()
    {
        this.mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        if (move == false)
        {
            Mouse();
        }
        
        if (Input.GetMouseButton(0))
        {
            move = true;
            UIManager.Instance.polaroid.SetActive(false);
            mainCamPosX = mainCam.position.x;
            mainCamPosY = mainCam.position.x;
            StartCoroutine(ItemActivate());
        }

        if (placed == true && Input.GetMouseButton(0))
        {
            UIManager.Instance.polaroid.SetActive(true);
            Destroy(gameObject);
        }

        if (UIManager.Item == Inventory.CameraVision)
        {
            objectCamera.transform.position = new Vector3(mainCamPosX, mainCamPosY, -1);
        }
    }

    IEnumerator ItemActivate()
    {
        yield return new WaitForSeconds(2);
        placed = true;
    }

    private void OnMouseOver()
    {
        if (placed == true && Input.GetMouseButton(0))
        {
            UIManager.Instance.polaroid.SetActive(true);
            Destroy(gameObject);
        }
    }
}
