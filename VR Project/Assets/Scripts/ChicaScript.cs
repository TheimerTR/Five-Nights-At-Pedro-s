using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicaBehaviour : MonoBehaviour
{
    GameObject angerCondition;
    [SerializeField] bool angry;
    float time;
    public float timeForKill;
    Animator animator;  
    // Start is called before the first frame update
    void Start()
    {
        angry = false;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (angry) 
        {
            time += Time.deltaTime;
            if (time > timeForKill) 
            {
                //Call function for kill
            }
        }
        else 
        {
            time = 0.0f;
        }
    }
}
