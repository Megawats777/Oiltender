using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeHUDGroup : GameHUDBase
{

    // HUD OBJECTS
    [Header("HUD Objects"), SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Button startButton;

    // Game stage level address
    [SerializeField]
    private string gameStageLevelAddress;


    // EXTERNAL REFERENCES
    private LevelTransitionManager levelTransitionManagerRef;



    // Called before start
    private void Awake()
    {
        levelTransitionManagerRef = FindObjectOfType<LevelTransitionManager>();
    }

    // Use this for initialization
    void Start()
    {
        setIsHUDVisible(true);

        // Update the content of the HUD
        updateHUDContent();

        // Show the mouse cursor
        MouseCursorVisiblityManager.showMouseCursor();

        // Link the launch game event to the start button
        startButton.onClick.AddListener(delegate { launchGame(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void hideHUD()
    {
        hudContentRoot.SetActive(false);
        setIsHUDVisible(false);
    }

    public override void showHUD()
    {
        hudContentRoot.SetActive(true);
        setIsHUDVisible(true);
    }

    public override void updateHUDContent()
    {
        // Set the content of the high score text object
        // to be the same as the saved high score
        highScoreText.text = SaveGameManager.getSavedHighScore().ToString();
    }

    // Launch game
    private void launchGame()
    {
        // Hide this HUD
        hideHUD();

        // Launch game stage
        StartCoroutine(levelTransitionManagerRef.loadLevelWithDelay(gameStageLevelAddress, 2.0f));
    }

}
