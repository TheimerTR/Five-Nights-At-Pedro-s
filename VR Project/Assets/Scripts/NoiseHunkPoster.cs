using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseHunkPoster : MonoBehaviour
{
    AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            m_AudioSource.Play();
        }
    }
}
