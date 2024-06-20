using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (transform.position.y < 11.0f)
        {
            transform.Translate(0, 0.2f, 0);
        }
        if (time >= 50)
            SceneManager.LoadScene("GameClear");
    }
}
