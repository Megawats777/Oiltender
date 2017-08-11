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
        hudContentRoot.SetActive(false);
    }

    public override void showHUD()
    {
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
        blueDiamondOrderText.text = orderManagerRef.getDispensedBlueDiamond() + " / " + orderManagerRef.getRequiredBlueDiamond();
        magicGrapeOrderText.text = orderManagerRef.getDispensedMagicGrape() + " / " + orderManagerRef.getRequiredMagicGrape();
        redSugarOrderText.text = orderManagerRef.getDispensedRedSugar() + " / " + orderManagerRef.getRequiredRedSugar();
    }




}