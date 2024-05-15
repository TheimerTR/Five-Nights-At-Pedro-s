using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class Freddy_Behaviour : MonoBehaviour
{
    //public List<Vector3> FreddyListRandomPositions;
    public GameObject FreddyListRandomPositions;
    Vector3[] positionShelve; //This are their positions of oriigin for when then return to the shelve
    public GameObject[] plushies;
    public int plushesOutOfShelve;
    List<int> positionsPlushies; //Lista posiciones plushies para no repetir.

    public float time;

    public SixAM isHour;

    public List<float> firstChangePerHour; //Tiempo que tarda el primer muñeco en salir del estante
    public List<float> extraChangePerHour; //Tiempo que tardan los siguientes muñecos en salir una vez salio el primero.

    //Efectos nocivos
    public Flashlight flashlightReferece;
    public List<GameObject> ligthsToTurnOff;
    float timeSwitchLigths;
    // Start is called before the first frame update

    public AudioSource MoveSound;
    void Start()
    {
        positionShelve = new Vector3[3];
        positionShelve[0] = new Vector3(-4.35f,0f,0f);
        positionShelve[1] = Vector3.zero;
        positionShelve[2] = new Vector3(4.35f, 0f, 0f);

        positionsPlushies = new List<int>();

        plushesOutOfShelve = 0;

        time = 0.0f;   
    }

    // Update is called once per frame
    void Update()
    {
        if (isHour.currentHour != SixAM.Hour.SIX_AM)
        {
            time += Time.deltaTime;

            if (plushesOutOfShelve > 2) //If all plushies are out of the shelve
            {
                flashlightReferece.deactivated = true;
                if (time > 15.0f)
                {
                    Debug.Log("Plushies Killed You");
                }
                //Kill player.
            }
            else if (0 < plushesOutOfShelve)
            {
                flashlightReferece.deactivated = false;
                //Debuff based on num plushies out
                if (2 == plushesOutOfShelve)
                {
                    for (int i = 0; i < ligthsToTurnOff.Count; i++)
                    {
                        ligthsToTurnOff[i].SetActive(false);
                    }
                }
                else if (1 == plushesOutOfShelve)
                {
                    timeSwitchLigths += Time.deltaTime;

                    if (timeSwitchLigths > 0.75f)
                    {
                        for (int i = 0; i < ligthsToTurnOff.Count; i++)
                        {
                            if (Random.Range(0, 2) == 0)
                            {
                                ligthsToTurnOff[i].SetActive(false);
                                timeSwitchLigths = 0;
                            }
                        }
                    }

                    for (int i = 0; i < ligthsToTurnOff.Count; i++)
                    {
                        if (!ligthsToTurnOff[i].active && timeSwitchLigths >= 0.3f)
                        {
                            ligthsToTurnOff[i].SetActive(true);
                        }
                    }
                }
                if (extraChangePerHour[(int)isHour.currentHour] < time)
                {
                    RandomPosPlushies(plushies.ElementAt(plushesOutOfShelve)); // If its time to let out another plushie call the function
                    time = 0.0f;
                }
            }
            else
            {
                if (firstChangePerHour[(int)isHour.currentHour] < time)
                {
                    Debug.Log("Mini fredies go");
                    time = 0.0f;
                    RandomPosPlushies(plushies.ElementAt(plushesOutOfShelve)); // If its time to let out the first plushie call the function
                }
            }
        }

    }

    private void RandomPosPlushies(GameObject go)
    {
        MoveSound.Play();

        List<GameObject> list = new List<GameObject>();
        FreddyListRandomPositions.GetChildGameObjects(list);

        plushesOutOfShelve++;
        int pos = Random.Range(0,list.Count);
        bool checkAgain = true;
        if(positionsPlushies.Count == 0) { checkAgain = false; }

        int check = 0;
        while(checkAgain && check<10)  //Check de que no se repitan
        { 
            check++;
            for(int i = 0; i < positionsPlushies.Count; i++) 
            {
                if (positionsPlushies[i] != pos)
                {
                    checkAgain = false;
                    //break;
                }
                else 
                {
                    checkAgain = true;
                    pos = Random.Range(0, list.Count);
                }
            }
        }

        go.transform.position = list[pos].transform.position;
        go.transform.rotation = list[pos].transform.rotation;
        XRGrabInteractable xr = go.GetComponent<XRGrabInteractable>();
        xr.enabled = true;
        positionsPlushies.Add(pos);
    }
}
