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
    public bool cameraButton;

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
        
        if (Input.GetMouseButton(0) && placed == false)
        {
            move = true;
            UIManager.Instance.polaroid.SetActive(false);
            GameManager.Instance.CameraScreen();
            cameraButton = true;
            mainCamPosX = mainCam.position.x;
            mainCamPosY = mainCam.position.x;
            StartCoroutine(ItemActivate());
        }

        if (UIManager.Item == Inventory.CameraVision)
        {
            objectCamera.transform.position = new Vector3(mainCamPosX, mainCamPosY, -1);
        }
    }

    IEnumerator ItemActivate()
    {
        yield return new WaitForSeconds(1);
        placed = true;
    }

    private void OnMouseDown()
    {
        if (placed == true && Input.GetMouseButton(0))
        {
            UIManager.Instance.polaroid.SetActive(true);
            Destroy(gameObject);
        }
    }
}
