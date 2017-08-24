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

    // The motion blur toggle save file name
    private static string motionBlurToggleSaveFileName = "MOTIONBLURTOGGLE.SAVE";

    // The mouse sensitivity value save file name
    private static string mouseSensitivityValueSaveFileName = "MOUSESENSITIVITYVALUE.SAVE";

    // The audio volume value save file name
    private static string audioVolumeValueSaveFileName = "AUDIOVOLUMEVALUE.SAVE";

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



    /*---OPTIONS DATA SAVE FUNCTIONS---*/

    /*-Get and Set saved mouse sensitivity-*/

    // Get the saved mouse sensitivity
    public static float getSavedMouseSensitivity()
    {
        BinaryFormatter fileReader = new BinaryFormatter();

        // If the save file exists
        if (File.Exists(saveDataDirectory + "/" + motionBlurToggleSaveFileName))
        {
            // Open the file
            FileStream fileStream = new FileStream(saveDataDirectory + "/" + mouseSensitivityValueSaveFileName, FileMode.Open);

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
            return 1.5f;
        }
    }

    // Set the saved mouse sensitivity
    public static void setSavedMouseSensitivity(float newMouseSensitivity)
    {
        BinaryFormatter fileWriter = new BinaryFormatter();

        // Create an instance of the options data class
        OptionsData optionsDataRef = new OptionsData();

        // Create the save file
        FileStream fileStream = new FileStream(saveDataDirectory + "/" + mouseSensitivityValueSaveFileName, FileMode.Create);

        // Set the saved mouse sensitivity to the one set the the newMouseSensitivity parameter
        optionsDataRef.savedMouseSensitivity = newMouseSensitivity;

        // Serialize the options data class
        fileWriter.Serialize(fileStream, optionsDataRef);

        // Stop writing to the save file
        fileStream.Close();
    }

    // Reset the saved mouse sensitivity
    public static void resetSavedMouseSensitivity()
    {
        setSavedMouseSensitivity(2.0f);
    }


    /*-Get and Set saved motion blur toggle-*/

    // Get the saved motion blur toggle
    public static bool getSavedMotionBlurToggle()
    {
        BinaryFormatter fileReader = new BinaryFormatter();

        // If the save file exists
        if (File.Exists(saveDataDirectory + "/" + motionBlurToggleSaveFileName))
        {
            // Open the file
            FileStream fileStream = new FileStream(saveDataDirectory + "/" + motionBlurToggleSaveFileName, FileMode.Open);

            // Deserialize the file 
            OptionsData optionsDataRef = (OptionsData)fileReader.Deserialize(fileStream);

            // Get the saved motion blur toggle
            bool fileMotionBlurToggle = optionsDataRef.savedMotionBlurToggle;

            // Stop reading the file
            fileStream.Close();

            // Return the saved motion blur toggle
            return fileMotionBlurToggle;
        }

        // Otherwise
        else
        {
            print("Could not get options data (motion blur toggle) file");
            return true;
        }
    }

    // Set the saved motion blur toggle
    public static void setSavedMotionBlurToggle(bool newStatus)
    {
        BinaryFormatter fileWriter = new BinaryFormatter();

        // Create an instance of the options data class
        OptionsData optionsDataRef = new OptionsData();

        // Create the save file
        FileStream fileStream = new FileStream(saveDataDirectory + "/" + motionBlurToggleSaveFileName, FileMode.Create);

        // Set the saved motion blur toggle to the one set by the new status parameter
        optionsDataRef.savedMotionBlurToggle = newStatus;

        // Serialize the options data class
        fileWriter.Serialize(fileStream, optionsDataRef);

        // Stop writing to the save file
        fileStream.Close();
    }


    /*-Get and Set audio volume value-*/

    // Get the saved audio volume value
    public static float getSavedAudioVolumeValue()
    {
        BinaryFormatter fileReader = new BinaryFormatter();

        // If the file exists
        if (File.Exists(saveDataDirectory + "/" + audioVolumeValueSaveFileName))
        {
            // Open the file
            FileStream fileStream = new FileStream(saveDataDirectory + "/" + audioVolumeValueSaveFileName, FileMode.Open);

            // Deserialize the file
            OptionsData optionsDataRef = (OptionsData)fileReader.Deserialize(fileStream);

            // Get the saved audio volume value
            float fileAudioVolumeValue = optionsDataRef.savedAudioVolumeValue;

            // Stop reading the file
            fileStream.Close();

            // Return the saved audio volume value
            return fileAudioVolumeValue;
        }

        // Otherwise
        else
        {
            print("Could not get options data (Audio Volume) file");
            return 1;
        }
    }

    // Set the saved audio volume value
    public static void setSavedAudioVolumeValue(float newValue)
    {
        BinaryFormatter fileWriter = new BinaryFormatter();

        // Create an instance of the options data class
        OptionsData optionsDataRef = new OptionsData();

        // Create the save file
        FileStream fileStream = new FileStream(saveDataDirectory + "/" + audioVolumeValueSaveFileName, FileMode.Create);

        // Set the saved audio volume value to the one set the by the new value parameter
        optionsDataRef.savedAudioVolumeValue = newValue;

        // Serialize the opttions data class
        fileWriter.Serialize(fileStream, optionsDataRef);

        // Stop writing to the save file
        fileStream.Close();
    }

    // Reset the saved audio volume value
    public static void resetSavedAudioVolumeValue()
    {
        setSavedAudioVolumeValue(1.0f);
    }

    /*---END OF OPTIONS DATA SAVE FUNCTIONS---*/
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

