using System;

public class WordProgress
{
    public int level;
    public DateTime Date { get; private set; }

    private Word progressedWord;

    public WordProgress(Word progressedWord)
    {
        this.progressedWord = progressedWord;
    }

    public void StartLearning()
    {
        level = 1;
        Date = DateTime.Now.AddDays(1);

        Db_Learning.UpdateWord(progressedWord);
    }

    public void NextLevel()
    {
        level++;

        switch (level)
        {
            case 2: Date = DateTime.Now.AddMonths(1); break;
            case 3: Date = DateTime.Now.AddMonths(6); break;
            case 4: Date = DateTime.Now.AddYears(1); break;
            case 5: FinishLearning(); return;
        }

        Db_Learning.UpdateWord(progressedWord);
    }

    public void SetProgress(int level, DateTime date)
    {
        this.level = level;
        this.Date = date;
    }

    private void FinishLearning()
    {
        LearnedWord learned = new LearnedWord(progressedWord.WordIng, progressedWord.WordTr, progressedWord.WordType, progressedWord.Sentence, DateTime.Now);
        Db_Learning.DeleteWord(progressedWord);
        Db_Learned.SetWord(learned);
    }
}
