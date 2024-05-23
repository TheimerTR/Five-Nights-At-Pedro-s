using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MiniFreddy_Behaviour : MonoBehaviour
{
    public bool isOut;
    public Freddy_Behaviour freddy;
    XRGrabInteractable interactable;
    public int plushieNumber;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        isOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOut) 
        {
            if(Input.GetKeyDown(KeyCode.F)) 
            {
                transform.position = freddy.positionShelve[plushieNumber];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (interactable.enabled)
        {
            if (other.tag == "IsInShelve")
            {
                freddy.plushiesOut[plushieNumber] = false;
                freddy.plushesOutOfShelve--;
                freddy.time = 0.0f;
                interactable.enabled = false;
                transform.position = freddy.positionShelve[plushieNumber];
            }
        }
    }
}
