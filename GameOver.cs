using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (transform.position.y < 11.0f)
        {
            transform.Translate(0, 0.1f, 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.Z))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
