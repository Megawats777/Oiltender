using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine;

// Handles getting and setting saved data
public class SaveGameManager : MonoBehaviour
{
    // Application save data directory
    private static string saveDataDirectory = Application.persistentDataPath;

    // Get the saved high score
    public static int getSavedHighScore()
    {
        BinaryFormatter fileReader = new BinaryFormatter();

        // If the save file exists
        if (File.Exists(saveDataDirectory + "/" + "HighScore.SAVE"))
        {
            // Open the file
            FileStream fileStream = new FileStream(saveDataDirectory + "/" + "HighScore.SAVE", FileMode.Open);

            // Deserialize the file
            PlayerData playerDataRef = (PlayerData) fileReader.Deserialize(fileStream);

            // Get the saved high score
            int fileScore = playerDataRef.savedHighScore;

            // Stop reading the file
            fileStream.Close();

            // Return the saved high score
            return fileScore;
        }

        // Otherwise
        else
        {
            print("Could not get player data file");
            return 0;
        }
    }

    // Set the saved high score
    public static void setSavedHighScore(int newHighScore)
    {
        BinaryFormatter fileWriter = new BinaryFormatter();

        // Create and instance of the player data class
        PlayerData playerDataRef = new PlayerData();

        // Create the save file
        FileStream fileStream = new FileStream(saveDataDirectory + "/" + "HighScore.SAVE", FileMode.Create);

        // Set the saved high score to the player data instance
        playerDataRef.savedHighScore = newHighScore;

        // Serialize the player data class
        fileWriter.Serialize(fileStream, playerDataRef);

        // Stop writing to the save file
        fileStream.Close();
    }
}

// Acts as a container for the player's data
[Serializable]
public class PlayerData
{
    // The player's saved high score
    public int savedHighScore;
}
