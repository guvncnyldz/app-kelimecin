public class Word
{
    public int Id { get; set; }

    public string WordIng { get; private set; }
    public string WordTr { get; private set; }
    public string WordType { get; private set; }

    private string sentence;
    public string Sentence
    {
        get { return sentence; }
        set
        {
            if (value == null || value == "")
                sentence = "Kayıtlı cümle yok";
            else
                sentence = value;
        }
    }

    public WordProgress wordProgress;

    public Word(string wordIng, string wordTr, string wordType, string sentence)
    {
        this.WordIng = wordIng;
        this.WordTr = wordTr;
        this.WordType = wordType;
        this.Sentence = sentence;

        wordProgress = new WordProgress(this);
    }
}
