using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIFFICULTY : int
{
    TUTORIAL,
    PUTO_CASUAL,
    NORMAL,
    HARD
}

public class ChangeDifficulty : MonoBehaviour
{
    public DIFFICULTY difficulty = DIFFICULTY.NORMAL;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LessDifficulty()
    {
        difficulty--;

        Debug.Log("Difficulty--: " + difficulty.ToString());
    }

    public void MoreDifficulty()
    {
        difficulty++;

        Debug.Log("Difficulty++: " + difficulty.ToString());
    }
}
