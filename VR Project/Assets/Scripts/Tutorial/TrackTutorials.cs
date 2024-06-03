using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackTutorials : MonoBehaviour
{
    public int completedTutorials = 0;
    public int numberTutorials = 5;
    public GameObject canvasEnd;

    // Start is called before the first frame update
    void Start()
    {
        completedTutorials = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTutorials()
    {
        completedTutorials++;

        if (completedTutorials == numberTutorials)
        {
            canvasEnd.SetActive(true);
        }
    }
}
