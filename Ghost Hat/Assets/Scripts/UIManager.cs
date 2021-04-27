using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Inventory
{
    None,
    Spiritbox,
    Camera,
    Cake,
    Torchlight,
    Radar,
    CameraVision
}
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static Inventory _item;
    public static Inventory Item
    {
        get
        {
            return _item;
        }
    }
    int panik = 100;
    float panikCountDown = 0;
    public float fear;

    float timer = 0;
    int hour = 19;
    int minUni = 0;
    int minDiz = 0;

    public Text time;
    public Image pointeur;
    public GameObject itemSlot;
    public Button spiritbox;
    public Button cameraSlot;
    public Button cake;
    public Button torchlight;
    public Button radar;
    public Button cameraVision;
    void Awake()
    {
        _instance = this;
        _item = Inventory.None;
        time.text = hour + "H" + minDiz + minUni;
    }
    void Update()
    {
        Panik();
        TimeCount();     
    }
    void Panik()
    {
        panikCountDown += Time.deltaTime;
        if (panikCountDown > fear && panik > 0)
        {
            panik -= 1;
            pointeur.transform.position = new Vector2(pointeur.transform.position.x - 5, pointeur.transform.position.y);
            panikCountDown = 0;
        }
    }
    void TimeCount()
    {
        timer += Time.deltaTime;
        if (timer > 1 && hour != 0)
        {
            if (minUni != 9)
            {
                minUni += 1;
            }
            else if (minDiz != 5)
            {
                minUni = 0;
                minDiz += 1;
            }
            else if (hour != 23)
            {
                minUni = 0;
                minDiz = 0;
                hour += 1;
            }
            else
            {
                minUni = 0;
                minDiz = 0;
                hour = 0;
            }
            time.text = hour + "H" + minDiz + minUni;
            timer = 0;
        }
    }
    public void SpiritBox()
    {
        if(_item == Inventory.Spiritbox)
        {
            ChangeItem(Inventory.None);
        }
        else
        {
            ChangeItem(Inventory.Spiritbox);
        }
    }
    public void Camera()
    {
        if (_item == Inventory.Camera)
        {
            ChangeItem(Inventory.None);
        }
        else
        {
            ChangeItem(Inventory.Camera);
        }
    }
    public void Torch()
    {
        if (_item == Inventory.Torchlight)
        {
            ChangeItem(Inventory.None);
        }
        else
        {
            ChangeItem(Inventory.Torchlight);
        }
    }
    public void Radar()
    {
        if (_item == Inventory.Radar)
        {
            ChangeItem(Inventory.None);
        }
        else
        {
            ChangeItem(Inventory.Radar);
        }
    }
    public void Cake()
    {
        if (_item == Inventory.Cake)
        {
            ChangeItem(Inventory.None);
        }
        else
        {
            ChangeItem(Inventory.Cake);
        }
    }
    public void CameraVision()
    {
        if (_item == Inventory.CameraVision)
        {
            ChangeItem(Inventory.None);
        }
        else
        {
            ChangeItem(Inventory.CameraVision);
        }
    }
    void ChangeItem(Inventory item)
    {
        _item = item;
        switch (_item)
        {
            case Inventory.None:
                itemSlot.SetActive(true);
                break;
            case Inventory.Spiritbox:
                itemSlot.SetActive(true);
                break;
            case Inventory.Camera:
                itemSlot.SetActive(true);
                break;
            case Inventory.Torchlight:
                itemSlot.SetActive(true);
                break;
            case Inventory.Radar:
                itemSlot.SetActive(true);
                break;
            case Inventory.Cake:
                itemSlot.SetActive(true);
                break;
            case Inventory.CameraVision:
                itemSlot.SetActive(false);
                break;
        }
        Debug.Log(_item);
    }
}
