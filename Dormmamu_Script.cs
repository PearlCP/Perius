using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormmamu_Script : MonoBehaviour
{
    public GameObject bullet;
    public GameObject fakeSlash;
    public GameObject Slash;
    GameObject status;
    GameObject BossManagement;
    protected Animator animator;

    public AudioClip SE1;
    public AudioClip SE2;
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

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (attackable)
            delay += Time.deltaTime;

        if (delay > 9.0f && attackable)
        {
            attackable = false;
            if (Random.Range(0, 2) == 0)
            {
                attackable = false;
                animator.SetBool("Battack", true);
                StartCoroutine(Attack1(4));
                delay = 0;
            }
            else
            {
                attackable = false;
                animator.SetBool("Battack", true);
                StartCoroutine(Attack2(Random.Range(2, 5)));
                delay = 0;
            }
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
        for (int i = 0; i < size; i++)
        {
            Instantiate(bullet);
            this.audio.PlayOneShot(this.SE1);
            yield return new WaitForSeconds(0.4f);
        }
        animator.SetBool("Battack", false);
        attackable = true;
    }
    IEnumerator Attack2(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Instantiate(fakeSlash);
            this.audio.PlayOneShot(this.SE2);
            yield return new WaitForSeconds(0.5f);

            Instantiate(Slash);
            this.audio.PlayOneShot(this.SE1);
            this.audio.PlayOneShot(this.SE2);
            yield return new WaitForSeconds(0.5f);
        }
        animator.SetBool("Battack", false);
        attackable = true;
    }
}
