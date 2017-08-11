using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

	// The health of the robot
	private int health = 10;


	// The default delay before the robot starts losing health
	[SerializeField]
	private float defaultHealthLossDelay = 1.0f;

	// EXTERNAL REFERENCES
	private GameManager gameManagerRef;

	/*--GETTERS AND SETTERS--*/

	// Get and set the robot's health value
	public int getHealth()
	{
		return health;
	}

	public void setHealth(int health)
	{
		this.health = health;
	}
	

	// Get and set the default health loss delay
	public float getDefaultHealthLossDelay()
	{
		return defaultHealthLossDelay;
	}

	public void setDefaultHealthLossDelay(float defaultHealthLossDelay)
	{
		this.defaultHealthLossDelay = defaultHealthLossDelay;
	}

	/*--END OF GETTERS AND SETTERS--*/


	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		gameManagerRef = FindObjectOfType<GameManager>();
	}


    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {

    }

	// Drain the health of the robot
	private void drainHealth()
	{
		decreaseHealth(1);

		// If the health remaining equals 0
		// Stop draining health
		// End the game
		if (getHealth() == 0)
		{
			stopDrainingHealth();
			gameManagerRef.endGame();
		}
	}

	// Start draining the health of the robot
	public void startDrainingHealth(float initialDelay)
	{
		InvokeRepeating("drainHealth", initialDelay, 1.0f);
	}

	// Stop draining the health of the robot
	public void stopDrainingHealth()
	{
		CancelInvoke("drainHealth");
	}


	// Decrease the health of the robot
	public void decreaseHealth(int decreaseAmount)
	{
		setHealth(getHealth() - decreaseAmount);
	}

	// Increase the health of the robot
	public void increaseHealth(int increaseAmount)
	{
		setHealth(getHealth() + increaseAmount);
	}
}
