using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Chica_Behaviour : MonoBehaviour
{
    [SerializeField] bool angry;
    float time;
    public float timeForClipChange;
    public float timeForKill;
    public VideoPlayer tv;
    Animator animator; 
    public List<VideoClip> videoClipList;
    public AudioSource chicaScreamer;
    // Start is called before the first frame update
    void Start()
    {
        angry = false;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(tv.clip == videoClipList[videoClipList.Count-1]) //Last clip will be allways the one that kills the player
        {
            angry = true;
        }
        else 
        {
            angry = false;
            time += Time.deltaTime;
            if (timeForClipChange < time) 
            {
                tv.clip = videoClipList[videoClipList.Count-1];
                time = 0.0f;
            }
        }
        if (angry) 
        {
            time += Time.deltaTime;
            if (time > timeForKill) 
            {
                Kill();
            }
        }
    }

    public void ChangeChannel()
    {
        if (angry) 
        {
            tv.clip = videoClipList[Random.Range(0, videoClipList.Count - 2)]; //Change to any clip that isn't the last one
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
