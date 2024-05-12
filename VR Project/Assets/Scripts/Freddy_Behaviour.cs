using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Freddy_Behaviour : MonoBehaviour
{
    public List<Vector3> FreddyListRandomPositions;
    Vector3[] positionShelve; //This are their positions of oriigin for when then return to the shelve
    public GameObject[] plushies;
    public int plushesOutOfShelve;
    List<int> positionsPlushies; //Lista posiciones plushies para no repetir.

    float time;

    public SixAM isHour;

    public List<float> firstChangePerHour; //Tiempo que tarda el primer muñeco en salir del estante
    public List<float> extraChangePerHour; //Tiempo que tardan los siguientes muñecos en salir una vez salio el primero.

    // Start is called before the first frame update
    void Start()
    {
        positionShelve = new Vector3[3];
        positionShelve[0] = new Vector3(-4.35f,0f,0f);
        positionShelve[1] = Vector3.zero;
        positionShelve[2] = new Vector3(4.35f, 0f, 0f);

        plushesOutOfShelve = 0;

        time = 0.0f;   
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;

        if (plushesOutOfShelve > 2) //If all plushies are out of the shelve
        {
            //Kill player.
        }
        else if(0 < plushesOutOfShelve) 
        {
            if(extraChangePerHour[(int)isHour.currentHour] < time) 
            {
                RandomPosPlushies(plushies.ElementAt(plushesOutOfShelve)); // If its time to let out another plushie call the function
            }
        }
        else 
        {
            if (firstChangePerHour[(int)isHour.currentHour] < time)
            {
                RandomPosPlushies(plushies.ElementAt(plushesOutOfShelve)); // If its time to let out the first plushie call the function
            }
        }
    }

    private void RandomPosPlushies(GameObject go)
    {
        plushesOutOfShelve++;
        int pos = Random.Range(0,positionShelve.Length);
        bool checkAgain = true;
        while(checkAgain)  //Check de que no se repitan
        { 
            for(int i = 0; i < positionsPlushies.Count; i++) 
            {
                if (positionsPlushies[i] == pos) 
                {
                    checkAgain = false;
                }
            }
        }

        go.transform.position = FreddyListRandomPositions[pos];
        positionsPlushies.Add(pos);

        
    }
}
