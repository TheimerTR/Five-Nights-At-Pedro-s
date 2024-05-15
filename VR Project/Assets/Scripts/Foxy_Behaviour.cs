using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foxy_Behaviour : MonoBehaviour
{
    public GameObject Foxy;
    public Transform[] SpawnPoint;

    public float TimeToAppear;
    public float TimeToKill;
    public float Timer = 0;

    bool HasApperared;

    // Start is called before the first frame update
    void Start()
    {
        Foxy.SetActive(false);
        HasApperared = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > TimeToAppear && !HasApperared)
        {
            HasApperared = true;

            Foxy.SetActive(true);
            Foxy.transform.position = SpawnPoint[Random.RandomRange(0, SpawnPoint.Length)].position;
            Foxy.transform.rotation = SpawnPoint[Random.RandomRange(0, SpawnPoint.Length)].rotation;
        }
    }
}
