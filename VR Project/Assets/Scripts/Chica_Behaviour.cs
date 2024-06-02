using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using static Unity.VisualScripting.Member;

public class Chica_Behaviour : MonoBehaviour
{
    public SixAM isHour;

    [SerializeField] bool angry;
    float time;

    public float timeForClipChange;
    public float timeForKill;
    public VideoPlayer tv;

    public GameObject chica_Jumpscare;

    Animator animator;
    public VideoClip[] videoClipList;
    public VideoClip[] AddsClipList;
    public AudioSource Growl;
    public AudioSource chicaScreamer;

    public Light eye_R;
    public Light eye_L;

    public float minWaitTimeForAdd = 20f;
    public float maxWaitTimeForAdd = 80f;
    public float timeToNextAd = 0f;

    bool dead = false;
    float passScene = 0f;

    // Tutorial
    public bool isTutorial = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        angry = false;
        time = 0.0f;
        timeToNextAd = Random.Range(minWaitTimeForAdd, maxWaitTimeForAdd);

        animator = GetComponent<Animator>();

        tv.clip = videoClipList[Random.Range(0, videoClipList.Length)];
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

                if (isHour.currentHour == SixAM.Hour.ZERO_AM)
                {
                    minWaitTimeForAdd = 20f;
                    maxWaitTimeForAdd = 40f;
                }

                if (isHour.currentHour == SixAM.Hour.ONE_AM)
                {
                    minWaitTimeForAdd = 15f;
                    maxWaitTimeForAdd = 40f;
                }

                if (isHour.currentHour == SixAM.Hour.TWO_AM)
                {
                    minWaitTimeForAdd = 15f;
                    maxWaitTimeForAdd = 30f;
                }

                if (isHour.currentHour == SixAM.Hour.THREE_AM)
                {
                    minWaitTimeForAdd = 10f;
                    maxWaitTimeForAdd = 30f;
                }

                if (isHour.currentHour == SixAM.Hour.FOUR_AM)
                {
                    minWaitTimeForAdd = 10f;
                    maxWaitTimeForAdd = 20f;
                }

                if (isHour.currentHour == SixAM.Hour.FIVE_AM)
                {
                    minWaitTimeForAdd = 8f;
                    maxWaitTimeForAdd = 25f;
                }

                if (Input.GetKeyDown(KeyCode.V))
                {
                    angry = !angry;
                    time = 0;
                    timeToNextAd = Random.Range(minWaitTimeForAdd, maxWaitTimeForAdd);

                    if (!angry)
                    {
                        tv.clip = videoClipList[Random.Range(0, videoClipList.Length)];
                        animator.SetBool("isAngry", false);
                    }
                    else
                    {
                        tv.clip = AddsClipList[Random.Range(0, AddsClipList.Length)];
                        animator.SetBool("isAngry", true);
                    }
                }

                time += Time.deltaTime;

                if (time >= timeToNextAd && !angry)
                {
                    tv.clip = AddsClipList[Random.Range(0, AddsClipList.Length)];
                    Growl.Play();
                    animator.SetBool("isAngry", true);

                    time = 0;
                    angry = true;
                }

                //if(tv.clip == videoClipList[videoClipList.Count-1]) //Last clip will be allways the one that kills the player
                //{
                //    angry = true;
                //}
                //else 
                //{
                //    angry = false;
                //    time += Time.deltaTime;
                //    if (timeForClipChange < time) 
                //    {
                //        tv.clip = videoClipList[videoClipList.Count-1];
                //        time = 0.0f;
                //    }
                //}

                if (angry)
                {
                    eye_R.color = Color.red;
                    eye_L.color = Color.red;

                    if (time > timeForKill)
                    {
                        Kill();
                        time = 0;
                        angry = false;
                    }
                }
                else
                {
                    eye_R.color = Color.white;
                    eye_L.color = Color.white;
                    animator.SetBool("isAngry", false);
                }
            }
        }

        else
        {
            minWaitTimeForAdd = 8f;
            maxWaitTimeForAdd = 25f;
            
            if (Input.GetKeyDown(KeyCode.V))
            {
                angry = !angry;
                time = 0;
                timeToNextAd = Random.Range(minWaitTimeForAdd, maxWaitTimeForAdd);

                if (!angry)
                {
                    tv.clip = videoClipList[Random.Range(0, videoClipList.Length)];
                    animator.SetBool("isAngry", false);
                }
                else
                {
                    tv.clip = AddsClipList[Random.Range(0, AddsClipList.Length)];
                    animator.SetBool("isAngry", true);
                }
            }

            time += Time.deltaTime;

            if (time >= timeToNextAd && !angry)
            {
                tv.clip = AddsClipList[Random.Range(0, AddsClipList.Length)];
                Growl.Play();
                animator.SetBool("isAngry", true);

                time = 0;
                angry = true;
            }

            //if(tv.clip == videoClipList[videoClipList.Count-1]) //Last clip will be allways the one that kills the player
            //{
            //    angry = true;
            //}
            //else 
            //{
            //    angry = false;
            //    time += Time.deltaTime;
            //    if (timeForClipChange < time) 
            //    {
            //        tv.clip = videoClipList[videoClipList.Count-1];
            //        time = 0.0f;
            //    }
            //}

            if (angry)
            {
                eye_R.color = Color.red;
                eye_L.color = Color.red;
            }

            else
            {
                eye_R.color = Color.white;
                eye_L.color = Color.white;
                animator.SetBool("isAngry", false);
            }
        }
    }

    public void ChangeChannel()
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            if (angry)
            {
                tv.clip = videoClipList[Random.Range(0, videoClipList.Length)];
                timeToNextAd = Random.Range(minWaitTimeForAdd, maxWaitTimeForAdd);
                time = 0;
                angry = false; 
                
                if (isTutorial)
                {
                    GameObject welldone = GameObject.Find("CongratsSoundEffect");
                    AudioSource congrats = welldone.GetComponent<AudioSource>();
                    congrats.Play();

                    player.GetComponent<TrackTutorials>().UpdateTutorials(); // DONDE NO ANGRY
                    this.enabled = false;
                    this.gameObject.SetActive(false);
                    tv.enabled = false;
                }
            }
            else
            {
                Kill(); //If you change Chica the TV while she is enjoying she kills you to
            }
        }
    }

    public void Kill() 
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            //Chica screamer
            chica_Jumpscare.SetActive(true);
            chicaScreamer.Play();
            Debug.Log("Chica killed You");

            //Kill player
            dead = true;
        }
    }
}
