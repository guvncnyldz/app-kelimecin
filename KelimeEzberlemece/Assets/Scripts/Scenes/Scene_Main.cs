using System;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Main : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneItems, questionArea;

    private void Start()
    {
        List<Word> askableWord = new List<Word>();

        foreach (Word w in Db_Learning.GetAllWords())
        {
            if (DateTime.Now > w.wordProgress.Date)
                askableWord.Add(w);
        }

        if (askableWord.Count > 0)
            AskQuestion(askableWord);
    }

    public void Button_Main(int choosenScene)
    {
        StartCoroutine(SceneOperation.GetInstance().AnimExit(sceneItems, choosenScene));
    }

    void AskQuestion(List<Word> words)
    {
        sceneItems.SetActive(false);

        questionArea.SetActive(true);
        questionArea.GetComponent<QuestionArea>().words = words;
    }
}
