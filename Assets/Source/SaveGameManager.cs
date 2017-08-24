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


    /*--PLAYER DATA SAVE FUNCTIONS--*/


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
            PlayerData playerDataRef = (PlayerData)fileReader.Deserialize(fileStream);

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

        // Create an instance of the player data class
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

    /*--END OF PLAYER DATA SAVE FUNCTIONS--*/



    /*--OPTIONS DATA SAVE FUNCTIONS--*/

    // Get the saved mouse sensitivity
    public static float getSavedMouseSensitivity()
    {
        BinaryFormatter fileReader = new BinaryFormatter();

        // If the save file exists
        if (File.Exists(saveDataDirectory + "/" + "OPTIONSDATA.SAVE"))
        {
            // Open the file
            FileStream fileStream = new FileStream(saveDataDirectory + "/" + "OPTIONSDATA.SAVE", FileMode.Open);

            // Deserialize the file
            OptionsData optionsDataRef = (OptionsData)fileReader.Deserialize(fileStream);

            // Get the saved mouse sensitivity
            float fileMouseSensitivity = optionsDataRef.savedMouseSensitivity;

            // Stop reading the file
            fileStream.Close();

            // Return the saved high score
            return fileMouseSensitivity;
        }

        // Otherwise
        else
        {
            print("Could not get options data (Mouse Sensitivity) file");
            return 20.0f;
        }
    }

    // Set the saved mouse sensitivity
    public static void setSavedMouseSensitivity(float newMouseSensitivity)
    {
        BinaryFormatter fileWriter = new BinaryFormatter();

        // Create and instance of the options data class
        OptionsData optionsDataRef = new OptionsData();

        // Create the save file
        FileStream fileStream = new FileStream(saveDataDirectory + "/" + "OPTIONSDATA.SAVE", FileMode.Create);

        // Set the saved mouse sensitivity to the options data instance
        optionsDataRef.savedMouseSensitivity = newMouseSensitivity;

        // Serialize the options data class
        fileWriter.Serialize(fileStream, optionsDataRef);

        // Stop writing to the save file
        fileStream.Close();
    }

    /*--END OF OPTIONS DATA SAVE FUNCTIONS--*/
}

// Acts as a container for the player's data
[Serializable]
public class PlayerData
{
    // The player's saved high score
    public int savedHighScore;
}

// Acts as a container for options data
[Serializable]
public class OptionsData
{
    // The saved mouse sensitivity
    public float savedMouseSensitivity = 20.0f;

    // The saved motion blur toggle
    public bool savedMotionBlurToggle = true;

    // The saved audio volume value
    public float savedAudioVolumeValue = 1.0f;
}

