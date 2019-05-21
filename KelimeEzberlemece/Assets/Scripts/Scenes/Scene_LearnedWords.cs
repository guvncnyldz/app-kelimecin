using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_LearnedWords : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneItems;
    [SerializeField]
    private Dropdown dropdownWordIng;
    [SerializeField]
    private Text wordTr, wordType, wordDate, sentence;

    List<LearnedWord> words;

    void Start()
    {
        words = Db_Learned.GetAllWords();

        FillDropDowns();
    }

    void FillDropDowns()
    {
        List<string> d_options = new List<string>();

        foreach (LearnedWord w in words)
        {
            d_options.Add(w.WordIng);
        }

        SetLabel(words[0]);
        dropdownWordIng.ClearOptions();
        dropdownWordIng.AddOptions(d_options);
    }

    public void DropDown_OnChange(Text wordIng)
    {
        foreach (LearnedWord w in words)
        {
            if (w.WordIng == wordIng.text)
            {
                SetLabel(w);
            }

        }
    }

    private void SetLabel(LearnedWord w)
    {
        wordTr.text = w.WordTr;
        wordType.text = w.WordType;
        wordDate.text = w.LearnedDate.ToString("dd/MM/yyyy");
        sentence.text = w.Sentence;
    }

    public void Button_Back()
    {
        StartCoroutine(SceneOperation.GetInstance().AnimExit(sceneItems, 1));
    }
}
