using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Word
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        for (int i = 0; i < length; i++)
        {
            characters.Add(myText.text[i]);

            characters[i] = char.ToLower(characters[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
