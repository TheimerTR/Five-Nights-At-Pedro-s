using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.XR.OpenXR.Features.Interactions.DPadInteraction;
using UnityEngine.SceneManagement;

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
    public AudioSource Growl;

    public Animator animator;

    bool dead = false;
    float passScene = 0f;
    public GameObject chica_Jumpscare;

    // Tutorial
    public bool isTutorial = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Foxy.SetActive(false);
        HasApperared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTutorial)
        {
            if (isHour.currentHour != SixAM.Hour.SIX_AM)
            {
                if (dead)
                {
                    passScene += Time.deltaTime;

                    if (passScene > 1.5f)
                    {
                        SceneManager.LoadScene("Dead");
                    }
                }

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

                if (Flashed >= 5 && HasApperared)
                {
                    HasApperared = false;
                    Timer = 0;
                    Flashed = 0;
                    Foxy.SetActive(false);
                    Growl.Play();
                }

                if (Timer > WaitTime && HasApperared)
                {
                    dead = true;
                    chica_Jumpscare.SetActive(true);
                    Jumpscare.Play();
                    Debug.Log("FoxyKill!");
                    Timer = 0;
                }
            }
        }

        else
        {
            Timer += Time.deltaTime;
            TimeToAppear = 5f;

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

            if (Flashed >= 5 && HasApperared)
            {
                HasApperared = false;
                //Timer = 0;
                Flashed = 0;
                Growl.Play();
                gameObject.SetActive(false);
                player.GetComponent<TrackTutorials>().UpdateTutorials();
            }

            if (Timer > WaitTime && HasApperared)
            {
                // Don't kill, but jumpscare to learn
                //dead = true;
                chica_Jumpscare.SetActive(true);
                Jumpscare.Play();
                //Debug.Log("FoxyKill!");
                //Timer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Foxy_FlashLight")
        {
            animator.SetTrigger("IsFlashed");
            Flashed++;
        }
    }
}
