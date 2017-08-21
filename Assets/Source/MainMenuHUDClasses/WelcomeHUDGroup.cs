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
    [SerializeField]
    private Button howToPlayButton;
    [SerializeField]
    private Button optionsButton;

    // Game stage level address
    [Space(2), SerializeField]
    private string gameStageLevelAddress;



    // EXTERNAL REFERENCES
    private LevelTransitionManager levelTransitionManagerRef;
    private HowToPlayHUDGroup howToPlayHUDRef;
    private OptionsHUDGroup optionsHUDRef;

    // Called before start
    private void Awake()
    {
        levelTransitionManagerRef = FindObjectOfType<LevelTransitionManager>();

        howToPlayHUDRef = FindObjectOfType<HowToPlayHUDGroup>();
        optionsHUDRef = FindObjectOfType<OptionsHUDGroup>();
    }

    // Use this for initialization
    void Start()
    {
        showHUD();
        setIsHUDVisible(true);

        // Update the content of the HUD
        updateHUDContent();

        // Show the mouse cursor
        MouseCursorVisiblityManager.showMouseCursor();

        // Link events to HUD buttons
        startButton.onClick.AddListener(delegate { launchGame(); });
        howToPlayButton.onClick.AddListener(delegate { transitionToHowToPlayScreen(); });
        optionsButton.onClick.AddListener(delegate { transitionToOptionsScreen();  });
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

    // Transition to the how to play screen
    private void transitionToHowToPlayScreen()
    {
        // Hide this HUD
        hideHUD();

        // Show the how to play HUD
        howToPlayHUDRef.showHUD();
    }

    // Transition to options screen
    private void transitionToOptionsScreen()
    {
        // Hide this HUD
        hideHUD();

        // Show the options HUD
        optionsHUDRef.showHUD();
    }

}
