using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear_Script : MonoBehaviour
{
    public bool Endless_Unlock;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        Endless_Unlock = true;
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
