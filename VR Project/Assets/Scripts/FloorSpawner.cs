using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject Flashlight;
    public GameObject TVcontroller;

    public Transform flashT;
    public Transform contrT;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Flashlight)
        {
            //Debug.Log("Enter");
            Flashlight.transform.position = flashT.position;
            Flashlight.transform.rotation = flashT.rotation;
        }
        
        if(other.gameObject == TVcontroller)
        {
            Debug.Log("Enter");
            TVcontroller.transform.position = contrT.position;
            TVcontroller.transform.rotation = contrT.rotation;
        }
    }
}
