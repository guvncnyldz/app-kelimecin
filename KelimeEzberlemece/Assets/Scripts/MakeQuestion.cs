using System.Collections.Generic;
using UnityEngine;

public class MakeQuestion : MonoBehaviour
{ 
    public string question, answer;

    public string[] choice;

    public void Create(Word word)
    {
        question = word.WordIng;
        answer = word.WordTr;

        Choices();

    }

    private void Choices()
    {
        choice = new string[5];

        int trueChoice = Random.Range(0, 5);
        choice[trueChoice] = answer;

        for (int i = 0; i < 5; i++)
        {
            if (i == trueChoice)
                continue;

            do
            {
                choice[i] = Vocabulary.words[Random.Range(0, choice.Length)];
            } while (choice[i] == answer);
        }
    }
}
