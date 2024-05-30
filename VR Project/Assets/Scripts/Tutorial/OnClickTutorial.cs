using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnClickTutorial : MonoBehaviour
{
    public GameObject animatronic;
    private bool _end = false;
    private float passScene = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_end)
        {
            passScene += Time.deltaTime;

            if (passScene > 1.5f)
            {
                SceneManager.LoadScene("Dead"); // Go to main menu
            }
        }
    }

    public void Click()
    {
        animatronic.SetActive(true); // enable enemy of the tutorial
        gameObject.transform.parent.gameObject.SetActive(false); // disable Tutorial (canvas and sensor found in parent)
    }

    public void End()
    {
        _end = true;
    }
}
