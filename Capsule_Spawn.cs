using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_Spawn : MonoBehaviour
{
    public GameObject Capsule;

    float Spawn_Delay = 0;

    float spawner_y;
    int spawn_max;

    public float Spawn_Delay_Min;
    public float Spawn_Delay_Max;

    // Update is called once per frame
    void Update()
    {
        Spawn_Capsule();
    }

    //spawn Capsule
    void Spawn_Capsule()
    {
        Spawn_Delay += Time.deltaTime;
        if (Spawn_Delay > Random.Range(Spawn_Delay_Min, Spawn_Delay_Max))
        {
            spawner_y = Random.Range(-5.0f, 5.0f);
            transform.position = new Vector3(11, spawner_y, this.transform.position.z);
            Instantiate(Capsule);
            Spawn_Delay = 0;
        }
    }
}
