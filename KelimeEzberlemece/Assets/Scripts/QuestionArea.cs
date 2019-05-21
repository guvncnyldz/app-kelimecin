using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class QuestionArea : MonoBehaviour
{
    public Button[] choiceButtons = new Button[5];
    public Text questionText;
    public GameObject panel;

    public List<Word> words;

    public int currentQuestion = 0;

    MakeQuestion makeQuestion = new MakeQuestion();

    private void Start()
    {
        GetQuestion();
    }

    public void GetQuestion()
    {
        makeQuestion.Create(words[currentQuestion]);

        questionText.text = makeQuestion.question;

        for (int i = 0; i < 5; i++)
        {
            choiceButtons[i].GetComponentInChildren<Text>().text = makeQuestion.choice[i];
        }
    }

    public void Button_Choosen(Button choosenButton)
    {
        if (choosenButton.GetComponentInChildren<Text>().text == makeQuestion.answer)
        {
            panel.GetComponent<Image>().color = Color.green;
            words[currentQuestion].wordProgress.NextLevel();
        }
        else
        {
            panel.GetComponent<Image>().color = Color.red;
            words[currentQuestion].wordProgress.StartLearning();
        }

        currentQuestion++;
        Invoke("NextQuestion", 1f);
    }

    void NextQuestion()
    {
        if (currentQuestion == words.Count)
            StartCoroutine(SceneOperation.GetInstance().AnimExit(this.gameObject, 1));
        else
        {
            panel.GetComponent<Image>().color = new Color(0.49f, 0.22f, 0.53f);
            GetQuestion();
        }
    }
}
