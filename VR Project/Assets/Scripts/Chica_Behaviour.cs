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

    //public float timeForClipChange;
    public List<float> timeForKill;    
    public List<float> minWaitTimeForAdd;
    public List<float> maxWaitTimeForAdd;
    public float timeToNextAd = 0f;
    public VideoPlayer tv;

    public GameObject chica_Jumpscare;

    public Animator animator;
    public VideoClip[] videoClipList;
    public VideoClip[] AddsClipList;
    public AudioSource Growl;
    public AudioSource chicaScreamer;

    public Light eye_R;
    public Light eye_L;

    bool dead = false;
    float passScene = 0f;

    int CountToKillNotAdd = 0;

    // Tutorial
    public bool isTutorial = false;
    public GameObject player;
    public GameObject nextTutorial;

    // Start is called before the first frame update
    void Start()
    {
        angry = false;
        time = 0.0f;
        timeToNextAd = Random.Range(minWaitTimeForAdd[(int)isHour.currentHour], maxWaitTimeForAdd[(int)isHour.currentHour]);

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

                //Debugging
                if (Input.GetKeyDown(KeyCode.V))
                {
                    angry = !angry;
                    time = 0;
                    timeToNextAd = Random.Range(minWaitTimeForAdd[(int)isHour.currentHour], maxWaitTimeForAdd[(int)isHour.currentHour]);

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

                    if (time > timeForKill[(int)isHour.currentHour])
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
            time += Time.deltaTime;

            if (time >= 8 && !angry)
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
                timeToNextAd = Random.Range(minWaitTimeForAdd[(int)isHour.currentHour], maxWaitTimeForAdd[(int)isHour.currentHour]);
                time = 0;
                angry = false; 
                
                if (isTutorial)
                {
                    GameObject welldone = GameObject.Find("CongratsSoundEffect");
                    AudioSource congrats = welldone.GetComponent<AudioSource>();
                    congrats.Play();

                    player.GetComponent<TrackTutorials>().UpdateTutorials();
                    nextTutorial.SetActive(true);

                    this.enabled = false;
                    this.gameObject.SetActive(false);
                    tv.enabled = false;
                }
            }
            else
            {
                CountToKillNotAdd++;
                Growl.Play();

                if (CountToKillNotAdd >= 3 && !isTutorial)
                {
                    Kill();
                }

                //Kill(); //If you change Chica the TV while she is enjoying she kills you to
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
