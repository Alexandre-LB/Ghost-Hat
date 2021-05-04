using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            UIManager.Instance.ToMainMenu();
        }
    }
}
