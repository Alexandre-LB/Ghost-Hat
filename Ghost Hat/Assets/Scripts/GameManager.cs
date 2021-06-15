using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Quentin et Alexandre
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
    public AudioClip sonsAmbiance;

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
    public bool moving;

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
                SoundManager.Instance.StopAllSounds();
                SoundManager.Instance.Playsound(sonsAmbiance, 0.1f);
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
