using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_LearningWords : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject sceneItems;

    void Start()
    {
        GetAllLearningWords();
    }

    void GetAllLearningWords()
    {
        List<Word> words = Db_Learning.GetAllWords();

        foreach (Word word in words)
        {
            GameObject wordObj = new GameObject();
            wordObj.transform.localScale = new Vector3(1, 1, 1);
            wordObj.transform.parent = panel.transform;
            wordObj.AddComponent<Text>();

            Text text = wordObj.GetComponent<Text>();
            text.text = word.WordIng + " - " + word.WordTr;
            text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text.fontSize = 32;
            text.alignment = TextAnchor.MiddleCenter;
            text.color = Color.black;
            text.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Button_Back()
    {
        StartCoroutine(SceneOperation.GetInstance().AnimExit(sceneItems, 1));
    }
}
