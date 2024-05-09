using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixAM : MonoBehaviour
{
    Animator anim;
    public bool win;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            audio.Play();
            Debug.Log("YOU WON!");

            win = false;
        }
    }

    public void isSixAM()
    {
        win = true;
    }
}
