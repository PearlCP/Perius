using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Script : MonoBehaviour
{
    public float speed = -0.12f;
    bool loop = false;

    // Update is called once per frame
    void Update()
    {
        float star_x;
        float star_y;
        transform.Translate(speed, 0, 0);
        if (!loop)
        {
            star_x = Random.Range(-12.0f, 12.0f);
            star_y = Random.Range(-5.0f, 5.0f);
            transform.position = new Vector2(star_x, star_y);
            loop = true;
        }
        if (transform.position.x <= -11.0f)
        {
            star_x = Random.Range(11.0f, 12.0f);
            star_y = Random.Range(-5.0f, 5.0f);
            transform.position = new Vector2(star_x, star_y);
        }    
    }
}
