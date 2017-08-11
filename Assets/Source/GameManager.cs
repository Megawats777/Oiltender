using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// The current game state
	private PossibleGameStates currentGameState = PossibleGameStates.Starting;

	// EXTERNAL REFERENCES
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
		startHUD = FindObjectOfType<StartHUDGroup>();
		pauseHUD = FindObjectOfType<PauseHUDGroup>();
		gameOverHUD = FindObjectOfType<GameOverHUDGroup>();
		mainHUD = FindObjectOfType<MainHUDGroup>();

		robotRef = FindObjectOfType<Robot>();
	}


    // Use this for initialization
    void Start()
    {
		
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
		robotRef.startDrainingHealth();
	}
}
