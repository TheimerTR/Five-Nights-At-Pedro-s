using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static Unity.VisualScripting.Member;

public class Chica_Behaviour : MonoBehaviour
{
    [SerializeField] bool angry;
    float time;
    public float timeForClipChange;
    public float timeForKill;
    public VideoPlayer tv;

    Animator animator; 
    public VideoClip[] videoClipList;
    public VideoClip[] AddsClipList;
    public AudioSource Growl;
    public AudioSource chicaScreamer;

    public Light eye_R;
    public Light eye_L;

    public float minWaitTimeForAdd = 0f;
    public float maxWaitTimeForAdd = 80f;
    public float timeToNextAd = 0f;

    // Start is called before the first frame update
    void Start()
    {
        angry = false;
        time = 0.0f;
        timeToNextAd = Random.Range(minWaitTimeForAdd, maxWaitTimeForAdd);

        tv.clip = videoClipList[Random.Range(0, videoClipList.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            angry = !angry;
            time = 0;
            timeToNextAd = Random.Range(minWaitTimeForAdd, maxWaitTimeForAdd);

            if (!angry)
            {
                tv.clip = videoClipList[Random.Range(0, videoClipList.Length)];
            }
            else
            {
                tv.clip = AddsClipList[Random.Range(0, AddsClipList.Length)];
            }
        }

        time += Time.deltaTime;

        if(time >= timeToNextAd && !angry)
        {
            tv.clip = AddsClipList[Random.Range(0, AddsClipList.Length)];
            Growl.Play();

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
            }
        }
        else
        {
            eye_R.color = Color.white;
            eye_L.color = Color.white;
        }
    }

    public void ChangeChannel()
    {
        if (angry) 
        {
            tv.clip = videoClipList[Random.Range(0, videoClipList.Length)];
            timeToNextAd = Random.Range(minWaitTimeForAdd, maxWaitTimeForAdd);
            time = 0;
        }
        else 
        {
            Kill(); //If you change Chica the TV while she is enjoying she kills you to
        }
    }

    public void Kill() 
    {
        //Chica screamer
        chicaScreamer.Play();
        Debug.Log("Chica killed You");

        //Kill player
    }
}
