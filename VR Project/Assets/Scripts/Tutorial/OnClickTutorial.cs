using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTutorial : MonoBehaviour
{
    public GameObject animatronic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        animatronic.SetActive(true); // enable enemy of the tutorial
        gameObject.transform.parent.gameObject.SetActive(false); // disable Tutorial (canvas and sensor found in parent)
    }
}
