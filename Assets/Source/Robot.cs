using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

	// The health of the robot
	private int health = 100;


	/*--GETTERS AND SETTERS--*/

	// Get and set the robot's health value
	public int getHealth()
	{
		return health;
	}

	public void setHealth(int health)
	{
		this.health = health;
		print("Health:" + getHealth());
	}
	

	/*--END OF GETTERS AND SETTERS--*/


    // Use this for initialization
    void Start()
    {
		startDrainingHealth();
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
		if (getHealth() == 0)
		{
			stopDrainingHealth();
		}
	}

	// Start draining the health of the robot
	public void startDrainingHealth()
	{
		InvokeRepeating("drainHealth", 0.0f, 1.0f);
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
