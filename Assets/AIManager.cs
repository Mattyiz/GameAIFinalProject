using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIManager : MonoBehaviour
{
    [SerializeField] private List<Guess> guesses;
    [SerializeField] private Text target;
    [SerializeField] private List<char> targetText;
    [SerializeField] private int length;
    [SerializeField] private int generation;
    [SerializeField] private Text generactionCounter;


    // Start is called before the first frame update
    void Start()
    {

        generation = 0;

        length = target.text.Length;
        for(int i = 0; i < length; i++)
        {
            targetText.Add(target.text[i]);

            targetText[i] = char.ToLower(targetText[i]);
        }

        for(int i = 0; i < guesses.Count; i ++)
        {
            guesses[i].Length = length;

            CreateGuess(guesses[i]);

            guesses[i].Display();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(guesses[0].Score < (length * 10))
        {
            for (int i = 0; i < guesses.Count; i++)
            {
                guesses[i].Score = 0;
                Score(guesses[i]);
            }

            for (int i = 0; i < guesses.Count; i++)
            {
                for (int j = i; j < guesses.Count; j++)
                {
                    if (guesses[i].Score < guesses[j].Score)
                    {
                        Guess temp;
                        temp = guesses[j];

                        guesses[j] = guesses[i];
                        guesses[i] = temp;
                    }
                }
            }

            if(guesses[0].Score < (length * 10))
            {
                NextGeneration();
            }


        }

    }

    private void NextGeneration()
    {
        List<Guess> topTen = new List<Guess>();
        for(int i = 0; i < guesses.Count / 2; i ++)
        {
            topTen.Add(guesses[i]);
        }

        for (int i = 1; i < guesses.Count; i++)
        {
            if(i <= guesses.Count / 2)
            {
                guesses[i].Characters = Cross(topTen[0], guesses[i]);
                guesses[i].Characters = Mutate(guesses[i]);
            }
            /*else if (i == guesses.Count - 1)
            {
                guesses[i].Characters = Mutate(topTen[0]);
                guesses[i].Characters = Mutate(guesses[i]);
                guesses[i].Characters = Mutate(guesses[i]);
            }*/
            else
            {
                guesses[i].Characters = Cross(guesses[i - guesses.Count / 2], topTen[0]);
                guesses[i].Characters = Mutate(guesses[i]);
                //guesses[i].Characters = Mutate(topTen[i - (guesses.Count/2)]);
            }
            guesses[i].Display();
        }

        generation++;
        generactionCounter.text = generation.ToString();

    }

    private List<char> Cross(Guess a, Guess b)
    {
        List<char> crossed = new List<char>();

        for(int i = 0; i < length; i ++)
        {
            if(i <= length/2)
            {
                crossed.Add(a.Characters[i]);
            }
            else
            {
                crossed.Add(b.Characters[i]);
            }
        }

        return crossed;
    }

    private List<char> Mutate(Guess a)
    {

        int index = Random.Range(0, length);

        a.Characters[index] = RandomLetter();

        return a.Characters;
    }

    private void Score(Guess guess)
    {
        for(int i = 0; i < length; i ++)
        {
            if(guess.Characters[i] == targetText[i])
            {
                guess.Score += 10;
            }
            else
            {
                for (int j = 0; j < length; j++)
                {
                    if (guess.Characters[i] == targetText[j])
                    {
                        guess.Score += 5;
                        j = length;
                    }
                }
            }
            
        }
    }

    private void CreateGuess(Guess guess)
    {
        guess.Characters.Clear();

        for (int i = 0; i < length; i++)
        {
            guess.Characters.Add(RandomLetter());
        }
    }

    private char RandomLetter()
    {
        return (char)Random.Range('a', 'z');
    }
}
