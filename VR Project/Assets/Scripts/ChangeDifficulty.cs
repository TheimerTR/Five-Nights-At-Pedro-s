using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using TMPro;

public enum DIFFICULTY : int
{
    TUTORIAL,
    EASY,
    NORMAL,
    HARD
}

public class ChangeDifficulty : MonoBehaviour
{
    public DIFFICULTY difficulty = DIFFICULTY.NORMAL;
    public TextMeshProUGUI text;
    [SerializeField] private PassToGame CS_passToGame;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = DIFFICULTY.TUTORIAL;
        text.text = difficulty.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LessDifficulty()
    {
        if (difficulty > DIFFICULTY.EASY)
        {
            difficulty--;
        }
        else
        {
            difficulty = DIFFICULTY.HARD;
        }

        text.text = difficulty.ToString();
        CS_passToGame.scene = difficulty.ToString();

        Debug.Log("Difficulty--: " + difficulty.ToString());
    }

    public void MoreDifficulty()
    {
        if (difficulty < DIFFICULTY.HARD)
        {
            difficulty++;
        }
        else
        {
            difficulty = DIFFICULTY.TUTORIAL;
        }

        text.text = difficulty.ToString();
        CS_passToGame.scene = difficulty.ToString();

        Debug.Log("Difficulty++: " + difficulty.ToString());
    }
}
