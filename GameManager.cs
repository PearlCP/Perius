using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CoverImage1;
    public GameObject CoverImage2;
    GameObject ChangeScene;
    GameObject SetEndlessVariable;
    public bool Endless_Unlock = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.ChangeScene = GameObject.Find("Change_Scene");
        SetEndlessVariable = GameObject.Find("SetEndlessVariable");
        Endless_Unlock = SetEndlessVariable.GetComponent<GameClear_Script>().Endless_Unlock;

    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void OnClickStartButton()
    {
        CoverImage1.SetActive(false);
        CoverImage2.SetActive(false);
        SceneManager.LoadScene("Ingame");
    }
    public void OnClickEndlessButton()
    {
        if (Endless_Unlock)
        {
            CoverImage1.SetActive(false);
            CoverImage2.SetActive(false);
            SceneManager.LoadScene("Endless");
            Debug.Log("Endless_Unlock is True");
        }
        else
        {
            Debug.Log("Endless_Unlock is false");
        }
    }
}
