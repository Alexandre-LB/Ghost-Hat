using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        UIManager.Instance.ToMainMenu();
    }
}
