using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItem : Item
{
    private bool move;
    private bool placed;
    public GameObject objectCamera;
    public Transform mainCam;
    private float mainCamPosX;
    private float mainCamPosY;
    public bool cameraButton;
    public Rigidbody2D rb2d;

    private void Awake()
    {
        this.objectCamera = GameObject.FindGameObjectWithTag("Cam");
    }

    void FixedUpdate()
    {
        this.mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        if (move == false)
        {
            Mouse(0, 0);
            if (Input.GetMouseButton(1))
            {
                Destroy();
            }
        }
        if (Input.GetMouseButton(0) && placed == false)
        {
            move = true;
            UIManager.Instance.placed = true;
            UIManager.Instance.ChangeItem(Inventory.None);
            UIManager.Instance.polaroid.SetActive(false);
            GameManager.Instance.CameraScreen();
            cameraButton = true;
            mainCamPosX = mainCam.position.x;
            mainCamPosY = mainCam.position.y;
            placed = true;
            GameManager.Instance.room.cameraStand = true;
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }

        if (UIManager.Item == Inventory.CameraVision)
        {
            objectCamera.transform.position = new Vector3(mainCamPosX, mainCamPosY, transform.position.z);
        }

        if (GameManager.Instance.moving == true && placed == false)
        {
            UIManager.Instance.ChangeItem(Inventory.None);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (placed == true && Input.GetMouseButton(0) && UIManager.Item == Inventory.None)
        {
            UIManager.Instance.placed = false;
            UIManager.Instance.polaroid.SetActive(true);
            Destroy(gameObject);
            GameManager.Instance.room.cameraStand = false;
        }
    }
}
