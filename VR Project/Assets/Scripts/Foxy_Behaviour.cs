using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foxy_Behaviour : MonoBehaviour
{
    public GameObject Foxy;
    public Transform[] SpawnPoint;

    public float TimeToAppear;
    public float WaitTime;
    public float TimeToKill;
    public float Timer = 0;

    public int Flashed;

    bool HasApperared;

    public SixAM isHour;

    public AudioSource Jumpscare;
    public AudioSource Scratch;

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

        switch (isHour.currentHour)
        {
            case SixAM.Hour.ZERO_AM:
                TimeToAppear = 30f;
                break;
            case SixAM.Hour.ONE_AM:
                TimeToAppear = 26f;
                break;
            case SixAM.Hour.TWO_AM:
                TimeToAppear = 24f;
                break;
            case SixAM.Hour.THREE_AM:
                TimeToAppear = 20f;
                break;
            case SixAM.Hour.FOUR_AM:
                TimeToAppear = 19f;
                break;
            case SixAM.Hour.FIVE_AM:
                TimeToAppear = 18f;
                break;
            default:
                break;
        }

        if (Timer > TimeToAppear && !HasApperared)
        {
            HasApperared = true;
            Flashed = 0;
            Scratch.Play();

            Foxy.SetActive(true);
            transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].position;
            transform.rotation = SpawnPoint[Random.Range(0, SpawnPoint.Length)].rotation;
            
            WaitTime = Timer + TimeToKill;
        }

        if(Flashed >= 5 && HasApperared)
        {
            HasApperared = false;
            Timer = 0;
            Flashed = 0;
            Foxy.SetActive(false);
        }

        if(Timer > WaitTime && HasApperared)
        {
            Jumpscare.Play();
            Debug.Log("FoxyKill!");
            Timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Foxy_FlashLight")
        {
            Flashed++;
        }
    }
}
