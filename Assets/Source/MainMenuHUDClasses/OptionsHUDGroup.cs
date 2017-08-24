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

        // Update options control elements
        updateOptionsControlElements();

        // Bind functions to HUD objects
        bindFunctionsToHUDObjects();
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

        // Update options control elements
        updateOptionsControlElements();

        // Bind functions to HUD objects
        bindFunctionsToHUDObjects();
    }

    public override void updateHUDContent()
    {
        
    }

    // Update slider value text
    private void updateSliderValueText(Text textToUpdate, float value)
    {
        textToUpdate.text = Math.Round(value, 2).ToString();
    }

    // Update options control elements
    private void updateOptionsControlElements()
    {
        // Set the value of the motion blur toggle to be the same as the saved options data
        motionBlurToggle.isOn = SaveGameManager.getSavedMotionBlurToggle();

        // Set the value of the sliders to be the same as the saved options data
        mouseSensitivitySlider.value = SaveGameManager.getSavedMouseSensitivity();

        // Show the values of the sliders on their respective labels
        mouseSensitivityValueText.text = Math.Round(mouseSensitivitySlider.value, 2).ToString();
    }

    // Bind functions to HUD objects
    private void bindFunctionsToHUDObjects()
    {
        backButton.onClick.AddListener(delegate { transitionToWelcomeScreen(); });
        mouseSensitivitySlider.onValueChanged.AddListener(delegate { updateSliderValueText(mouseSensitivityValueText, mouseSensitivitySlider.value); });
    }


    // Transition to welcome screen
    private void transitionToWelcomeScreen()
    {
        print(mouseSensitivitySlider.value);
        
        // Set the saved data values
        SaveGameManager.setSavedMouseSensitivity(mouseSensitivitySlider.value);
        SaveGameManager.setSavedMotionBlurToggle(motionBlurToggle.isOn);

        print(SaveGameManager.getSavedMouseSensitivity());

        // Hide this HUD
        hideHUD();

        // Show the welcome HUD
        welcomeHUDRef.showHUD();
    }

}
