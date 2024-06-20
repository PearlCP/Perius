using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessButton : MonoBehaviour
{
    Image before_img;
    public Sprite after_img;
    GameObject SetEndlessVariable;
    bool Endless_Unlock;

    void Start()
    {
        before_img = GetComponent<Image>();
        SetEndlessVariable = GameObject.Find("SetEndlessVariable");
        Endless_Unlock = SetEndlessVariable.GetComponent<GameClear_Script>().Endless_Unlock;
    }
    // Update is called once per frame
    void Update()
    {
        if (Endless_Unlock)
        {
            transform.localScale = new Vector3(3, 2.8f, 1);
            before_img.sprite = after_img;
        }
    }
}
