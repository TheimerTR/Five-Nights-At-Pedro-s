using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Chica_Remote : MonoBehaviour
{
    public GameObject chica;
    Chica_Behaviour chicaBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        chicaBehaviour = chica.GetComponent<Chica_Behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(false) 
        {
            chicaBehaviour.ChangeChannel();
        }
    }
}
