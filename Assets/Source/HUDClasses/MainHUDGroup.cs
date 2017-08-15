using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MainHUDGroup : GameHUDBase
{
    // HUD OBJECTS
    [Header("HUD Objects"), SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Text robotHealthText;

    // ORDER REQUIREMENTS HUD OBJECTS
    [Header("Order Requirements HUD Objects"), SerializeField]
    private Text blueDiamondOrderText;
    [SerializeField]
    private Text magicGrapeOrderText;
    [SerializeField]
    private Text redSugarOrderText;

    // The default font sizes for each of the order requirements HUD objects
    private int blueDiamondOrderTextDefaultFontSize;
    private int magicGrapeOrderTextDefaultFontSize;
    private int redSugarOrderTextDefaultFontSize;

    // The font size for the order requirements HUD objects when an order is being acquired
    [SerializeField]
    private int acquiringOrderFontSize = 20;

    // EXTERNAL REFERENCES
    private PlayerCharacter playerRef;
    private Robot robotRef;
    private OrderManager orderManagerRef;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        playerRef = FindObjectOfType<PlayerCharacter>();
        robotRef = FindObjectOfType<Robot>();
        orderManagerRef = FindObjectOfType<OrderManager>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // Set the default font sizes for each of the order requirements HUD objects
        blueDiamondOrderTextDefaultFontSize = blueDiamondOrderText.fontSize;
        magicGrapeOrderTextDefaultFontSize = magicGrapeOrderText.fontSize;
        redSugarOrderTextDefaultFontSize = redSugarOrderText.fontSize;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        updateHUDContent();
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
        MouseCursorVisiblityManager.hideMouseCursor();
    }

    public override void updateHUDContent()
    {
        // Set the content for the current score, high score, and robot health text objects
        currentScoreText.text = playerRef.getCurrentScore().ToString();
        highScoreText.text = playerRef.getHighScore().ToString();
        robotHealthText.text = robotRef.getHealth().ToString();

        // Set the content for the order requirements text objects
        // If a new order is being generated
        // Show a message on order requirements HUD objects
        // Set the font size for the order requirements HUD objects to be order acquired font size
        if (orderManagerRef.getIsNewOrderBeingGenerated() == true)
        {
            blueDiamondOrderText.text = "Acquiring Order...";
            blueDiamondOrderText.fontSize = acquiringOrderFontSize;

            magicGrapeOrderText.text = "Acquiring Order...";
            magicGrapeOrderText.fontSize = acquiringOrderFontSize;
            
            redSugarOrderText.text = "Acquiring Order...";
            redSugarOrderText.fontSize = acquiringOrderFontSize;
        }

        // Otherwise show the status of the orders
        // Set the font size of the order requirements HUD objects to be their default font size
        else
        {
            blueDiamondOrderText.text = orderManagerRef.getDispensedBlueDiamond() + " / " + orderManagerRef.getRequiredBlueDiamond();
            blueDiamondOrderText.fontSize = blueDiamondOrderTextDefaultFontSize;

            magicGrapeOrderText.text = orderManagerRef.getDispensedMagicGrape() + " / " + orderManagerRef.getRequiredMagicGrape();
            magicGrapeOrderText.fontSize = magicGrapeOrderTextDefaultFontSize;

            redSugarOrderText.text = orderManagerRef.getDispensedRedSugar() + " / " + orderManagerRef.getRequiredRedSugar();
            redSugarOrderText.fontSize = redSugarOrderTextDefaultFontSize;
        }
    }
}