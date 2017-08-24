using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsHUDGroup : GameHUDBase
{

    // HUD OBJECTS
    [Header("HUD Objects"), SerializeField]
    private Slider mouseSensitivitySlider;
    [SerializeField]
    private Text mouseSensitivityValueText;
    [SerializeField]
    private Toggle motionBlurToggle;
    [SerializeField]
    private Slider audioVolumeSlider;
    [SerializeField]
    private Text audioVolumeValueText;
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
        hudContentRoot.SetActive(false);
        setIsHUDVisible(false);

        // Set the value of the sliders to be the same as the saved options data
        mouseSensitivitySlider.value = SaveGameManager.getSavedMouseSensitivity();

        // Show the values of the sliders on their respective labels
        mouseSensitivityValueText.text = Math.Round(mouseSensitivitySlider.value, 2).ToString();

        // Bind functions to HUD objects
        backButton.onClick.AddListener(delegate { transitionToWelcomeScreen(); });
        mouseSensitivitySlider.onValueChanged.AddListener(delegate { updateSliderValueText(mouseSensitivityValueText, mouseSensitivitySlider.value); });
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
    }

    public override void updateHUDContent()
    {
        
    }

    // Update slider value text
    private void updateSliderValueText(Text textToUpdate, float value)
    {
        textToUpdate.text = Math.Round(value, 2).ToString();
    }

    // Transition to welcome screen
    private void transitionToWelcomeScreen()
    {
        print(mouseSensitivitySlider.value);
        // Set the saved data
        SaveGameManager.setSavedMouseSensitivity(mouseSensitivitySlider.value);

        // Hide this HUD
        hideHUD();

        // Show the welcome HUD
        welcomeHUDRef.showHUD();
    }

}
