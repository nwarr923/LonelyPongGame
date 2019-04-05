using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save_System : MonoBehaviour
{
    public static Save_System manageData;

    public int highScore;
    public int longestGame;
    public int MostHits;

    private void Awake()
    {
        if (manageData == null)
        {
            DontDestroyOnLoad(gameObject);
            manageData = this;
        }
        else if (manageData != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter BinForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); // Creates save file
        gameData data = new gameData(); // Container for Data
        data.high_score = highScore;
        data.longest_game = longestGame;
        data.most_hits = MostHits;
        BinForm.Serialize(file, data); // Used for encryption
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists (Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file); // Decrypts file
            file.Close();
            highScore = data.high_score;
            longestGame = data.longest_game;
            MostHits = data.most_hits;
        }
    }
}

[Serializable]
class gameData
{
    public int high_score;
    public int longest_game;
    public int most_hits;
}
