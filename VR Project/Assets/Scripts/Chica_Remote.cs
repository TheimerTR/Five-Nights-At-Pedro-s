using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using static SixAM;

public class Chica_Remote : MonoBehaviour
{
    public GameObject chica;
    Chica_Behaviour chicaBehaviour;
    public SixAM isHour;

    // Start is called before the first frame update
    void Start()
    {
        chicaBehaviour = chica.GetComponent<Chica_Behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("Chica Kill");
                chicaBehaviour.ChangeChannel();
            }
        }
    }

    public void ChangeCH()
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            chicaBehaviour.ChangeChannel();
        }
    }
}
