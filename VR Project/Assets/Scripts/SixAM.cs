using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SixAM : MonoBehaviour
{
    Animator anim;
    public bool win;

    public VideoPlayer tv;
    public VideoClip isSixAM_Video;

    public Light directionalLight;

    AudioSource audio;

    public enum Hour 
    {
        ZERO_AM,
        ONE_AM,
        TWO_AM,
        THREE_AM,
        FOUR_AM,
        FIVE_AM,
        SIX_AM,
    }

    public Hour currentHour;

    public GameObject rain;
    public AudioSource rainSound;
    public AudioSource AmbientSound;
    public AudioSource MusicSound;

    Color Night;
    Color Day;

    public float DayTimer = 0;

    public float TimeTransition;
    public float TimerToReturn = 0;

    public bool ReturnToScene = false;

    // Start is called before the first frame update
    void Start()
    {
        Night = new Color(0.09692062f, 0.1262041f, 0.2075472f, 1f);
        Day = new Color(0.8113208f, 0.6888272f, 0.4324493f, 1f);
        directionalLight.color = Night;

        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        win = false;

        currentHour = Hour.ZERO_AM;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            win = true;
        }

        if (win)
        {
            tv.clip = isSixAM_Video;
            tv.SetDirectAudioVolume(0, 0);
            audio.Play();

            rain.SetActive(false);
            rainSound.Stop();
            AmbientSound.Stop();
            MusicSound.Stop();

            if (DayTimer < 1)
            {
                DayTimer += Time.deltaTime / TimeTransition;

                directionalLight.color = Color.Lerp(Night, Day, DayTimer);


                Debug.Log("YOU WON!");
            }

            if (DayTimer >= 1)
            {
                win = false;
                ReturnToScene = true;
            }
        }

        if (ReturnToScene)
        {
            TimerToReturn += Time.deltaTime;

            if (TimerToReturn >= 12)
            {
                SceneManager.LoadScene("Level Selector");
            }
        }
    }

    public void isSixAM()
    {
        win = true;
        currentHour = Hour.SIX_AM;
    }

    public void isZeroAM() 
    {
        currentHour = Hour.ZERO_AM;
    }
    public void isOneAM() 
    {
        currentHour = Hour.ONE_AM;
    }
    public void isTwoAM() 
    {
        currentHour = Hour.TWO_AM;
    }
    public void isThreeAM() 
    {
        currentHour = Hour.THREE_AM;
    }
    public void isFourAM() 
    {
        currentHour = Hour.FOUR_AM;
    }
    public void isFiveAM() 
    {
        currentHour = Hour.FIVE_AM;
    }
}
