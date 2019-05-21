using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeGraph : MonoBehaviour
{
    [SerializeField]
    private Dropdown choosenYear;
    [SerializeField]
    private Sprite cirleSprite;

    private List<GameObject> columns = new List<GameObject>();

    const float FIRSTCOUNTPOS = -87;
    const float FACTORCOUNT = 5.7f;
    const float FIRSTMONTHPOS = -173;
    const float FACTORMONTH = 30;

    List<LearnedWord> words;

    void Start()
    {
        words = Db_Learned.GetAllWords();

        ProccesValue();
    }

    public void ProccesValue()
    {
        ResetGraph();

        var year = Convert.ToInt16(choosenYear.options[choosenYear.value].text);

        int count = 0;
        for (var month = 1; month <= 12; month++)
        {
            count = 0;
            foreach (LearnedWord w in words)
            {
                if (w.LearnedDate.Month == month && w.LearnedDate.Year == year)
                {
                    count++;
                }
            }

            SetColumnPos(count, month);
        }
    }

    void SetColumnPos(int count, int month)
    {
        if (count == 0)
            return;

        float newMonthPos = FIRSTMONTHPOS + (FACTORMONTH * (month - 1));
        float newCountPos = FIRSTCOUNTPOS + (FACTORCOUNT * (count - 1) / 2) - 7.5f;
        float countHeight = 5.7f * (count - 1) + 15;


        columnCreate(new Vector2(newMonthPos, newCountPos), countHeight);
    }

    void columnCreate(Vector2 anchoredPosition, float height)
    {
        GameObject column = new GameObject("Circle", typeof(Image));
        column.transform.SetParent(this.transform, false);
        RectTransform rectTransform = column.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(7.5f, height);
        columns.Add(column);
    }

    void ResetGraph()
    {
        if (columns.Count > 0)
        {
            foreach (GameObject c in columns)
            {
                Destroy(c);
            }

            columns.Clear();
        }
    }
}
