using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// The current game state
	private PossibleGameStates currentGameState = PossibleGameStates.Active;



	// HUD REFERENCES
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
		pauseHUD = FindObjectOfType<PauseHUDGroup>();
		gameOverHUD = FindObjectOfType<GameOverHUDGroup>();
		mainHUD = FindObjectOfType<MainHUDGroup>();
	}


    // Use this for initialization
    void Start()
    {
		pauseGame();
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

	}

	// Restart the game
	public void restartGame()
	{

	}

	// Start the game
	public void startGame()
	{

	}
}
