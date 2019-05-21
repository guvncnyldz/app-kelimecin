using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;

public static class Db_Learning
{

    static SqliteConnection connection = new SqliteConnection(ConnectionString.connection);

    public static void SetWord(Word word)
    {
        connection.Open();

        string cmd = "insert into LearningWords(WordIng,WordTr,Type,Sentence,NextAskDate,Level) Values(@ing,@tr,@type,@sen,@date,@level)";
        SqliteCommand command = new SqliteCommand(cmd, connection);
        command.Parameters.AddWithValue("@ing", word.WordIng);
        command.Parameters.AddWithValue("@tr", word.WordTr);
        command.Parameters.AddWithValue("@type", word.WordType);
        command.Parameters.AddWithValue("@sen", word.Sentence);
        command.Parameters.AddWithValue("@date", word.wordProgress.Date);
        command.Parameters.AddWithValue("@level", word.wordProgress.level);

        command.ExecuteNonQuery();

        connection.Close();
    }

    public static void UpdateWord(Word word)
    {
        connection.Open();

        string cmd = "update LearningWords set NextAskDate=@date,level=@level where Id=@id";
        SqliteCommand command = new SqliteCommand(cmd, connection);
        command.Parameters.AddWithValue("@date", word.wordProgress.Date);
        command.Parameters.AddWithValue("@level", word.wordProgress.level);
        command.Parameters.AddWithValue("@id", word.Id);
        command.ExecuteNonQuery();

        connection.Close();
    }

    public static void DeleteWord(Word word)
    {
        connection.Open();

        string cmd = "delete from LearningWords where Id=@id";
        SqliteCommand command = new SqliteCommand(cmd, connection);
        command.Parameters.AddWithValue("@id", word.Id);
        command.ExecuteNonQuery();

        connection.Close();
    }

    public static List<Word> GetAllWords()
    {
        List<Word> wordList = new List<Word>();

        connection.Open();

        string cmd = "select * from LearningWords";
        SqliteCommand command = new SqliteCommand(cmd, connection);
        SqliteDataReader dr = command.ExecuteReader();

        while (dr.Read())
        {
            Word word = new Word(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            word.Id = Convert.ToInt32(dr[0]);

            word.wordProgress.SetProgress(Convert.ToInt16(dr[6].ToString()), (DateTime) dr[5]);

            wordList.Add(word);
        }

        connection.Close();

        return wordList;
    }
}
