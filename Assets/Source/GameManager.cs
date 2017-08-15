using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// The current game state
	private PossibleGameStates currentGameState = PossibleGameStates.Starting;

    // COMPONENT REFERENCES
    private LevelTransitionManager levelTransitionManagerRef;


	// EXTERNAL REFERENCES
	private PlayerCharacter playerRef;
	private Robot robotRef;

	// HUD REFERENCES
	private StartHUDGroup startHUD;
	private PauseHUDGroup pauseHUD;
	private GameOverHUDGroup gameOverHUD;
	private MainHUDGroup mainHUD;

	/*--GETTERS AND SETTERS--*/

	// Get and set the current game state
	public PossibleGameStates getCurrentGameState()
	{
		return currentGameState;
	}

	public void setCurrentGameState(PossibleGameStates currentGameState)
	{
		this.currentGameState = currentGameState;
	}

	/*--END OF GETTERS AND SETTERS--*/


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
        levelTransitionManagerRef = GetComponent<LevelTransitionManager>();


		startHUD = FindObjectOfType<StartHUDGroup>();
		pauseHUD = FindObjectOfType<PauseHUDGroup>();
		gameOverHUD = FindObjectOfType<GameOverHUDGroup>();
		mainHUD = FindObjectOfType<MainHUDGroup>();

		playerRef = FindObjectOfType<PlayerCharacter>();
		robotRef = FindObjectOfType<Robot>();
	}


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

	// Pause the game
	public void pauseGame()
	{
		// Set the current game state to paused
		// Set the time scale to be 0
		// Hide the main game HUD
		// Show the pause HUD
		setCurrentGameState(PossibleGameStates.Paused);
		Time.timeScale = 0.0f;
		mainHUD.hideHUD();
		pauseHUD.showHUD();
	}

	// End the game
	public void endGame()
	{
		// Set the current game state to be Finished
		// Stop the robot from losing health
		// Hide the main game HUD
		// Show the game over HUD
		setCurrentGameState(PossibleGameStates.Finished);
		robotRef.stopDrainingHealth();
		mainHUD.hideHUD();
		gameOverHUD.showHUD();

		// Set the new high score
		playerRef.setNewHighScore();
	}

	// Resume the game
	public void resumeGame()
	{
		// Set the current game state to be Active
		// Set the time scale to 1.0
		// Hide the pause HUD
		// Show the main game HUD
		setCurrentGameState(PossibleGameStates.Active);
		Time.timeScale = 1.0f;
		pauseHUD.hideHUD();
		mainHUD.showHUD();
	}

	// Start the game
	public void startGame()
	{
		// Set the current game state to be Active
		// Hide the starting HUD
		// Show the main game HUD
		// Have the robot start losing health
		setCurrentGameState(PossibleGameStates.Active);
		startHUD.hideHUD();
		mainHUD.showHUD();
		robotRef.startDrainingHealth(robotRef.getDefaultHealthLossDelay());
	}

    // Restart the game
    public void restartGame()
    {
        // If the current game state is Paused
        if (getCurrentGameState() == PossibleGameStates.Paused)
        {
            // If the Pause HUD is visible
            // Hide it
            if (pauseHUD.getIsHUDVisible() == true)
            {
                pauseHUD.hideHUD();
            }

        }

        // If the current game state is finished
        else if (getCurrentGameState() == PossibleGameStates.Finished)
        {
            // If the Game Over HUD is visible
            // Hide it
            if (gameOverHUD.getIsHUDVisible() == true)
            {
                gameOverHUD.hideHUD();
            }
        }

        // Load the current level again after a delay
        StartCoroutine(levelTransitionManagerRef.loadLevelWithDelay(SceneManager.GetActiveScene().name, 2.0f));
    }

    // Quit the game
    public void quitGame()
    {
        // If the current game state is paused
        if (getCurrentGameState() == PossibleGameStates.Paused)
        {
            // If the Pause HUD is visible
            // Hide it
            if (pauseHUD.getIsHUDVisible() == true)
            {
                pauseHUD.hideHUD();
            }
        }

        // If the current game state is finished
        else if (getCurrentGameState() == PossibleGameStates.Finished)
        {
            // If the Game Over HUD is visible
            // Hide it
            if (gameOverHUD.getIsHUDVisible() == true)
            {
                gameOverHUD.hideHUD();
            }
        }

        // Load the main menu level
        levelTransitionManagerRef.loadLevel("Scene_MainMenu_01");
    }
}
