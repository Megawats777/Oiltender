using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverHUDGroup : GameHUDBase
{

    // HUD OBJECTS
    [Header("HUD Objects"), SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private GameObject newHighScoreNotifyText;


    // EXTERNAL REFERENCES
    private PlayerCharacter playerRef;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerRef = FindObjectOfType<PlayerCharacter>();
    }


    // Use this for initialization
    void Start()
    {
        setIsHUDVisible(false);

        //hideHUD();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void hideHUD()
    {
        setIsHUDVisible(false);
        hudContentRoot.SetActive(false);
    }

    public override void showHUD()
    {
        setIsHUDVisible(true);
        hudContentRoot.SetActive(true);
		MouseCursorVisiblityManager.showMouseCursor();
        updateHUDContent();
    }

    public override void updateHUDContent()
    {
        // Set the content of the current and high score text objects
        currentScoreText.text = playerRef.getCurrentScore().ToString();
        highScoreText.text = playerRef.getHighScore().ToString();

        // Set the visibility of the new high score notify text object
        if (playerRef.getCurrentScore() > playerRef.getHighScore())
        {
            newHighScoreNotifyText.SetActive(true);
        }

        else
        {
            newHighScoreNotifyText.SetActive(false);
        }
    }
}
