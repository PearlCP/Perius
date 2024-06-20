using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EMP_Script : MonoBehaviour
{
    GameObject player;
    new Renderer renderer;
    public GameObject target;

    public AudioClip EMPse;

    float playerPos;

    new AudioSource audio;
    void Start()
    {
        renderer = target.GetComponent<Renderer>();
        this.player = GameObject.Find("Player");
        this.audio = GetComponent<AudioSource>();
        this.audio.PlayOneShot(this.EMPse);
        transform.localScale = new Vector3(13, 13, 1);
    }

    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = playerPos;
        StartCoroutine(FadeOut());
        StartCoroutine(disable());
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    IEnumerator FadeOut()
    {
        int i = 20;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            UnityEngine.Color c = renderer.material.color;
            c.a = f;
            renderer.material.color = c;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
