using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minagi_Script : MonoBehaviour
{
    public GameObject bullet;
    GameObject status;
    GameObject BossManagement;
    protected Animator animator;

    public AudioClip SE;
    public AudioClip DamagedSE;
    public GameObject effect;
    new AudioSource audio;

    public int HP;

    float delay;
    bool attackable = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        this.audio = GetComponent<AudioSource>();
        this.status = GameObject.Find("StatusBar");
        this.BossManagement = GameObject.Find("BossSpawn");
    }
    // Update is called once per frame
    void Update()
    {
        if (attackable)
            delay += Time.deltaTime;

        if (delay > 10.5f && attackable)
        {
            attackable = false;
            animator.SetBool("Battack", true);
            StartCoroutine(Attack1(4));
            delay = 0;
        }

        if (HP <= 0)
        {
            Instantiate(effect);
            Destroy(gameObject);
            BossManagement.GetComponent<Boss_Spawn>().spawn_boss = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            this.audio.PlayOneShot(this.DamagedSE);
            HP -= (int)status.GetComponent<Status_Script>().statusArray[3]; //1 for bullets, 2 for laser
        }
    }

    IEnumerator Attack1(int size)
    {
        this.audio.PlayOneShot(this.SE);
        for (int i = 0; i < size; i++)
        {
            Instantiate(bullet);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Battack", false);
        attackable = true;
    }
}
