using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;

public static class Db_Learned  {

    static SqliteConnection connection = new SqliteConnection(ConnectionString.connection);

    public static void SetWord(LearnedWord word)
    {
        connection.Open();

        string cmd = "insert into LearnedWords(WordIng,WordTr,Type,Sentence,LearnedDate) Values(@ing,@tr,@type,@sen,@date)";
        SqliteCommand command = new SqliteCommand(cmd, connection);
        command.Parameters.AddWithValue("@ing", word.WordIng);
        command.Parameters.AddWithValue("@tr", word.WordTr);
        command.Parameters.AddWithValue("@type", word.WordType);
        command.Parameters.AddWithValue("@sen", word.Sentence);
        command.Parameters.AddWithValue("@date", DateTime.Now);

        command.ExecuteNonQuery();

        connection.Close();
    }

    public static List<LearnedWord> GetAllWords()
    {
        List<LearnedWord> wordList = new List<LearnedWord>();

        connection.Open();

        string cmd = "select * from LearnedWords";
        SqliteCommand command = new SqliteCommand(cmd, connection);
        SqliteDataReader dr = command.ExecuteReader();

        while (dr.Read())
        {
            LearnedWord word = new LearnedWord(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), (DateTime)dr[5]);
            wordList.Add(word);
        }

        connection.Close();

        return wordList;
    }
}
