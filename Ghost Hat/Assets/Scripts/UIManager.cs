using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
//Quentin
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
    public Text score;
    public GameObject cameraScreen;

    [HideInInspector]
    public int panik;
    float panikCountDown;
    public float fear;

    float timer;
    int hour;
    int minUni;
    int minDiz;
    [HideInInspector]
    public float tictac;

    public bool placed;
    public Text time;
    public Image pointeur;
    [SerializeField]
    GameObject itemSlot;
    [SerializeField]
    GameObject openButton;
    [SerializeField]
    GameObject closeButton;
    public GameObject cake;
    public GameObject polaroid;
    public CameraItem trepied;
    CameraItem actualCamera;
    public SpiritBox capteur;
    SpiritBox actualSpirit;
    public GameObject onde;
    GameObject actualRadar;
    public Flashlight lampe;
    Flashlight actualLight;
    public Cake gateau;
    Cake actualCake;
    public GameObject cameraVert;
    public GameObject pauseScreen;

    [HideInInspector]
    public int gluttonyCount;
    [HideInInspector]
    public int shyCount;
    [HideInInspector]
    public int invisibleCount;
    [HideInInspector]
    public int earCount;
    public Text gluttonyText;
    public Text shyText;
    public Text invisibleText;
    public Text earText;
    public EventSystem EventSystem;
    Vector2 slotPosition;
    Vector2 slotStart;
    Vector2 slotEnd;

    public GameObject Level1Star1;
    public GameObject Level1Star2;
    public GameObject Level1Star3;
    public GameObject Level2Star1;
    public GameObject Level2Star2;
    public GameObject Level2Star3;
    public GameObject Level3Star1;
    public GameObject Level3Star2;
    public GameObject Level3Star3;
    public GameObject Level4Star1;
    public GameObject Level4Star2;
    public GameObject Level4Star3;
    public GameObject Level5Star1;
    public GameObject Level5Star2;
    public GameObject Level5Star3;
    public GameObject Level6Star1;
    public GameObject Level6Star2;
    public GameObject Level6Star3;
    public GameObject Level7Star1;
    public GameObject Level7Star2;
    public GameObject Level7Star3;
    public GameObject Level8Star1;
    public GameObject Level8Star2;
    public GameObject Level8Star3;
    public GameObject Level9Star1;
    public GameObject Level9Star2;
    public GameObject Level9Star3;
    public GameObject Level10Star1;
    public GameObject Level10Star2;
    public GameObject Level10Star3;
    public Text score1Text;
    public Text score2Text;
    public Text score3Text;
    public Text score4Text;
    public Text score5Text;
    public Text score6Text;
    public Text score7Text;
    public Text score8Text;
    public Text score9Text;
    public Text score10Text;
    public int score1 = 0;
    public int score2 = 0;
    public int score3 = 0;
    public int score4 = 0;
    public int score5 = 0;
    public int score6 = 0;
    public int score7 = 0;
    public int score8 = 0;
    public int score9 = 0;
    public int score10 = 0;
    void Awake()
    {
        _instance = this;
        _item = Inventory.None;
        placed = false;
        panik = 100;
        tictac = 300;
        panikCountDown = 0;
        timer = 0;
        hour = 19;
        minUni = 0;
        minDiz = 0;
        pointeur.rectTransform.position = new Vector2(1510, 940);
        time.text = hour + " : " + minDiz + minUni;
        slotPosition = itemSlot.transform.position;
        slotStart = itemSlot.transform.position;
        slotEnd = new Vector2(itemSlot.transform.position.x, itemSlot.transform.position.y - 300);
    }
    void Update()
    {
        if(GameManager.State == GameState.Game)
        {
            TimeCount();
            if (GameManager.Instance.room != null && GameManager.Instance.room.lumiere == false)
            {
                Panik();
            }
            if (panik == 0 || hour == 0)
            {
                GameManager.Instance.ChangeState(GameState.MainMenu);
                deathScreen.SetActive(true);
            }
        }
        if (Input.GetKeyDown("p"))
        {
            GameManager.Instance.ChangeState(GameState.Pause);
        }
        earText.text = "= " + earCount;
        gluttonyText.text = "= " + gluttonyCount;
        invisibleText.text = "= " + invisibleCount;
        shyText.text = "= " + shyCount;
    }
    private void FixedUpdate()
    {
        itemSlot.transform.position = Vector2.Lerp(itemSlot.transform.position, slotPosition, Time.deltaTime * 2);
    }
    void Panik()
    {
        panikCountDown += Time.deltaTime;
        if (panikCountDown > fear && panik > 0)
        {
            panik -= 1;
            pointeur.rectTransform.position = new Vector2(pointeur.rectTransform.position.x - 10.8f, pointeur.rectTransform.position.y);
            panikCountDown = 0;
        }
    }
    void TimeCount()
    {
        tictac -= Time.deltaTime;
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
            time.text = hour + " : " + minDiz + minUni;
            timer = 0;
        }
    }
    public void SpiritBox()
    {
        if(_item == Inventory.Spiritbox)
        {
            ChangeItem(Inventory.None);
            Destroy(actualSpirit.gameObject);
        }
        else if(_item == Inventory.None)
        {
            ChangeItem(Inventory.Spiritbox);
            actualSpirit = Instantiate(capteur, new Vector2(0, 0), Quaternion.identity);
        }
    }
    public void Camera()
    {
        if (_item == Inventory.Camera)
        {
            ChangeItem(Inventory.None);
            Destroy(actualCamera.gameObject);
        }
        else if (_item == Inventory.None)
        {
            ChangeItem(Inventory.Camera);
            actualCamera = Instantiate(trepied, new Vector3(0, 0, -2), Quaternion.identity);
        }
    }
    public void Flash()
    {
        if (_item == Inventory.Flashlight)
        {
            ChangeItem(Inventory.None);
            Destroy(actualLight.gameObject);
        }
        else if (_item == Inventory.None)
        {
            ChangeItem(Inventory.Flashlight);
            actualLight = Instantiate(lampe, new Vector2(0, 0), Quaternion.identity);
        }
    }
    public void Radar()
    {
        if (_item == Inventory.Radar)
        {
            ChangeItem(Inventory.None);
            Destroy(actualRadar);
        }
        else if (_item == Inventory.None)
        {
            ChangeItem(Inventory.Radar);
            actualRadar = Instantiate(onde, new Vector2(0, 0), Quaternion.identity);
        }
    }
    public void Cake()
    {
        if (_item == Inventory.Cake)
        {
            ChangeItem(Inventory.None);
            Destroy(actualCake.gameObject);
        }
        else if (_item == Inventory.None)
        {
            ChangeItem(Inventory.Cake);
            actualCake = Instantiate(gateau, new Vector3(0, 0, -0.99f), Quaternion.identity);
        }
    }
    public void CameraVision()
    {
        if (_item == Inventory.CameraVision)
        {
            ChangeItem(Inventory.None);
            itemSlot.SetActive(true);
            cameraVert.SetActive(false);
        }
        else if (_item == Inventory.None && placed == true)
        {
            ChangeItem(Inventory.CameraVision);
            itemSlot.SetActive(false);
            cameraVert.SetActive(true);
        }
    }
    public void ChangeItem(Inventory item)
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
    public void Close()
    {
        slotPosition = slotEnd;
        openButton.SetActive(true);
        closeButton.SetActive(false);
    }
    public void Open()
    {
        slotPosition = slotStart;
        openButton.SetActive(false);
        closeButton.SetActive(true);
    }
    public void ToMainMenu()
    {
        titleSceen.SetActive(true);
        pauseScreen.SetActive(false);
        creditScreen.SetActive(false);
        levelScreen.SetActive(false);
        gameScreen.SetActive(false);
        deathScreen.SetActive(false);
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
        victoryScreen.SetActive(false);
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
        SceneManager.LoadScene(niveau + 1);
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
