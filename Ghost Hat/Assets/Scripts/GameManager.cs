using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    MainMenu,
    Game,
    Pause
}
public class GameManager : MonoBehaviour
{
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
    private void Awake()
    {
        _instance = this;
        _state = 0;
    }
}
