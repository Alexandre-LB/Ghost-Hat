using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    MainMenu,
    Game,
    Pause,
    End
}
public class GameManager : MonoBehaviour
{
    public GameObject cam;
    private Transform mainCam;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameState _state;
    public static GameState State
    {
        get
        {
            return _state;
        }
    }
    [HideInInspector]
    public bool[,] cameraRoom;
    [HideInInspector]
    public Salle room;
    private void Awake()
    {
        this.cam = GameObject.FindGameObjectWithTag("Cam");
        _instance = this;
        _state = 0;
    }
    public void ChangeState(GameState state)
    {
        _state = state;
        switch (_state)
        {
            case GameState.MainMenu:
                break;
            case GameState.Game:
                break;
            case GameState.Pause:
                UIManager.Instance.pauseScreen.SetActive(true);
                break;
        }
    }

    private void Update()
    {
        this.mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    public void CameraScreen()
    {
        cam.transform.position = new Vector3(mainCam.position.x, mainCam.position.y, -1);
    }
}
