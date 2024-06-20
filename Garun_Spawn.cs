using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Garun_Spawn : MonoBehaviour
{
    public GameObject Garun;

    float Spawn_Delay = 0;

    float spawner_x;
    float spawner_y;
    int spawn_max;

    public float Spawn_Delay_Min;
    public float Spawn_Delay_Max;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Spawn_Garun();
    }


    //spawn Garun(Enemy Spawn)
    void Spawn_Garun()
    {
        Spawn_Delay += Time.deltaTime;
        if (Spawn_Delay > Random.Range(Spawn_Delay_Min, Spawn_Delay_Max))
        {
            spawn_max = Random.Range(5, 8);
            StartCoroutine(SpawnLoopGarun((int)spawn_max));
            Spawn_Delay = 0;
        }
    }

    IEnumerator SpawnLoopGarun(int size)
    {
        for (int i = 0; i < size; i++)
        {
            spawner_x = Random.Range(3.0f, 21.0f);
            spawner_y = Random.Range(9.0f, 13.0f);
            transform.position = new Vector3(spawner_x, spawner_y, this.transform.position.z);
            Instantiate(Garun);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
