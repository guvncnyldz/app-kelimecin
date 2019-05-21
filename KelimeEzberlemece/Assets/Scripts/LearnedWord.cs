using System;

public class LearnedWord
{
    public string WordIng { get; private set; }
    public string WordTr { get; private set; }
    public string WordType { get; private set; }
    public string Sentence { get; private set; }

    public DateTime LearnedDate { get; private set; }

    public LearnedWord(string wordIng, string wordTr, string wordType, string sentence, DateTime learnedDate)
    {
        this.WordIng = wordIng;
        this.WordTr = wordTr;
        this.WordType = wordType;
        this.Sentence = sentence;

        this.LearnedDate = learnedDate;
    }
}
