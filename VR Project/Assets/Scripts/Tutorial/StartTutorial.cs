using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : MonoBehaviour
{
    // Canvases to enable

    public GameObject bonnieCanvas;
    public GameObject foxyCanvas;
    public GameObject puppetCanvas;
    public GameObject chicaCanvas;

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
        switch (other.gameObject.tag)
        {
            case "Bonnie":
                bonnieCanvas.SetActive(true);
                break;
            case "Foxy":
                foxyCanvas.SetActive(true);
                break;            
            case "Puppet":
                puppetCanvas.SetActive(true);
                break;            
            case "Chica":
                chicaCanvas.SetActive(true);
                break;
            default:
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bonnie":
                bonnieCanvas.SetActive(false);
                break;
            case "Foxy":
                foxyCanvas.SetActive(false);
                break;            
            case "Puppet":
                puppetCanvas.SetActive(false);
                break;            
            case "Chica":
                chicaCanvas.SetActive(false);
                break;
            default:
                break;
        }
    }
}
