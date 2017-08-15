using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionManager : MonoBehaviour
{
    // Load level with delay
    public IEnumerator loadLevelWithDelay(string levelName, float delayLength)
    {
        yield return new WaitForSecondsRealtime(delayLength);
        SceneManager.LoadSceneAsync(levelName);
    }

    // Load level
    public void loadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }
}
