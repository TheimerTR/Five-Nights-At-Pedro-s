using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
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
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                List<GameObject> list = new List<GameObject>();
                freddy.FreddyReturnPosition.GetChildGameObjects(list);
           
                gameObject.transform.position = list[plushieNumber].transform.position;
                gameObject.transform.rotation = list[plushieNumber].transform.rotation;

                isOut = false;
                //gameObject.GetComponent<Rigidbody>().useGravity = false;
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

                List<GameObject> list = new List<GameObject>();
                freddy.FreddyReturnPosition.GetChildGameObjects(list);

                gameObject.transform.position = list[plushieNumber].transform.position;
                gameObject.transform.rotation = list[plushieNumber].transform.rotation;
            }
        }
    }
}
