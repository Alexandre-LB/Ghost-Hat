using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItem : Item
{
    private bool move;
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
            mainCamPosX = mainCam.position.x;
            mainCamPosY = mainCam.position.x;
        }

        if (UIManager.Item == Inventory.CameraVision)
        {
            objectCamera.transform.position = new Vector3(mainCamPosX, mainCamPosY, -1);
        }
    }
}
