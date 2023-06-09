using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guess : Word
{

    [SerializeField] private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void Display()
    {
        myText.text = "";
        for (int i = 0; i < length; i++)
        {
            myText.text += characters[i];
        }
    }
}
