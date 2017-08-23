using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HowToPlayHUDGroup : GameHUDBase
{
    // HUD SECTIONS
    [Header("HUD Sections"), SerializeField]
    private GameObject controlsHelpSection;
    [SerializeField]
    private GameObject gameRulesHelpSection;
    [SerializeField]
    private GameObject helpSelectionSection;

    // HUD BUTTONS
    [Header("HUD Buttons"), SerializeField]
    private Button controlsHelpSectionTrigger;
    [SerializeField]
    private Button gameRulesHelpSectionTrigger;
    [SerializeField]
    private Button backButton;

    // EXTERNAL REFERENCES
    private WelcomeHUDGroup welcomeHUDRef;

    // Called before start
    private void Awake()
    {
        welcomeHUDRef = FindObjectOfType<WelcomeHUDGroup>();
    }

    // Use this for initialization
    void Start()
    {
        setIsHUDVisible(false);
        hudContentRoot.SetActive(false);

        // Link functions to HUD buttons
        backButton.onClick.AddListener(delegate { transitionToWelcomeScreen(); });
        controlsHelpSectionTrigger.onClick.AddListener(delegate { goToControlsHelpSection(); });
        gameRulesHelpSectionTrigger.onClick.AddListener(delegate { goToGameRulesHelpSection(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Hide this HUD
    public override void hideHUD()
    {
        setIsHUDVisible(false);
        hudContentRoot.SetActive(false);
    }

    // Show this HUD
    public override void showHUD()
    {
        setIsHUDVisible(true);
        hudContentRoot.SetActive(true);

        // Show the help selection section
        helpSelectionSection.SetActive(true);

        // Hide both the controls and game rules help section
        controlsHelpSection.SetActive(false);
        gameRulesHelpSection.SetActive(false);
    }

    public override void updateHUDContent()
    {

    }

    // Go to the controls help section
    public void goToControlsHelpSection()
    {
        // Hide the help selection section
        // Hide the game rules help section
        helpSelectionSection.SetActive(false);
        gameRulesHelpSection.SetActive(false);

        // Show the controls help section
        controlsHelpSection.SetActive(true);

        // Set the function bind of the back button to be
        // Go to help selection section function
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(delegate { goToHelpSelectionSection(); });
    }

    // Go to game rules help section
    public void goToGameRulesHelpSection()
    {
        // Hide the help selection section
        // Hide the controls help section
        helpSelectionSection.SetActive(false);
        controlsHelpSection.SetActive(false);

        // Show the game rules help section
        gameRulesHelpSection.SetActive(true);

        // Set the function bind of the back button to be
        // Go to help selection section function
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(delegate { goToHelpSelectionSection(); });
    }

    // Go to help selection section
    public void goToHelpSelectionSection()
    {
        // Hide the controls help section
        // Hide the game rules help section
        controlsHelpSection.SetActive(false);
        gameRulesHelpSection.SetActive(false);

        // Show the help selection section
        helpSelectionSection.SetActive(true);

        // Set the function bind of the back button to be
        // transition to the welcome screen function
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(delegate { transitionToWelcomeScreen(); });
    }

    // Transition to the welcome screen
    private void transitionToWelcomeScreen()
    {
        // Hide this HUD
        hideHUD();

        // Show the welcome screen HUD
        welcomeHUDRef.showHUD();
    }
}
