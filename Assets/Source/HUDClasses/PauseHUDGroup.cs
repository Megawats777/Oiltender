using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseHUDGroup : GameHUDBase
{

    // HUD OBJECTS
    [Header("HUD Objects"), SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text highScoreText;


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
		//hideHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void hideHUD()
    {
        hudContentRoot.SetActive(false);
    }

    public override void showHUD()
    {
        hudContentRoot.SetActive(true);
		MouseCursorVisiblityManager.showMouseCursor();
        updateHUDContent();
    }

    public override void updateHUDContent()
    {
        // Set the content of the current and high score text objects
        currentScoreText.text = playerRef.getCurrentScore().ToString();
        highScoreText.text = playerRef.getHighScore().ToString();
    }

}
