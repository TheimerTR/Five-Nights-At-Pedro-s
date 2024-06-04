using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromDie : MonoBehaviour
{
    float timerToReturn = 0;
    public float timeToSceneReturn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerToReturn += Time.deltaTime;

        if(timerToReturn > timeToSceneReturn)
        {
            SceneManager.LoadScene("Level Selector");
            timerToReturn = 0;
        }
    }
}
