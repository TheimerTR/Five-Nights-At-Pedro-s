using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixAM : MonoBehaviour
{
    Animator anim;
    public bool win;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            Debug.Log("YOU WON!");
        }
    }

    public void isSixAM()
    {
        win = true;
    }
}
