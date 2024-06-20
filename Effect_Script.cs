using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Script : MonoBehaviour
{
    GameObject Fans;
    float delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.Fans = GameObject.Find("Fans(Clone)");
        Vector3 spawnPos = this.Fans.transform.position;
        transform.position = spawnPos;
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (delay > 0.1f)
            Destroy(gameObject);
    }
}
