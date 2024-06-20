using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Spawn : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetFrame", 2);
        Spawn_Star();
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    public void Spawn_Star()
    { 
        //star 프리팹 70개 생성
        for (int i = 0; i < 70; i++)
        {
            GameObject instance = Instantiate(prefab);
        }
    }

    void SetFrame()
    {
        Application.targetFrameRate = 60;
    }
}
