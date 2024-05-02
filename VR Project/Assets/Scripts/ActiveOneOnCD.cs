using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOneOnCD : MonoBehaviour
{
    public GameObject[] go;

    private float cd;
    public float minCd;
    public float maxCd;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        cd = Random.Range(minCd, maxCd);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            cd = -Time.deltaTime;
        }

        if (cd <= 0)
        {
            go[Random.Range(0, go.Length)].SetActive(true);
            isActive = true;
        }
    }

    public void ResetCD()
    {
        cd = Random.Range(minCd, maxCd);
        isActive = false;
    }
}
