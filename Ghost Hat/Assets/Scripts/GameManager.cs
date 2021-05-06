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
    public Camera cam;
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
    private void Awake()
    {
        this.mainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
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

    public void CameraScreen()
    {
        cam.transform.position = mainCam.position;
    }
}
