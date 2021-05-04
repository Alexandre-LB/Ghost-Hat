using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum Inventory
{
    None,
    Spiritbox,
    Camera,
    Cake,
    Flashlight,
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
    public GameObject gameScreen;
    public GameObject levelScreen;
    public GameObject titleSceen;
    public GameObject creditScreen;
    public GameObject deathScreen;
    public GameObject victoryScreen;
    public GameObject star2;
    public GameObject star3;

    int panik;
    float panikCountDown;
    public float fear;

    float timer;
    int hour;
    int minUni;
    int minDiz;

    public Text time;
    public Image pointeur;
    [SerializeField]
    GameObject itemSlot;
    public GameObject cake;
    public GameObject polaroid;
    public GameObject pauseScreen;
    void Awake()
    {
        _instance = this;
        _item = Inventory.None;
        panik = 100;
        panikCountDown = 0;
        timer = 0;
        hour = 19;
        minUni = 0;
        minDiz = 0;
        pointeur.transform.position = new Vector2(1210, 960);
        time.text = hour + "H" + minDiz + minUni;
    }
    void Update()
    {
        if(GameManager.State == GameState.Game)
        {
            TimeCount();
            Panik();
        }
        if (Input.GetKeyDown("p"))
        {
            GameManager.Instance.ChangeState(GameState.Pause);
        }
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
    public void Flash()
    {
        if (_item == Inventory.Flashlight)
        {
            ChangeItem(Inventory.None);
        }
        else
        {
            ChangeItem(Inventory.Flashlight);
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
            itemSlot.SetActive(true);
        }
        else
        {
            ChangeItem(Inventory.CameraVision);
            itemSlot.SetActive(false);
        }
    }
    void ChangeItem(Inventory item)
    {
        _item = item;
        switch (_item)
        {
            case Inventory.None:
                break;
            case Inventory.Spiritbox:
                break;
            case Inventory.Camera:
                break;
            case Inventory.Flashlight:
                break;
            case Inventory.Radar:
                break;
            case Inventory.Cake:
                break;
            case Inventory.CameraVision:
                break;
        }
    }
    public void ToMainMenu()
    {
        pauseScreen.SetActive(false);
        creditScreen.SetActive(false);
        levelScreen.SetActive(false);
        gameScreen.SetActive(false);
        titleSceen.SetActive(true);
        GameManager.Instance.ChangeState(GameState.MainMenu);
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void ToLevelMap()
    {
        titleSceen.SetActive(false);
        gameScreen.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        levelScreen.SetActive(true);
        GameManager.Instance.ChangeState(GameState.MainMenu);
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void ChargeLevel(int niveau)
    {
        titleSceen.SetActive(false);
        levelScreen.SetActive(false);
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        GameManager.Instance.ChangeState(GameState.Game);
        SceneManager.LoadScene(niveau + 2);
        Awake();
    }
    public void ToCredit()
    {
        titleSceen.SetActive(false);
        creditScreen.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        GameManager.Instance.ChangeState(GameState.Game);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Awake();
        Resume();
    }
}
