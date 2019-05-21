using UnityEngine;
using UnityEngine.UI;

public class Scene_AddWord : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneItems, PopUpPanel;

    public InputField wordIng, wordTr, sentence;
    public Dropdown wordType;
    public Text popUpText;

    public void Button_AddWord()
    {
        if (wordIng.text == "" || wordTr.text == "")
        {
            PopUp("Zorunlu yerleri doldurun");
        }
        else
        {
            Word word = new Word(wordIng.text, wordTr.text, wordType.options[wordType.value].text, sentence.text);
            word.wordProgress.StartLearning();

            Db_Learning.SetWord(word);
            PopUp("Kayıt Başarılı");

            ResetTextbox();
        }
    }

    public void PopUp(string errorMessage)
    {
        PopUpPanel.SetActive(true);
        popUpText.text = errorMessage;
    }

    public void Button_Ok()
    {
        PopUpPanel.SetActive(false);
    }

    public void Button_Back()
    {
        StartCoroutine(SceneOperation.GetInstance().AnimExit(sceneItems, 1));
    }

    public void ResetTextbox()
    {
        wordIng.text = "";
        wordTr.text = "";
        sentence.text = "";
    }
}
