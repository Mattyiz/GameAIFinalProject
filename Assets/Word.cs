using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    [SerializeField] protected int length;
    [SerializeField] protected List<char> characters;
    [SerializeField] protected Text myText;

    public int Length
    {
        get
        {
            return length;
        }
        set
        {
            length = value;
        }
    }

    public List<char> Characters
    {
        get
        {
            return characters;
        }
        set
        {
            characters = value;
        }
    }

    // Start is called before the first frame update
    protected void Start()
    {
        myText = GetComponent<Text>();
        length = myText.text.Length;

    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

}
